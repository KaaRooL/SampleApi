using System.Security.Claims;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Firebase;

public class FirebaseAuthenticationFunctionHandler
{
    private const string BEARER_PREFIX = "Bearer ";

    private readonly FirebaseApp _firebaseApp;

    public FirebaseAuthenticationFunctionHandler(FirebaseApp firebaseApp)
    {
        _firebaseApp = firebaseApp;
    }
    
    public async Task<AuthenticateResult> HandleFirebaseAuthenticateAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.NoResult();
        }

        context.Request.Headers.TryGetValue("Authorization", out var authorizationValue);
        var bearerToken = authorizationValue.ToString();
        
        if (!bearerToken.StartsWith(BEARER_PREFIX))
        {
            return AuthenticateResult.Fail("Invalid scheme.");
        }
        string token = bearerToken.Substring(BEARER_PREFIX.Length);

        try
        {
            FirebaseToken firebaseToken = await FirebaseAuth.GetAuth(_firebaseApp).VerifyIdTokenAsync(token);
            return AuthenticateResult.Success(CreateAuthenticationTicket(firebaseToken));
        }
        catch (Exception ex)
        {
            return AuthenticateResult.Fail(ex);
        }
    }
    private AuthenticationTicket CreateAuthenticationTicket(FirebaseToken firebaseToken)
    {
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new List<ClaimsIdentity>()
        {
            new(ToClaims(firebaseToken.Claims), nameof(ClaimsIdentity))
        });

        return new AuthenticationTicket(claimsPrincipal, JwtBearerDefaults.AuthenticationScheme);
    }

    private IEnumerable<Claim> ToClaims(IReadOnlyDictionary<string, object> claims)
    {
        return new List<Claim>
        {
            new(FirebaseUserClaimType.ID, claims.GetValueOrDefault("user_id", "").ToString()),
            new(FirebaseUserClaimType.EMAIL, claims.GetValueOrDefault("email", "").ToString()),
            new(FirebaseUserClaimType.EMAIL_VERIFIED, claims.GetValueOrDefault("email_verified", "").ToString()),
            new(FirebaseUserClaimType.USERNAME, claims.GetValueOrDefault("name", "").ToString()),
        };
    }
}
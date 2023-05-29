using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Firebase;

public class FirebaseAuthenticationHandler:  AuthenticationHandler<FirebaseAuthenticationOptions>
{
    private readonly FirebaseAuthenticationFunctionHandler _firebaseAuthenticationFunctionHandler;

    public FirebaseAuthenticationHandler(IOptionsMonitor<FirebaseAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, FirebaseAuthenticationFunctionHandler firebaseAuthenticationFunctionHandler) : base(options, logger, encoder, clock)
    {
        _firebaseAuthenticationFunctionHandler = firebaseAuthenticationFunctionHandler;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        return _firebaseAuthenticationFunctionHandler.HandleFirebaseAuthenticateAsync(Context);
    }
}
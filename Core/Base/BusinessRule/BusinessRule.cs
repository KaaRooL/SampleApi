/* Copyright (C) 2022 Patco, LLC - All Rights Reserved. You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC. */
namespace Core.Base.BusinessRule
{
	internal static class BusinessRule
	{
		public static void Check(IBusinessRule rule) => rule.Invoke();
	}
}
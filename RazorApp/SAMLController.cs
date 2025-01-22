namespace exmplRazor
{
	using ITfoxtec.Identity.Saml2;
	using ITfoxtec.Identity.Saml2.Schemas;
	using Microsoft.AspNetCore.Mvc;

	namespace YourApp.Controllers
	{
		public class SAMLController : Controller
		{
			private readonly Saml2Configuration _saml2Config;

			public SAMLController(Saml2Configuration saml2Config)
			{
				_saml2Config = saml2Config;
			}

			// This is the URL where users will be redirected to sign in
			//[HttpGet]
			//public IActionResult SignIn()
			//{
			//	var signInRequest = new Saml2AuthnRequest(_saml2Config)
			//	{
			//		DestinationUrl = _saml2Config.SingleSignOnDestination // Azure AD SSO URL
			//	};
			//	return Redirect(signInRequest.RedirectUrl);
			//}

			// This is the Assertion Consumer Service (ACS) endpoint where the SAML response is sent
			[HttpPost]
			public IActionResult ACS()
			{
				var samlResponse = new Saml2AuthnResponse(_saml2Config);

				if (samlResponse.Status == Saml2StatusCodes.AuthnFailed)
				{
					return Unauthorized("Invalid SAML Response");
				}

				// Extract user information from the SAML assertion
				var userName = samlResponse.NameId; // Or any other attribute based on your config
													// Authenticate the user in your system or create an identity

				return RedirectToAction("Index", "Home"); // Redirect to a page after login
			}

			// Optionally, you can add a sign-out method
			[HttpGet]
			public IActionResult SignOut()
			{
				return RedirectToAction("Index", "Home");
			}
		}
	}

}

namespace exmplRazor
{
	public class Saml2ConfigurationNUsed
	{
		public string EntityId { get; set; } // Set this to your Azure AD App's Entity ID
		public string SingleSignOnDestination { get; set; } // Azure AD SSO URL
		public string SingleLogoutDestination { get; set; } // Optional, if you want to support SLO
		public string CertificateFile { get; set; } // Your certificate file for signing/encryption
		public string CertificatePassword { get; set; } // Password for your certificate
														// You can add more configurations as required
	}
}

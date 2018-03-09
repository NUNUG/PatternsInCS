using OldAuthenticationSystem;
using NewAuthenticationSystem;

namespace AuthSystemAdapter 
{
	public class AuthenticatorAdapter : IOldAuthenticator
	{
		private INewAuthenticator NewAuthenticator { get; }
		public AuthenticatorAdapter(INewAuthenticator newAuthenticator)
		{
			this.NewAuthenticator = newAuthenticator;
		}
		public bool Login(string username, string password)
		{
			this.NewAuthenticator.SetEmailAddress($"{username.ToLower()}@myorganization.com");
			this.NewAuthenticator.SetPassword(password);
			bool result = this.NewAuthenticator.Authenticate();
			return result;
		}
	}
}
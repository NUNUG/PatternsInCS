using System;

namespace OldAuthenticationSystem
{
	public interface IOldAuthenticator
	{
		bool Login(string username, string password);
	}

	public class OldAuthenticator : IOldAuthenticator
	{
		public bool Login(string username, string password)
		{
			// This system no longer works.  We have to use the new system now.
			//return (username.Equals("Phil") && password.Equals("blah"));
			throw new Exception("The OldAuthenticationSystem is deprecated.  Use the NewAuthenticationSystem instead.");
		}
	}
}
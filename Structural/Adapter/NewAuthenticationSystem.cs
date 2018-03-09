using System;

namespace NewAuthenticationSystem
{
	// Pretend that this interface is imported from a remote service and cannot be changed.
	public interface INewAuthenticator
	{
		void SetEmailAddress(string emailAddress);
		void SetPassword(string password);
		bool Authenticate();
	}

	// Pretend that this implementation calls a remote service to get a result.
	public class NewAuthenticator : INewAuthenticator
	{
		private string _emailAddress;
		private string _password;

		public void SetEmailAddress(string emailAddress)
		{
			this._emailAddress = emailAddress;
		}

		public void SetPassword(string password)
		{
			this._password = password;
		}

		public bool Authenticate()
		{
			return this._emailAddress.Equals("phil@myorganization.com") && this._password.Equals("blah");
		}
	}
}
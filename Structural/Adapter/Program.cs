using System;
using OldAuthenticationSystem;
using NewAuthenticationSystem;
using AuthSystemAdapter;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
			// ****** This code is only used here and its creation can be changed. ******

			// This sytem works as is.
			//var authSystem = new OldAuthenticator() as IOldAuthenticator;

			// This, of course, won't compile because of a type mismatch.  
			// It's the wrong interface.
			//var authSystem = new NewAuthenticator() as INewAuthenticator;

			// This uses an adapter so we can keep referencing the old auth 
			// system interface with the new auth system implementation.
			var newAuthSystem = new NewAuthenticator() as INewAuthenticator;
			var authSystem = new AuthenticatorAdapter(newAuthSystem) as IOldAuthenticator;

            Program p = new Program(authSystem);
			p.Execute();
        }

		private IOldAuthenticator Authenticator { get; }
		
		public Program(IOldAuthenticator authenticator)
		{
			this.Authenticator = authenticator;
		}

		private void Execute()
		{
			// This code is used everywhere.  We don't want to break it.
			string username = "Phil";
			string password = "blah";
			var success = this.Authenticator.Login(username, password);
			Console.WriteLine($"Login result: {success.ToString()}");
		}
	}
}

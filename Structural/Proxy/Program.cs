using System;
using System.Text;
using System.Linq;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
			p.Execute();
        }

		private void Execute()
		{
			SuperSlowRemoteServiceWrittenInPHP remoteService = new SuperSlowRemoteServiceWrittenInPHP();
			ServiceClient client = new ServiceClient(remoteService);
			var myID = client.GetIDForUser("Phil");
			Console.WriteLine(
				new StringBuilder()
					.AppendLine($"Data for user ID {myID}:")
					.AppendLine(
				 		client
							.GetAllRecordProxies()
							.First(r => r.ID == myID)
							.Data)
					.ToString()
				);


			
		}
	}
}

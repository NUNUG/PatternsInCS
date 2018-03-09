using System;
using System.Collections.Generic;

namespace Proxy 
{

	public class ServiceClient
	{
		private SuperSlowRemoteServiceWrittenInPHP _service;

		public ServiceClient(SuperSlowRemoteServiceWrittenInPHP service)
		{
			_service = service;
		}

		public int GetDatabaseRecordCount()
		{
			return _service.GetDatabaseRecordCount();
		}

		public int GetIDForUser(string userName)
		{
			return _service.GetIDForUser(userName);
		}

		public List<DatabaseRecord> GetAllRecords()
		{
			// NO NO NO!  We could never do this because it would take up to 1000ms * 2000 records to finish.  
			// Plus, it'll be too big to handle.  Giggity.
			List<DatabaseRecord> result = new List<DatabaseRecord>();
			int count = _service.GetDatabaseRecordCount();
			for (int j = 0; j < count; j++)
			{
				Console.WriteLine($"Fetched record {j} of {count}.");
				result.Add(_service.GetDataBaseRecordByID(j));
			}
			return result;
		}

		public List<DatabaseRecordProxy> GetAllRecordProxies()
		{
			// NO NO NO!  We could never do this because it would take up to 1000ms * 2000 records to finish.  
			List<DatabaseRecordProxy> result = new List<DatabaseRecordProxy>();
			int count = _service.GetDatabaseRecordCount();
			for (int j = 0; j < count; j++)
			{
				Console.WriteLine($"Created proxy for record {j} of {count}.");
				result.Add(new DatabaseRecordProxy(j, this));
			}
			return result;
		}

		public DatabaseRecord GetDataBaseRecordByID(int recordID)
		{
			// This process is slow.  It takes 1000 ms eaches to get this data back from the server.
			Console.WriteLine($"Retrieving record {recordID} from the server...");
			var result = _service.GetDataBaseRecordByID(recordID);
			Console.WriteLine("   Done.");
			return result;
		}
	}

}
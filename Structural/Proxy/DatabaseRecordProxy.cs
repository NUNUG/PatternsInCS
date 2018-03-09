using System;

namespace Proxy
{
	public class DatabaseRecordProxy
	{
		public int ID { get; }
		private ServiceClient _client;
		private DatabaseRecord _databaseRecord = null;

		// This property is forwarded to the actual DatabaseRecord which is represented by this proxy.  
		// This is a lazy proxy, so if there isn't an underlying DatabaseRecord yet, we have to create it.  
		public string Data { 
			get
			{
				if (_databaseRecord == null)
					_databaseRecord = _client.GetDataBaseRecordByID(this.ID);

				return _databaseRecord.Data;
			}
		}

		public DatabaseRecordProxy(int id, ServiceClient client)
		{
			this.ID = id;
			this._client = client;
		}
	}
}
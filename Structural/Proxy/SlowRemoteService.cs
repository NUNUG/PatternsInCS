using System;
using System.Text;


namespace Proxy 
{
	// We'll just pretend that this is on a remote machine.
	public class SuperSlowRemoteServiceWrittenInPHP
	{
		private Random _rnd;
		public SuperSlowRemoteServiceWrittenInPHP()
		{
			_rnd = new Random((int)(DateTime.Now.Ticks & 0x0FFFFFFFF));
		}

		public int GetDatabaseRecordCount()
		{
			return _rnd.Next(1000, 2000);
		}

		public int GetIDForUser(string userName)
		{
			if (userName.Equals("Phil"))
				return 895;
			else
				return _rnd.Next(1, 1999);
		}

		public DatabaseRecord GetDataBaseRecordByID(int recordID)
		{
			DatabaseRecord recordData = new DatabaseRecord(recordID);
			System.Threading.Thread.Sleep(1000);
			return recordData;
		}
	}

	public class DatabaseRecord 
	{
		public int ID { get; }
		public string Data { get; }
		public DatabaseRecord(int id)
		{
			this.ID = id;
			Random rnd = new Random((int)(DateTime.Now.Ticks & 0x0FFFFFFFF));
			int size = rnd.Next(100, 1000);
			StringBuilder sb = new StringBuilder();
			for(int j = 0; j < size; j++)
			{
				byte ascii = (byte) (rnd.Next(65, 65+26-1) & 0x0FF);
				char c = (char)ascii;
				sb.Append(c);
			}
			string s = sb.ToString();
			this.Data = s;
		}
	}
}
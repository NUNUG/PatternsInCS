using System;
using System.Text;

namespace Facade{

	public class DataProducer
	{
		public string CreateData(int size)
		{
			Random rnd = new Random((int)(DateTime.Now.Ticks & 0x0FFFFFFFF));
			StringBuilder sb = new StringBuilder();
			for(int j = 0; j < size; j++)
			{
				byte ascii = (byte) (rnd.Next(65, 65+26-1) & 0x0FF);
				char c = (char)ascii;
				sb.Append(c);
			}
			string s = sb.ToString();
			
			return s;
		}
	}
}
using System;
using System.Text;

namespace Prototype 
{
	public class SuperSlowInternetConnection
	{
		public SuperSlowInternetConnection()
		{
		}

		public ExpensiveData DownloadBootlegGame(int gameSize)
		{
			ExpensiveData randomData = ExpensiveDataProducer.GetData(gameSize);
			return randomData;
		}
	}

	public static class ExpensiveDataProducer 
	{
		public static ExpensiveData GetData(int size)
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
			ExpensiveData result = new ExpensiveData(s);
			return result;
		}
	}

	public interface ICompressResult
	{
		ExpensiveData CompressedData {get; }
	}

	public interface ICompressor
	{
		ICompressResult Compress(ExpensiveData data);
	}


	public class CompressResult : ICompressResult
	{
		public ExpensiveData CompressedData { get; }

		public CompressResult(ExpensiveData compressedData)
		{
			Random _rnd = new Random();
			CompressedData = compressedData;
		}
	}

	public class Compressor : ICompressor
	{
		public ICompressResult Compress(ExpensiveData data)
		{
			Random rnd = new Random((int)(DateTime.Now.Ticks & 0x0FFFFFFFF));
			var originalData = data;
			int minSize = (int)(originalData.Size / 2) + 1;
			int maxSize = (int)(originalData.Size * 1.5) + 1;
			var newDataSize = rnd.Next(minSize, maxSize);
			ExpensiveData newData = ExpensiveDataProducer.GetData(newDataSize);
			return new CompressResult(newData);
		}

	}

	public class PCXCompressor: Compressor { } 
	public class RLE3compressor: Compressor { }
}
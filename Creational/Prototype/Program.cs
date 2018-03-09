using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
			ICompressor pcx = new PCXCompressor();
			ICompressor rle3 = new RLE3compressor();
			SuperSlowInternetConnection connection = new SuperSlowInternetConnection();

			// This is too expensive to do twice!!
            // ExpensiveData gameData1 = SuperSlowInternetConnection.DownloadBootlegGame();
            // ExpensiveData gameData2 = SuperSlowInternetConnection.DownloadBootlegGame();

			// Let's use a proxy instead.
			ExpensiveData originalGameData = connection.DownloadBootlegGame(1000000);
			ExpensiveData gameData1 = originalGameData.Clone();
			ExpensiveData gameData2 = originalGameData.Clone();


			// Which compression is more effective?
			ICompressResult pcxResult = gameData1.Compress(pcx);
			ICompressResult rle3Result = gameData1.Compress(rle3);
			if (pcxResult.CompressedData.Size < rle3Result.CompressedData.Size)
			{
				Console.WriteLine($"PCX is smaller with a size of ({pcxResult.CompressedData.Size}) bytes.");
			}
			else  
			{
				Console.WriteLine($"RLE3 is smaller with a size of ({pcxResult.CompressedData.Size}) bytes.");
			}
        }
    }

	public interface IPrototype<T>
	{
		T Clone();
	}

	public class ExpensiveData: IPrototype<ExpensiveData>
	{
		public string Data;
		public int Size => Data.Length;

		public ExpensiveData(string source)
		{
			this.Data = source;
		}
		
		public ICompressResult Compress(ICompressor compressor)
		{
			return compressor.Compress(this);
		}

		public ExpensiveData Clone()
		{
			return new ExpensiveData(this.Data);
		}
	}
}

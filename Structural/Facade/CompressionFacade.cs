using CompressionStuff;

namespace Facade
{
	public interface ICompressionFacade
	{
		string Zip(string bigData);
		string BZip2(string bigData);
	}

	public class CompressionFacade: ICompressionFacade
	{
		public string Zip(string bigData)
		{
			ICompressionAlgorithm lz = new LZ77CompressionAlgorithm() as ICompressionAlgorithm;
			string lzOutput = lz.Compress(bigData);
			IEntropyCoder entropy = new ShannonFanoTreeCoder() as IEntropyCoder;
			string entropyOutput = entropy.Encode(lzOutput);
			return entropyOutput;
		}

		public string BZip2(string bigData)
		{
			ICompressionAlgorithm bwt = new BurrowsWheelerTransformAlgorithm() as ICompressionAlgorithm;
			string bwtOutput = bwt.Compress(bigData);
			IDataTransform mtf = new MoveToFrontTransform() as IDataTransform;
			string mtfOutput = mtf.Transform(bwtOutput);
			IRunLengthCoder rle = new RLE2Encoding() as IRunLengthCoder;
			string rleOutput = rle.Encode(mtfOutput);
			IEntropyCoder huffman = new AdaptiveHuffmanCoder() as IEntropyCoder;
			string huffmanOutput = huffman.Encode(rleOutput);
			return huffmanOutput;
		}
	}
}
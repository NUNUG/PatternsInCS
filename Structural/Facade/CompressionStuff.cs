
namespace CompressionStuff
{
	public interface ICompressionAlgorithm { string Compress(string data); }
	public abstract class CompressionAlgorithm: ICompressionAlgorithm { public virtual string Compress(string data) { return data; } }
	public class LZ77CompressionAlgorithm: CompressionAlgorithm { }
	public class LZ78CompressionAlgorithm: CompressionAlgorithm { }
	public class BurrowsWheelerTransformAlgorithm: CompressionAlgorithm { }
	
	public interface IDataTransform { string Transform(string data); }
	public abstract class DataTransform: IDataTransform { public virtual string Transform(string data) { return data; } }
	public class MoveToFrontTransform: DataTransform { }
	public class MoveToFrontOneTransform: DataTransform { }
	public class DistanceTransform: DataTransform { } 
	
	public interface IRunLengthCoder { string Encode(string data); }
	public abstract class RunLengthCoder: IRunLengthCoder { public virtual string Encode(string data) { return data; } }
	public class PCXEncoding: RunLengthCoder { }
	public class RLE2Encoding: RunLengthCoder { }
	public class RLE3Encoding: RunLengthCoder { }

	public interface IEntropyCoder { string Encode(string data); }
	public abstract class EntropyCoder: IEntropyCoder { public virtual string Encode(string data) { return data; } }
	public class ShannonFanoTreeCoder: EntropyCoder { }
	public class StaticHuffmanCoder: EntropyCoder { }
	public class CanonicalHuffmanCoder: EntropyCoder { }
	public class AdaptiveHuffmanCoder: EntropyCoder { }
	public class ArithmeticCoder: EntropyCoder{ }
}
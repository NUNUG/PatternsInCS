using System;

namespace Facade
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
			var dataProducer = new DataProducer();
			var data = dataProducer.CreateData(100);

			ICompressionFacade compressionFacade = new CompressionFacade();
			var zippedData = compressionFacade.Zip(data);

			// There is no implementation in the compression library itself, 
			// so this application has no actual output.
		}
	}
}

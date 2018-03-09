using System;

namespace ChainOfResponsibility
{
	public class CommandExecutor
	{
		private IProcessor _chain;
		public void AddProcessor(IProcessor processor)
		{
			processor.AppendToChain(_chain);
			_chain = processor;
		}

		public void Execute(string command)
		{
			Console.WriteLine("---- CommandExecutor is executing the following command:");
			Console.WriteLine($"----{command}");
			_chain.ProcessCommand(command);
		}
	}
}
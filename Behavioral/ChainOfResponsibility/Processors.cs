using System;

namespace ChainOfResponsibility
{
	public interface IProcessor
	{
		void AppendToChain(IProcessor chain);
		void ProcessCommand(string command);
	}

	public abstract class AbstractProcessor : IProcessor
	{
		private IProcessor _nextProcessor;
		public void AppendToChain(IProcessor chain)
		{
			_nextProcessor = chain;
		}

		public void ProcessCommand(string command)
		{
			if (CanProcessCommand(command))
				Execute(command);
			else
				if (_nextProcessor == null) 
					Console.WriteLine($"NO PROCESSOR FOUND FOR COMMAND ({command})!");
				else
					_nextProcessor.ProcessCommand(command);
		}

		public abstract void Execute(string command);

		protected abstract bool CanProcessCommand(string command);
	}

	public class EmailProcessor : AbstractProcessor
	{
		public override void Execute(string command)
		{
			Console.WriteLine("The email has been sent.");
		}

		protected override bool CanProcessCommand(string command)
		{
			return command.Equals("EmailMeAReport");
		}
	}

	public class DefragProcessor : AbstractProcessor
	{
		public override void Execute(string command)
		{
			Console.WriteLine("Defragging now.");
		}

		protected override bool CanProcessCommand(string command)
		{
			return command.Equals("RunDefrag");
		}
	}

	public class JokeProcessor : AbstractProcessor
	{
		public override void Execute(string command)
		{
			Console.WriteLine("Question: What did the snowman say to the other snowman?");
			Console.WriteLine("Answer: Do you smell carrots?");
		}

		protected override bool CanProcessCommand(string command)
		{
			return command.Equals("TellMeAJoke");
		}
	}
}
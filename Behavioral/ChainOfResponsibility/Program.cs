using System;

namespace ChainOfResponsibility
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
			CommandExecutor executor = new CommandExecutor();
			executor.AddProcessor(new EmailProcessor());
			executor.AddProcessor(new DefragProcessor());
			executor.AddProcessor(new JokeProcessor());

			executor.Execute("EmailMeAReport");

			executor.Execute("RunDefrag");

			executor.Execute("SomeInvalidCommand");	// There is no processor for this.

			executor.Execute("TellMeAJoke");
		}
	}
}

using System;

namespace Composite
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
			var e = new BinaryExpression(
				new BinaryExpression(
					new LiteralExpression("FirstName"),
					ExpressionBinaryOperator.EQUALS,
					new LiteralExpression("Phil")
				),
				ExpressionBinaryOperator.AND,
				new NotExpression(
					new LiteralExpression("Dead")
				)
			);

			Console.WriteLine(e.ToString());
		}
	}
}

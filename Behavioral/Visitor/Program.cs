using System;
using System.Collections.Generic;
using System.Linq;

namespace Visitor
{
	public interface IIterable
	{
		int Value { get; }
	}

    class Program: IIterable
    {
        static void Main(string[] args)
        {
			Program p = new Program();
			p.Accept(new FizzBangVisitor());
        }

		private int _value;
		public int Value { get { return _value; } }
		
		public void Accept(FizzBangVisitor visitor)
		{
			for(int j = 1; j <= 15; j++)
			{
				this._value = j;
				visitor.Visit(this);
			}
		}
    }

	public class FizzBangVisitor
	{
		public void Visit(IIterable client)
		{
			int v = client.Value;
			string s = 
				string.Concat(
					(v % 3 == 0) && (v %5 != 0) ? "Fizz" : "",
					(v % 3 != 0) && (v %5 == 0) ? "Bang" : "",
					(v % 3 == 0) && (v %5 == 0) ? "FizzBang" : "",
					(v % 3 != 0) && (v %5 != 0) ? v.ToString() : ""
				);

			Console.WriteLine(s);
		}
	}
}

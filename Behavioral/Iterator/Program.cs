using System;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
			p.DotItTheOldFashionedWay();
			p.DoItManuallyTheNewWay();
			p.DoItAutomaticallyTheNewWay();
			p.DoItWithLinq();
        }

		private void DotItTheOldFashionedWay()
		{
			Console.WriteLine("Manually, the old way");
			// Without first class language support, you would do it like this.
			SomeCollectionObject c = new SomeCollectionObject();
			for(int j = 1; j <= 5; j++)
				c.Add(j.ToString());
			
			var e = c.GetEnumerator();
			while (e.MoveNext())
				Console.WriteLine(e.Current);
		}

		private void DoItManuallyTheNewWay()
		{
			Console.WriteLine("Manually, the new way.");
			// IEnumerable<T> is built into C#!
			// List, IList and nearly all other collections already implement it, but as a class, not the universal interface.
			List<string> numberList = new List<string>(Enumerable.Range(1, 5).Select(i => i.ToString()));
			List<string>.Enumerator e = numberList.GetEnumerator();
			while(e.MoveNext())
				Console.WriteLine(e.Current);
		}

		private void DoItAutomaticallyTheNewWay()
		{
			Console.WriteLine("Automatically, the new way.");
			// Any type of collection in .NET can be iterated, almost like magic.
			// This includes ILists, IEnumerables and Arrays.
			// Foreach will easily iterate over them for you.
			List<string> numberList = new List<string>() { "1", "2", "3", "4", "5" };
			foreach(string s in numberList)
				Console.WriteLine(s);
		}

		private void DoItWithLinq()
		{
			Console.WriteLine("With Linq!");
			// Linq loves iterators.
			Enumerable.Range(1, 5)						// Returns an IEnumerable
				.Select(i => i.ToString())				// Iterates over it, transforming each element and returning the whole thing as a new IEnumerable.
				.ToList()								// Converts to a List<string>.  We have to do that to get to the ForEach that comes next.  This is an aspect of Linq, not of iterators.
				.ForEach(s => Console.WriteLine(s));	// Iterate over the list and take action on each element.
		}
	}
}

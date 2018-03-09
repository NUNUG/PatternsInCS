using System;
using System.Collections.Generic;
using System.Linq;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
			p.IterateHeroes()
				.ToList()
				.ForEach(h => 
				{
					Console.WriteLine($"{h.GetType().Name} says:  ------------------");
					h.Transform();
					h.EngageInCombat();
				});
        }

		public IEnumerable<Hero> IterateHeroes()
		{
			yield return new Hulk();
			yield return new Batman();
			yield return new Superman();
		}
		

    }
}

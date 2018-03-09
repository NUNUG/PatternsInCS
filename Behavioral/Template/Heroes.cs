using System;

namespace Template
{

	public class Hero
	{
		public virtual void Transform()
		{
			Console.WriteLine("I don't understand.  Transform into what?");
		}

		public virtual void EngageInCombat()
		{
			Console.WriteLine("Now, there's no need for fisticuffs.");
		}
	}

	public class Hulk: Hero
	{
		public override void Transform()
		{
			Console.WriteLine("Hulk SMASH!");
		}

		public override void EngageInCombat()
		{
			Console.WriteLine("Hulk SMASH!");
		}
	}

	public class Batman: Hero
	{
		public override void Transform()
		{
			Console.WriteLine("To the BatCave, Alfred!");
		}

		public override void EngageInCombat()
		{
			Console.WriteLine("Death from above.");
		}
	}

	public class Superman: Hero
	{
		public override void Transform()
		{
			Console.WriteLine("Where are all the phone booths in the 21st century?  I can't change clothes in a Nokia!");
		}

		public override void EngageInCombat()
		{
			Console.WriteLine("Just doing my part, Mr. President.");
		}
	}

}
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoFactory
{
	class Butler
	{
		static void Main(string[] args)
		{
			Butler b = new Butler();
			b.AnswerDoor();
			b.Greet();
			b.OfferBeverage();
			b.Farewell();
			Console.ReadLine();
		}

		private IList<string> Friends { get; set; }
		private IList<string> Family { get; set; }
		private string Guest { get; set; }

		public Butler()
		{
			this.Friends = new List<string>() { "Billy", "Bobby" };
			this.Family = new List<string>() { "Willy", "Wally" };
		}


		private void AnswerDoor()
		{
			Console.WriteLine("Knock knock.");
			Console.WriteLine("Who's there?");
			this.Guest = Console.ReadLine();
		}

		private void Greet()
		{
			if (this.Friends.Select(s => s.ToUpper()).Contains(Guest.ToUpper()))
			{
				Console.WriteLine("DUDE!  Get in here!  How ya been?");
			}
			else if (this.Family.Select(s => s.ToUpper()).Contains(Guest.ToUpper()))
			{
				Console.WriteLine("Oh.  It's you.  Do you need money or something?");
			}
			else
			{
				Console.WriteLine("Welcome. Won't you come in?");
			}
		}

		private void OfferBeverage()
		{
			if (this.Friends.Select(s => s.ToUpper()).Contains(Guest.ToUpper()))
			{
				Console.WriteLine("What'll ya have, bro?");
			}
			else if (this.Family.Select(s => s.ToUpper()).Contains(Guest.ToUpper()))
			{
				Console.WriteLine("You can get yourself a water, I guess.");
			}
			else
			{
				Console.WriteLine("Fancy a beverage?");
			}
		}

		private void Farewell()
		{
			if (this.Friends.Select(s => s.ToUpper()).Contains(Guest.ToUpper()))
			{
				Console.WriteLine("Don't be a stranger.  Say hello to those kids for me.");
			}
			else if (this.Family.Select(s => s.ToUpper()).Contains(Guest.ToUpper()))
			{
				Console.WriteLine("Don't let the door hit you on the way out.");
			}
			else
			{
				Console.WriteLine("Farewell and goodnight!");
			}
		}
	}
}



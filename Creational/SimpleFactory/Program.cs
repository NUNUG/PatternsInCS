using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleFactory
{
	class Party
	{
		static void Main(string[] args)
		{
			GreetingsFactory gf = new GreetingsFactory();
			Butler b = new Butler(gf);
			Party p = new Party(b);
			
			Console.WriteLine("Who has arrived?");
			var guest = Console.ReadLine();
			p.GuestArrives(guest);
		}

	 	private Butler MyButler { get; set; }

	 	public Party(Butler butler)
	 	{
			 this.MyButler = butler;
		}
	 	
		public void GuestArrives(string guest)
		{
			Console.WriteLine("Knock knock!");
			MyButler.AnswerDoor(guest);
		}
	
}

	internal class GreetingsFactory
	{
		public List<string> Friends { get; set; }
		public List<string> Family { get; set; }

		public GreetingsFactory() 
		{
			Friends = new List<string>();
			Family = new List<string>();
		}

		public Greetings CreateGreetings(string guest)
		{
			if (this.Friends.Contains(guest))
				return new FriendGreetings();
			else if (this.Family.Contains(guest))
				return new FamilyGreetings();
			else
				return new PoliteGreetings();
		}
	}

	internal class Butler
	{
		private GreetingsFactory greetingsFactory;
		private Greetings greetings;

		public Butler(GreetingsFactory greetingsFactory)
		{
			this.greetingsFactory = greetingsFactory;
			this.greetingsFactory.Friends.AddRange(new[] { "Billy", "Bobby" });
			this.greetingsFactory.Family.AddRange(new[] { "Willy", "Wally" });
		}

		public void AnswerDoor(string guest)
		{
			this.greetings = greetingsFactory.CreateGreetings(guest);
			Greet();
			OfferBeverage();
			Farewell();
		}

		public void Greet() 
		{
			Console.WriteLine(greetings.Greet());
		}
		public void OfferBeverage()
		{
			Console.WriteLine(greetings.OfferBeverage());
		}
		public void Farewell()
		{
			Console.WriteLine(greetings.Farewell());

		}
	}

	internal abstract class Greetings
	{
		public abstract string Greet();
		
		public abstract string OfferBeverage();
		
		public abstract string Farewell();
	}

	internal class PoliteGreetings: Greetings
	{
		public override string Greet()
		{
			return "Welcome. Won't you come in?";
		}
		
		public override string OfferBeverage()
		{
			return "Fancy a beverage?";
		}
		
		public override string Farewell()
		{
			return "Farewell and goodnight!";
		}
	}

	internal class FamilyGreetings: Greetings
	{
		public override string Greet()
		{
			return "Oh.  It's you.  Do you need money or something?";
		}
		
		public override string OfferBeverage()
		{
			return "You can get yourself a water, I guess.";
		}
		
		public override string Farewell()
		{
			return "Don't let the door hit you on the way out.";
		}
	}

	internal class FriendGreetings: Greetings
	{
		public override string Greet()
		{
			return "DUDE!  Get in here!  How ya been?";
		}
		
		public override string OfferBeverage()
		{
			return "What'll ya have, bro?";
		}
		
		public override string Farewell()
		{
			return "Don't be a stranger.  Say hello to those kids for me.";
		}
	}

}
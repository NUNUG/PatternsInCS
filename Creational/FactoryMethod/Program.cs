using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleFactory
{
	class Party
	{
		static void Main(string[] args)
		{
			// W can't pass in the butler anymore because we can't build it here.
			// We need a guest just to CREATE one.  So Party will have to do it later.  
			// Party shouldn't be the one doing this.
			Party p = new Party();
			
			Console.WriteLine("Who has arrived?");
			var guest = Console.ReadLine();
			p.GuestArrives(guest);
		}

	 	private Butler MyButler { get; set; }

	 	public Party()
	 	{
		}
	 	
		public void GuestArrives(string guest)
		{
			// Now that we have a guest, someone can create a Butler.
			// It shouldn't be Party that does this.  Party shouldn't be responsible for knowing Butler's 
			// friends and family in the first place. But party has the information 
			// and needs a Butler now and there is nobody else around to do it.
			// Not only that, but we have to construct a whole new butler for each guest that arrives!
			// We could instead create one of each type and than add an IF THEN IF THEN IF THEN ELSE THEN IF SOMETHING ELSE,
			// But then why even bother with a creational pattern in the first place?
			// Here we go.
			if (new [] { "Billy", "Bobby" }.Contains(guest))
				MyButler = new FriendButler();
			else if (new [] { "Willy", "Wally" }.Contains(guest))
				MyButler = new FamilyButler();
			else  
				MyButler = new PoliteButler();
			
			Console.WriteLine("Knock knock!");
			MyButler.AnswerDoor(guest);
		}
	
}

	internal abstract class Butler
	{
		private Greetings greetings;

		public Butler()
		{
		}

        // THIS is the actual factory method.  
        protected abstract Greetings CreateGreetings();

		public void AnswerDoor(string guest)
		{
			this.greetings = CreateGreetings();
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

    internal class FamilyButler: Butler
    {
        protected override Greetings CreateGreetings()
        {
            return new FamilyGreetings();
        }
    }

    internal class FriendButler: Butler
    {
        protected override Greetings CreateGreetings()
        {
            return new FriendGreetings();
        }
    }

    internal class PoliteButler: Butler
    {
        protected override Greetings CreateGreetings()
        {
            return new PoliteGreetings();
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
using System;

namespace Strategy
{

	public abstract class Personality
	{
		public virtual string WhyAmISuchACoward { get; }

		public virtual string ShouldIBuyAMotorcycle { get; }

		public virtual string  SometimesIJustWantSomeontToHoldMeAndTellMeThatEverythingIsGoingToBeAlright { get; }
	}
	public class PotHeadPersonality: Personality
	{
		public override string WhyAmISuchACoward => "The world is a scary place, man.";

		public override string ShouldIBuyAMotorcycle => "Far out, man.";

		public override string SometimesIJustWantSomeontToHoldMeAndTellMeThatEverythingIsGoingToBeAlright => "Aw, come here, buddy.  I love you man.";
	}
	public class InsuranceSalesmanPersonality: Personality
	{
		public override string WhyAmISuchACoward => "You need peace of mind.  I can give it to you.  Sign here.";

		public override string ShouldIBuyAMotorcycle => "Those monsters are dangerous!  Drive your premiums through the roof.";

		public override string SometimesIJustWantSomeontToHoldMeAndTellMeThatEverythingIsGoingToBeAlright => "Whoah!  I think I hear my wife calling.  Here's my card.  I also do real estate.  Call me.";
	}
	public class BodyBulderPersonality: Personality
	{
		public override string WhyAmISuchACoward => "Who could blame you with those girly arms.  Do you even lift, bro?";

		public override string ShouldIBuyAMotorcycle => "Pfft.  You mean you don't have one?  You couldn't handle it anyway.";

		public override string SometimesIJustWantSomeontToHoldMeAndTellMeThatEverythingIsGoingToBeAlright => "I will kill you where you stand.";
	}
	public class MotherPersonality: Personality
	{
		public override string WhyAmISuchACoward => "Not MY big boy.  Who told you that?  I'm calling his mother right now!";

		public override string ShouldIBuyAMotorcycle => "Motorcycles are for thugs and miscreants like that Johnson boy.  Always was a bad seed, that one.";

		public override string SometimesIJustWantSomeontToHoldMeAndTellMeThatEverythingIsGoingToBeAlright => "Everything is going to be alright.";
	}

}
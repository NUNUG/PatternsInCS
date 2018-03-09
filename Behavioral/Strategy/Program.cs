using System;
using System.Collections.Generic;

namespace Strategy
{
    class Program
    {
		static void Main(string[] args)
        {
            Program p = new Program();
        }

		private Personality _friend;
		public Program()
		{
			var potHead = new PotHeadPersonality();
			var insuranceSalesman = new InsuranceSalesmanPersonality();
			var bodyBuilder = new BodyBulderPersonality();
			var mother = new MotherPersonality();

			SetFriend(potHead);
			WhyAmISuchACoward();

			SetFriend(bodyBuilder);
			WhyAmISuchACoward();

			SetFriend(insuranceSalesman);
			ShouldIBuyAMotorcycle();
			
			SetFriend(mother);
			SometimesIJustWantSomeontToHoldMeAndTellMeThatEverythingIsGoingToBeAlright();
		}

		private void SetFriend(Personality personality)
		{
			this._friend = personality;
		}

		public void WhyAmISuchACoward()
		{
			Console.WriteLine(this._friend.WhyAmISuchACoward);
		}

		public void ShouldIBuyAMotorcycle()
		{
			Console.WriteLine(this._friend.ShouldIBuyAMotorcycle);
		}

		public void SometimesIJustWantSomeontToHoldMeAndTellMeThatEverythingIsGoingToBeAlright()
		{
			Console.WriteLine(this._friend.SometimesIJustWantSomeontToHoldMeAndTellMeThatEverythingIsGoingToBeAlright);
		}
	}
}

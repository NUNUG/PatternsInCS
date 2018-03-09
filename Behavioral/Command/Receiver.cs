using System;

namespace Command
{
	public interface ILifeSimulator
	{
		void SnoozeForAnHour();
		void GetUp();
		void GetDressed();
		void BrushTeeth();
		void Shower();
		void EatBreakfast();
		void DriveCarPool();
		void GoToEarlyMeeting();
		void GoToWork();
		void CasualFriday();
		void Oversleep();
		void PutOnDirtyClothes();
		void GrabAPopTart();
	}

	public class LifeSimulator: ILifeSimulator
	{
		public void SnoozeForAnHour()
		{
			Console.WriteLine("Snoozed for an hour.");
		}

		public void GetUp()
		{	
			Console.WriteLine("Whose dog is barking outside?  Well, no sense sleeping now.  You're up.  Getting out of bed now.");
		}
	
		public void GetDressed()
		{
			Console.WriteLine("Put on clean clothes.");
		}
	
		public void BrushTeeth()
		{
			Console.WriteLine("Brushed, rinsed, gargled.  Ah!");
		}
	
		public void Shower()
		{
			Console.WriteLine("Took a shower.  Washed behind ears.");
		}
	
		public void EatBreakfast()
		{
			Console.WriteLine("Made toast.  Yum!");
		}

		public void DriveCarPool()
		{
			Console.WriteLine("Drove the carpool.  Joyce's kid puked in the back again.  I hate that kid.  It's too early for this crap.");
		}

		public void GoToEarlyMeeting()
		{
			Console.WriteLine("Had to leave early for a stupid early morning meeting.  The coffee was cold.");
		}

		public void GoToWork()
		{
			Console.WriteLine("Drove to work.");
		}

		public void CasualFriday()
		{
			Console.WriteLine("Casual Friday!  Changed into jeans.");
		}
	
		public void Oversleep()
		{
			Console.WriteLine("Holy CRAP!  Why didn't my alarm go off?!");
		}

		public void PutOnDirtyClothes()
		{
			Console.WriteLine("(Sniff) .... yeah, it's fine.  I can wear these.");
		}
	
		public void GrabAPopTart()
		{
			Console.WriteLine("Grabbed a pop tart on the way out.");
		}
	
	}

}
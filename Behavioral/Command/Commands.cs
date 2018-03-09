using System;

namespace Command
{	
	public interface ILifeTask
	{
		 void Execute();
	}

	public abstract class LifeTaskCommand: ILifeTask
	{
		protected ILifeSimulator _receiver;
		public LifeTaskCommand(ILifeSimulator receiver)
		{
			this._receiver = receiver;
		}
		public abstract void Execute();
	}

	public class SnoozeForAnHourCommand: LifeTaskCommand
	{
		public SnoozeForAnHourCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.SnoozeForAnHour();
		}
	}

	public class GetUpCommand: LifeTaskCommand
	{
		public GetUpCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.GetUp();
		}
	}
	
	public class GetDressedCommand: LifeTaskCommand
	{
		public GetDressedCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.GetDressed();
		}
	}

	public class BrushTeethCommand: LifeTaskCommand
	{
		public BrushTeethCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.BrushTeeth();
		}
	}

	public class ShowerCommand: LifeTaskCommand
	{
		public ShowerCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.Shower();
		}
	}

	public class EatBreakfastCommand: LifeTaskCommand
	{
		public EatBreakfastCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.EatBreakfast();
		}
	}

	public class DriveCarPoolCommand: LifeTaskCommand
	{
		public DriveCarPoolCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.DriveCarPool();
		}
	}

	public class GoToEarlyMeetingCommand: LifeTaskCommand
	{
		public GoToEarlyMeetingCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.GoToEarlyMeeting();
		}
	}

	public class GoToWorkCommand: LifeTaskCommand
	{
		public GoToWorkCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.GoToWork();
		}
	}

	public class CasualFridayCommand: LifeTaskCommand
	{
		public CasualFridayCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.CasualFriday();
		}
	}

	public class OversleepCommand: LifeTaskCommand
	{
		public OversleepCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.Oversleep();
		}
	}

	public class PutOnDirtyClothesCommand: LifeTaskCommand
	{
		public PutOnDirtyClothesCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.PutOnDirtyClothes();
		}
	}

	public class GrabAPopTartCommand: LifeTaskCommand
	{
		public GrabAPopTartCommand(ILifeSimulator receiver): base(receiver) { }
		public override void Execute()
		{
			_receiver.GrabAPopTart();
		}
	}

}
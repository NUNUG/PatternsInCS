using System;
using System.Collections.Generic;

namespace Command
{
    class Client
    {
        static void Main(string[] args)
        {
			Console.WriteLine("What is the day of the week?");
			string dayOfWeek = Console.ReadLine();

			ILifeSimulator sim = new LifeSimulator();
            DailyRoutines routines = new DailyRoutines(sim);
			routines.UseTypicalMorningProgram(dayOfWeek);
			routines.Simulate();
        }
	}


	// This is the invoker.
	public class DailyRoutines
	{
		// A list of commands.
		private List<LifeTaskCommand> _program;
		private ILifeSimulator _sim;
		public DailyRoutines(ILifeSimulator sim)
		{
			_sim = sim;
			_program = new List<LifeTaskCommand>();
		}

		public void UseTypicalMorningProgram(string dayOfWeek)
		{
			_program.Clear();

			if (!dayOfWeek.Equals("Monday") && !dayOfWeek.Equals("Wednesday"))
				_program.Add(new SnoozeForAnHourCommand(_sim));
			_program.Add(new GetUpCommand(_sim));
			_program.Add(new EatBreakfastCommand(_sim));
			_program.Add(new ShowerCommand(_sim));
			_program.Add(new GetDressedCommand(_sim));
			if (dayOfWeek.Equals("Friday"))
				_program.Add(new CasualFridayCommand(_sim));
			_program.Add(new BrushTeethCommand(_sim));
			if (dayOfWeek.Equals("Monday"))
				_program.Add(new DriveCarPoolCommand(_sim));
			if (dayOfWeek.Equals("Wednesday"))
				_program.Add(new GoToEarlyMeetingCommand(_sim));
			_program.Add(new GoToWorkCommand(_sim));
		}

		public void Simulate()
		{
			_program.ForEach(c => c.Execute());
		}

		public void UseLateMorningProgram(string dayOfWeek)
		{
			_program.Clear();
			_program.Add(new OversleepCommand(_sim));
			_program.Add(new PutOnDirtyClothesCommand(_sim));
			_program.Add(new GrabAPopTartCommand(_sim));
			_program.Add(new GoToWorkCommand(_sim));
		}

	}

}

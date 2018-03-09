using System;

namespace Builder 
{

    class RaceTrackSimulator
    {
		public RaceCar Car {get;set;}
		
		public void Simulate()
		{
			if (this.Car == null) throw new Exception ("You can't race without a car, dummy.");
			if (this.Car.Tires == TireType.None) throw new Exception("Tires must be mounted on the car.  Please specify some tires.");
			if (this.Car.Weight == 0) throw new Exception("Please specify the dry weight of the car.");
			if (this.Car.ZeroTo60Time == 0.0m) throw new Exception("Please specify the ZeroTo60Time for the car.");
			if (this.Car.Engine == EngineType.None) throw new Exception("The car is disqualified due to lack of an engine.");
			
			Console.WriteLine("Simulation complete.");
		}
    }
}
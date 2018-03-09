using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
			// We build a car, but we may not have a lot of knowledge about how it should be built.  
			// There are a lot of properties here.  We may not understand them all.  
			// We may miss some properties.
			// We may have to do this over and over and are repeating ourselves a lot.
			var car1 = new RaceCar();
			car1.Color = "red";
			car1.Engine = EngineType.InlineTurbo;
			car1.Tires = TireType.PRated;
			car1.Weight = 1500 - 25.0m - 63.0m - 8.5m + (8.6m * 5.0m);
			car1.ZeroTo60Time = 5.4m;


			// // Here is a way to do it more flexibly with a builder.
			// var car2 = new CarBuilder()
			// 	.StartWithFordMustang()
			// 	.ChangeTires(TireType.Track)
			// 	.InstallEngine(EngineType.V8SuperCharged)
			// 	.CutOffPart(25.0m)
			// 	.CutOffPart(63.0m)
			// 	.CutOffPart(8.5m)
			// 	.FillGasTank()
			// 	.Build();
				
			// // Ah, but we could also adust the builder just a bit and create a second car.  Or ten identical instances.
			// CarBuilder beachBlastCustoms = new CarBuilder()
			// 	.StartWithMeyersManx()
			// 	.FillGasTank();
			// RaceCar blueManx = beachBlastCustoms.Paint("Blue").Build();
			// RaceCar redManx = beachBlastCustoms.Paint("Red").Build();
			// RaceCar purpleManx = beachBlastCustoms.Paint("Purple").Build();

			RaceTrackSimulator sim = new RaceTrackSimulator();
			sim.Car = car1;
			try 
			{
				sim.Simulate();
			} 
			catch (Exception e) 
			{
				Console.WriteLine(e.Message);
			}
		}
    }
}

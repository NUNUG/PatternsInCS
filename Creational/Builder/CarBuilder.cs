using System;

namespace Builder 
{
	public class CarBuilder 
	{
		// Copies of the RaceCar class's public properties.  Don't just wrap the target's own properties.
		// They shouldn't end up on the target until the Build() method is called.
		private string _color;

		private TireType _tires;
		private EngineType _engine;
		private decimal _zeroTo60Time;
		private decimal _weight;

		// Builder methods.  They're usually fluent.
		public CarBuilder Paint(string color)
		{
			_color = color;
			return this;
		}

		public CarBuilder ChangeTires(TireType tires)
		{
			_tires = tires;
			return this;
		}

		public CarBuilder InstallEngine(EngineType engine)
		{
			_engine = engine;
			return this;
		}

		public CarBuilder SetSpeed(decimal zeroTo60Time)
		{
			_zeroTo60Time = zeroTo60Time;
			return this;
		}

		public CarBuilder SetWeight(decimal initialWeight)
		{
			_weight = initialWeight;
			return this;
		}

		public CarBuilder FillGasTank() 
		{
			_weight = _weight + 8.6m * 5m;
			return this;
		}

		public CarBuilder CutOffPart(decimal weightOfPart)
		{
			_weight = _weight - weightOfPart;
			return this;
		}

		public CarBuilder StartWithFordMustang() 
		{
			this.Init("Grey", EngineType.V8, TireType.PRated, 5.5m, 2200m);
			return this;
		}

		public CarBuilder StartWithDodgeAriesWagon()
		{
			this.Init("Maroon with wood paneling", EngineType.Inline, TireType.Donut, 23.4m, 2100m);
			return this;
		}

		public CarBuilder StartWithMeyersManx()
		{
			this.Init("Yellow with a giant flower on the hood.", EngineType.FlatFour, TireType.Baja, 8.3m, 1300m);
			return this;
		}

		public CarBuilder StartWithFordGT40()
		{
			this.Init("Silver", EngineType.V8SuperCharged, TireType.Track, 3.9m, 1400m);
			return this;
		}


		public CarBuilder Init(string color, EngineType engine, TireType tires, decimal zeroTo60Time, decimal weight) 
		{
			_color = color;
			_engine = engine;
			_tires = tires;
			_zeroTo60Time = zeroTo60Time;
			_weight = weight;
		
			return this;
		}

		public CarBuilder() 
		{ 
			Init("Rust", EngineType.Inline, TireType.Flat, 35.5m, 3505m);
		}

		public RaceCar Build()
		{
			RaceCar c = new RaceCar();
			c.Color = _color;
			c.Engine = _engine;
			c.Tires = _tires;
			c.ZeroTo60Time = _zeroTo60Time;
			c.Weight = _weight;
			
			return c;
		}
	}
}
using System;

	public enum EngineType { None, TwoStrokeSingle, Inline, InlineTurbo, V8, FlatFour,
		V8SuperCharged, HybridElectric, TurboDiesel, Methahol, Radial, Rotary, TurboProp, TurboJet, Rocket };
	public enum TireType { None, PRated, YRated, ZRated, LT, AllTerrain, OffRoad, DragSlick, Baja, Mudder, Tractor,  Donut, Track, Flat } ;

	public class RaceCar
	{
		public string Color {get;set;}

		public TireType Tires {get;set;}
		public EngineType Engine {get;set;}
		public decimal ZeroTo60Time {get;set;}
		public decimal Weight {get;set;}
	}

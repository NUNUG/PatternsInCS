using System;

namespace Mediator
{
	public interface IScore
	{
		void IncrementScoreBy(int points);
		void ResetScore();
		int Points { get; set; }
	}
	public class Score: IScore
	{
		private Mediator _mediator;
		public int Points { get; set; }
		public Score(Mediator mediator)
		{
			this._mediator = mediator;
			this._mediator.RegisterScore(this);
		}

		public void IncrementScoreBy(int points)
		{
			this.Points = this.Points + points;
			Console.WriteLine($"Score is now {this.Points}.");
		}
		public void ResetScore() 
		{
			this.Points = 0;
			Console.WriteLine($"Score is now {this.Points}.");
		}
	}

	public delegate void MouseClickEventHandler();
	public interface IMouse
	{
		event MouseClickEventHandler OnClick;
		void SimulateMouseClicks();
	}
	public class Mouse: IMouse
	{
		private Mediator _mediator;
		public event MouseClickEventHandler OnClick;
		public Mouse(Mediator mediator)
		{
			this._mediator = mediator;
			this._mediator.RegisterMouse(this);
		}

		public void SimulateMouseClicks()
		{
			string s = string.Empty;
			while (!s.Equals("quit"))
			{
				Console.WriteLine("Press Enter to simulate a mouse click...");
				s = Console.ReadLine();
				var handler = this.OnClick;
				if (handler != null)
					handler();
			}
		}
	}

	public interface IShip
	{
		void Fire();
	}
	public class Ship: IShip
	{
		private Mediator _mediator;
		public Ship(Mediator mediator)
		{
			this._mediator = mediator;
			this._mediator.RegisterShip(this);
		}
		public void Fire()
		{
			Console.WriteLine("Firing photon torpedo.");
			this._mediator.PlayFireSound();
		}
	}

	public interface ISound
	{
		void PlayCollisionSound();
		void PlayFireSound();
	}

	public class Sound: ISound
	{
		private Mediator _mediator;
		public Sound(Mediator mediator)
		{
			this._mediator = mediator;
			this._mediator.RegisterSound(this);
		}
		public void PlayCollisionSound()
		{
			Console.WriteLine("Crash!");
		}
		public void PlayFireSound()
		{
			Console.WriteLine("Pew pew pew!");
		}
	}

	public interface IAsteroids
	{
		void AsteroidHit();
	}
	public class Asteroids: IAsteroids
	{
		private Mediator _mediator;
		public Asteroids(Mediator mediator)
		{
			this._mediator = mediator;
			this._mediator.RegisterAsteroids(this);
		}
		public void AsteroidHit()
		{
			this._mediator.PlayCollisionSound();
			this._mediator.AddPoints(10);
		}
	}

	public interface IScreen
	{
		void Draw(IAsteroids asteroids, IShip ship, IScore score);
	}
	public class Screen: IScreen
	{
		private Mediator _mediator;
		public Screen(Mediator mediator)
		{
			this._mediator = mediator;
			this._mediator.RegisterScreen(this);
		}
		public void Draw(IAsteroids asteroids, IShip ship, IScore score)
		{
			Console.WriteLine("Drawing screen.");
		}
	}
}
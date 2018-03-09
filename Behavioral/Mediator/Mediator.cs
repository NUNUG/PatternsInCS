using System;

namespace Mediator
{
	public class Mediator
	{
		public IScreen Screen { get; set; }
		public IShip Ship { get; set; }
		public IAsteroids Asteroids { get; set; }
		public IScore Score { get; set; }
		public ISound Sound { get; set; }
		public IMouse Mouse { get; set; }

		private Random _rnd;
		public Mediator()
		{
			this._rnd = new Random();
		}

		public void RegisterScreen(IScreen screen)
		{
			this.Screen = screen;
		}
		public void RegisterShip(IShip ship)
		{
			this.Ship = ship;
		}
		public void RegisterAsteroids(IAsteroids asteroids)
		{
			this.Asteroids = asteroids;
		}
		public void RegisterScore(IScore score)
		{
			this.Score = score;
		}
		public void RegisterSound(ISound sound)
		{
			this.Sound = sound;
		}
		public void RegisterMouse(IMouse mouse)
		{
			this.Mouse = mouse;
			this.Mouse.OnClick += new MouseClickEventHandler(MouseClicked);
		}


		public void MouseClicked()
		{
			this.Ship.Fire();
			// We have a 1 in 3 chance that the shot hit an asteroid.
			var roll = _rnd.Next(3) + 1;
			if (roll == 3)
			{
				Console.WriteLine("It's a hit!");
				this.Asteroids.AsteroidHit();
			}
			else
				Console.WriteLine("Miss!");
		}
		public void AddPoints(int points)
		{
			this.Score.IncrementScoreBy(points);
		}
		public void Draw(IAsteroids asteroids, IShip ship, IScore score)
		{
			this.Screen.Draw(this.Asteroids, this.Ship, this.Score);
		}
		public void PlayCollisionSound()
		{
			this.Sound.PlayCollisionSound();
		}
		public void PlayFireSound()
		{
			this.Sound.PlayFireSound();
		}
	}
}
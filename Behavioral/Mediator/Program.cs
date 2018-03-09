using System;

namespace Mediator
{
    class AsteroidsGame
    {
        static void Main(string[] args)
        {
            AsteroidsGame g = new AsteroidsGame();
			g.Execute();
        }

		private void Execute()
		{
			Mediator mediator = new Mediator();
			IScore score = new Score(mediator);
			IMouse mouse = new Mouse(mediator);
			IShip ship = new Ship(mediator);
			IAsteroids asteroids = new Asteroids(mediator);
			ISound sound = new Sound(mediator);
			IScreen screen = new Screen(mediator);

			Console.WriteLine("Type 'quit' to end.");
			mouse.SimulateMouseClicks();
		}
	}
}

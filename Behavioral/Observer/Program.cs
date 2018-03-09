using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Execute();
        }

        private void Execute()
        {
            Observer o = new Observer();
            Score score = new Score(o);
            Asteroids asteroids = new Asteroids(o);
            Mouse mouse = new Mouse(o);
            Ship ship = new Ship(o);
            Sound sound = new Sound(o);

            mouse.Begin();

        }
    }
}

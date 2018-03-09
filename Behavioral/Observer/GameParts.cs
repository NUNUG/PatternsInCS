using System;

namespace Observer
{
    public class Score
    {
        private Observer _observer;
        public int Points { get; set; }
        public Score(Observer observer)
        {
            this._observer = observer;
            this._observer.AddListener("AddPointsToScore", new Listener(this, 
                (obs, sender, eventName, payload) => 
                {
                    this.AddPoints((int)payload);
                }));
            

            this.Points = 0;
        }

        public void AddPoints(int points)
        {
            this.Points = this.Points + points;
            Console.WriteLine($"Score is now {this.Points} points.");
        }
    }

    public class Asteroids
    {
        private Observer _observer;
        public Asteroids(Observer observer)
        {
            this._observer = observer;
            this._observer.AddListener("AsteroidIsHit", new Listener(this, 
                (obs, sender, eventName, payload) => 
                {
                    this.AsteroidIsHit();
                }));
        }

        public void AsteroidIsHit()
        {
            _observer.Trigger(this, "PlayCrashSound", null);
            Console.WriteLine("Aseroid has been hit.");
            _observer.Trigger(this, "AddPointsToScore", 10);
        }
    }

    public class Mouse
    {
        private Observer _observer;
        public Mouse(Observer observer)
        {
            this._observer = observer;
        }

        public void Begin()
        {
            Console.WriteLine("Press ENTER to simulate a mouse click.  Type 'quit' when done.");
            string s = Console.ReadLine();
            while (!s.Equals("quit"))
            {
                this._observer.Trigger(this, "Fire", null);
                s = Console.ReadLine();
            }
        }
    }

    public class Ship
    {
        private Observer _observer;
        private Random _rnd;

        public Ship(Observer observer)
        {
            this._observer = observer;
            this._observer.AddListener("Fire", new Listener(this, 
                (obs, sender, eventName, payload) => 
                {
                    this.Fire();
                }));

            this._rnd = new Random();
        }

        public void Fire()
        {
            _observer.Trigger(this, "PlayBangSound", null);
            // We have a one in 3 chance to hit an asteroid.
            var roll = this._rnd.Next(1, 4);
            if (roll == 3)
            {
                _observer.Trigger(this, "AsteroidIsHit", null);
            }
            else
            {
                Console.WriteLine("It's a miss :(");                
            }
        }
    }

    public class Sound
    {
        private Observer _observer;
        public Sound(Observer observer)
        {
            this._observer = observer;
            this._observer.AddListener("PlayBangSound", new Listener(this, 
                (obs, sender, eventName, payload) => 
                {
                    this.PlayBang();
                }));
            this._observer.AddListener("PlayCrashSound", new Listener(this, 
                (obs, sender, eventName, payload) => 
                {
                    this.PlayCrash();
                }));
        }

        public void PlayCrash()
        {
            Console.WriteLine("Crash!");
        }
        public void PlayBang()
        {
            Console.WriteLine("Bang!");
        }
    }
}
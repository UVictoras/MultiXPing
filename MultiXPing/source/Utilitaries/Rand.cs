using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    public sealed class Rand
    {

        private Random _random = new Random();
        private static Rand Instance { get; set; }//Singleton
        public Random Random { get => _random; set => _random = value; }

        private Rand() { }

        public static Rand GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Rand();
            }
            return Instance;

        }

        public int Randint(int value)
        {
            return Random.Next(value);
        }
    }

}

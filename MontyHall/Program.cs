using System;

namespace MontyHall
{
    class MontyHallDoors
    {
        private bool Door1;
        private bool Door2;
        private bool Door3;

        public bool this[int index]
        {
            set
            {
                switch (index)
                {
                    case 0: Door1 = value;
                        break;
                    case 1: Door2 = value;
                        break;
                    case 2: Door3 = value;
                        break;

                    default: throw new ArgumentOutOfRangeException("index");
                }
            }

            get
            {
                switch (index)
                {
                    case 0: return Door1;
                    case 1: return Door2;
                    case 2: return Door3;

                    default: throw new ArgumentOutOfRangeException("index");
                }       
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MontyHallDoors MontyHallGame = new MontyHallDoors();

            Random rnd = new Random();

            MontyHallGame[0] = (rnd.Next(2) == 0) ? false : true;
            if (!MontyHallGame[0])
            {
                MontyHallGame[1] = (rnd.Next(2) == 0) ? false : true;
                if (!MontyHallGame[1])
                {
                    MontyHallGame[2] = true;
                }
            }

            Console.WriteLine("{0}, {1}, {2}", MontyHallGame[0], MontyHallGame[1], MontyHallGame[2]);

        }
    }
}

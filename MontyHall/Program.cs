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
            int playerWon = 0;
            int playerLost = 0;
            Random rnd = new Random();

            for (int i = 0; i < 1000000; i++)
            {

                MontyHallDoors MontyHallGame = new MontyHallDoors();


                MontyHallGame[0] = (rnd.Next(2) == 0) ? false : true;
                if (!MontyHallGame[0])
                {
                    MontyHallGame[1] = (rnd.Next(2) == 0) ? false : true;
                    if (!MontyHallGame[1])
                    {
                        MontyHallGame[2] = true;
                    }
                }

                //Console.WriteLine("{0}, {1}, {2}", MontyHallGame[0], MontyHallGame[1], MontyHallGame[2]);


                int playerChoice = rnd.Next(3);


                if (MontyHallGame[playerChoice])
                {
                    playerWon++;
                    //Console.WriteLine("You won!");
                }
                else
                {
                    playerLost++;
                    //Console.WriteLine("You lost!");
                }
            }

            Console.WriteLine("Times won: {0}\nTimes lost: {1}", playerWon, playerLost);

        }
    }
}

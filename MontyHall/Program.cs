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
        const int numberOfGames = 1000000;

        static void Main(string[] args)
        {
            int playerWon = 0;          // number of times player has won
            int playerLost = 0;         // number of times player has lost
            Random rnd = new Random();  // single Random object to generate all random numbers as per MSDN

            for (int i = 0; i < numberOfGames; i++)
            {

                MontyHallDoors MontyHallGame = new MontyHallDoors();


                MontyHallGame[0] = (rnd.Next(2) == 0) ? false : true;       // set door #1 randomly
                if (!MontyHallGame[0])                                      // if the prize is not behind door #1
                {
                    MontyHallGame[1] = (rnd.Next(2) == 0) ? false : true;   // set door #2 randomly 
                    if (!MontyHallGame[1])                                  // if the prize is not behind door #2
                    {
                        MontyHallGame[2] = true;                            // then it is surely behind door #3
                    }
                }

                //Console.WriteLine("{0}, {1}, {2}", MontyHallGame[0], MontyHallGame[1], MontyHallGame[2]);


                int playerChoice = rnd.Next(3);                             // player picks a random door

                int montyIntervention = rnd.Next(3);                        // Monty picks his door              
                while ((montyIntervention == playerChoice) || (MontyHallGame[montyIntervention]))
                {
                    montyIntervention = rnd.Next(3);
                }
                
                int newPlayerChoice = rnd.Next(3);                          // player SHOULD change his mind
                while ((newPlayerChoice == playerChoice) || (newPlayerChoice == montyIntervention))
                {
                    newPlayerChoice = rnd.Next(3);
                }

                if (MontyHallGame[newPlayerChoice])
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

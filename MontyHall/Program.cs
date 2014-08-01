using System;
using System.Collections.Generic;

namespace MontyHall
{
    class MontyHallGame
    {
        private enum Prize {Car, Donkey};

        private Random rnd = new Random();

        public bool Play(bool swap)
        {
            // TODO: It would be better to fill doors at random
            // TODO: Choose number of doors?
            List<Prize> doors = new List<Prize> {Prize.Car, Prize.Donkey, Prize.Donkey};

            // Player picks a random door
            int playerChoice = rnd.Next(doors.Count);
            Prize playerPrize = doors[playerChoice];
            doors.RemoveAt(playerChoice);

            // Monty opens a door with a donkey
            // TODO: if there are two donkeys left, Monty's choice MUST be random?
            doors.Remove(Prize.Donkey);

            if (swap)
            {
                // If the player decided to switch doors, he has only one door left
                // The only element in a list is at index 0
                playerPrize = doors[0];
            }

            // Let's see if the player won
            return (playerPrize == Prize.Car);
        }
    }

    class Program
    {
        private void RunSimulation(int numberOfTimes, bool swap)
        {
            int playerWon = 0;          // number of times player has won
            int playerLost = 0;         // number of times player has lost

            MontyHallGame game = new MontyHallGame();

            for(int i = 0; i < numberOfTimes; i++)
            {
                if (game.Play(swap))
                {
                    playerWon++;
                }
                else
                {
                    playerLost++;
                }
            }

            Console.WriteLine("Results for {0}switching doors:", swap ? "" : "not ");
            Console.WriteLine("Times won: {0}, times lost: {1}\n", playerWon, playerLost);
        }

        static void Main(string[] args)
        {
            // Number of simulations
            const int numberOfGames = 1000000;

            Program p = new Program();

            // Run simulations with switching
            p.RunSimulation(numberOfGames, true);

            // Run simulations without switching
            p.RunSimulation(numberOfGames, false);
        }
    }
}

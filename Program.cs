using CardGame.Classes;

namespace CardGame
{
    class Program
    {
        static void Main()
        {
            int totalTurnCount = 0, finiteGameCount = 0;

            for (int i = 0; i < 1; i++)
            {
                //Create game
                ActualGame game = new("Jack", "Joe");

                while (!game.IsEndOfGame())
                {
                    game.PlayTurn();

                    if (game.TurnCount < 20)
                    {
                        totalTurnCount += game.TurnCount;
                        finiteGameCount++;
                    }
                }
            }

            double avgTurn = (double)totalTurnCount / (double)finiteGameCount;

            Console.WriteLine(finiteGameCount + " finite games with an average of " + Math.Round(avgTurn, 2) + " turns per game.");

            Console.Read();
        }
    }
}
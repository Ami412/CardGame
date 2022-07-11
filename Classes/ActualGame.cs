namespace CardGame.Classes
{
    public class ActualGame
    {
        private Player Player1;
        private Player Player2;
        public int TurnCount;
        public ActualGame(string player1name, string player2name)
        {
            Player1 = new Player(player1name);
            Player2 = new Player(player2name);

            //Returns a shuffled set of cards
            var cards = Decker.CreateCards();

            //Returns Player2's deck.  Player1 has his deck already.
            var deck = Player1.Deal(cards); 
            Player2.Deck = deck;
        }

        public bool IsEndOfGame()
        {
            if (!Player1.Deck.Any())
            {
                Console.WriteLine(Player1.Name + " is out of cards!  " + Player2.Name + " WINS!");
                Console.WriteLine("TURNS: " + TurnCount.ToString());
                return true;
            }
            else if (!Player2.Deck.Any())
            {
                Console.WriteLine(Player2.Name + " is out of cards!  " + Player1.Name + " WINS!");
                Console.WriteLine("TURNS: " + TurnCount.ToString());
                return true;
            }
            else if (TurnCount > 20)
            {
                Console.WriteLine("Infinite game!  Let's call the whole thing off.");
                return true;
            }
            return false;
        }

        public void PlayTurn()
        {
            Queue<Card> pool = new();

            var player1card = Player1.Deck.Dequeue();
            var player2card = Player2.Deck.Dequeue();

            pool.Enqueue(player1card);
            pool.Enqueue(player2card);

            Console.WriteLine(Player1.Name + " has " + player1card.ShortName + ", " + Player2.Name + " has " + player2card.ShortName);

            while (player1card.Value == player2card.Value)
            {
                Console.WriteLine("Let's play WAR!");

                if (Player1.Deck.Count < 4)
                {
                    Player1.Deck.Clear();
                    return;
                }
                if (Player2.Deck.Count < 4)
                {
                    Player2.Deck.Clear();
                    return;
                }

                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());

                player1card = Player1.Deck.Dequeue();
                player2card = Player2.Deck.Dequeue();

                pool.Enqueue(player1card);
                pool.Enqueue(player2card);

                Console.WriteLine(Player1.Name + " has " + player1card.ShortName + ", " + Player2.Name + " has " + player2card.ShortName);
            }

            if (player1card.Value < player2card.Value)
            {
                Player2.Deck.Enqueue(pool);
                Console.WriteLine(Player2.Name + " takes the hand!");
            }
            else
            {
                Player1.Deck.Enqueue(pool);
                Console.WriteLine(Player1.Name + " takes the hand!");
            }

            TurnCount++;
        }
    }
}

namespace CardGame.Classes
{
    public static class Decker
    {
        public static Queue<Card> CreateCards()
        {
            Queue<Card> cards = new Queue<Card>();
            for (int i = 2; i <= 14; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Enqueue(new Card()
                    {
                        Suit = suit,
                        Value = i,
                        ShortName = GetShortName(i, suit)
                    });
                }
            }
            return Shuffle(cards);
        }

        private static Queue<Card> Shuffle(Queue<Card> cards)
        {
            //Shuffle the existing cards using Fisher-Yates Modern
            List<Card> transformedCards = cards.ToList();
            Random r = new(DateTime.Now.Millisecond);
            for (int n = transformedCards.Count - 1; n > 0; --n)
            {
                //Step 2: Randomly pick a card which has not been shuffled
                int k = r.Next(n + 1);

                //Step 3: Swap the selected item with the last "unselected" card in the collection
                Card temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            Queue<Card> shuffledCards = new();

            foreach (var card in transformedCards)
            {
                shuffledCards.Enqueue(card);
            }

            return shuffledCards;
        }

        private static string GetShortName(int value, Suit suit)
        {
            string valueDisplay = value switch
            {
                11 => "J",
                12 => "Q",
                13 => "K",
                14 => "A",
                _ => value.ToString(),
            };
            return valueDisplay + Enum.GetName(typeof(Suit), suit)[0];
        }
    }
}

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
            return ShuffleCards(cards);
        }

        private static Queue<Card> ShuffleCards(Queue<Card> cards)
        {
            List<Card> listOfCards = cards.ToList();
            Random r = new(DateTime.Now.Millisecond);

            for (int i = listOfCards.Count - 1; i > 0; --i)
            {
                int k = r.Next(i + 1);

                Card temp = listOfCards[i];
                listOfCards[i] = listOfCards[k];
                listOfCards[k] = temp;
            }

            Queue<Card> shuffledCards = new();

            foreach (var card in listOfCards)
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

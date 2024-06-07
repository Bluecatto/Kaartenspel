using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaartenspel;

namespace Kaartenspel.classes
{
    public class Deck
    {
        //Making a list of the cards in the Card class and making a random deck in the Deck class.
        private List<Card> cards;
        private Random random;

        public Deck()
        {
            //Makes a new list of the cards and makes a random.
            cards = new List<Card>();
            random = new Random();
            InitializeDeck();
            Shuffle();
        }

        private void InitializeDeck()
        {
            //Gets elements from the Card class and puts them in System.type
            foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
            {
                for (int value = 1; value <= 13; value++)
                {
                    cards.Add(new Card(suit, value));
                }
            }
        }

        public void Shuffle()
        {
            //The cards get shuffled and goes into a random order
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        //Draws a card
        public Card DrawCard()
        {
            if (cards.Count == 0) return null;

            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        //Goes back to the remaining cards
        public int RemainingCards()
        {
            return cards.Count;
        }
    }
}
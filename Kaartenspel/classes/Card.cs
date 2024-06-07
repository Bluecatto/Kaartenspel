using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaartenspel;

namespace Kaartenspel.classes
{
    public class Card
    {
        //Card suits, all the shapes in a enum type.
        public enum Suit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        //Making a suit of the cards and a value.
        public Suit CardSuit { get; private set; }
        public int Value { get; private set; }

        //Making a card with the suit and values in it.
        public Card(Suit suit, int value)
        {
            CardSuit = suit;
            Value = value;
        }

        //Making an array of the cards and putting them in the value.
        public override string ToString()
        {
            string[] valueStrings = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            return $"{valueStrings[Value - 1]} of {CardSuit}";
        }
    }
}
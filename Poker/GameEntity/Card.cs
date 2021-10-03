using System;

namespace Poker.GameEntity
{
    public class Card
    {

        private int value;
        private Face face;
        private Suit symbol;
        
        public Card(string cardInfo)
        {
            AssignFace(cardInfo[0]);
            AssignSymbol(cardInfo[1]);
            HandleJoker();
        }
        public Suit GetCardSymbol()
        {
            return symbol;
        }
        public int GetCardValue()
        {
            return value;
        }
        
        private void AssignFace(char face)
        {
            this.face = (Face)face;
            AssignValue();
        }

        private void AssignValue()
        {
            //todo: Might change for enumExtension
            value = face.GetHashCode() - '0';
            if (face == Face.One)
            {
                value = 1;
            } else if (face == Face.Ten)
            {
                value = 10;
            } else if (face == Face.Jack)
            {
                value = 11;
            } else if (face == Face.Queen)
            {
                value = 12;
            } else if (face == Face.King)
            {
                value = 13;
            }
        }
        private void AssignSymbol(char cardSymbol)
        {
            symbol = (Suit)cardSymbol;
        }
        private void HandleJoker()
        {
            if (symbol == Suit.Joker)
                value = Face.Joker.GetHashCode() - '0';
        }
        
    }
}
using System;

namespace Poker.GameEntity
{
    public class Card
    {

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
            return face.GetHashCode();
        }
        
        private void AssignFace(char face)
        {
            Enum.TryParse(face.ToString(), out this.face);
        }
        private void AssignSymbol(char cardSymbol)
        {
            symbol = (Suit)cardSymbol;
        }
        private void HandleJoker()
        {
            if (symbol == Suit.Joker)
                face = Face.Joker;
        }
        
    }
}
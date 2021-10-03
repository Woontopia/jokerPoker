using System;

namespace Poker.GameEntity
{
    public class Card
    {

        private int value;
        private Suit symbol;
        
        public Card(string cardInfo)
        {
            AssignValue(cardInfo[0]);
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
        
        private void AssignValue(char value)
        {
            //todo: change to a better way
            if (value == 'A')
            {
                this.value = 1;
            } else if (value == 'T')
            {
                this.value = 10;
            } else if (value == 'J')
            {
                this.value = 11;
            } else if (value == 'Q')
            {
                this.value = 12;
            } else if (value == 'K')
            {
                this.value = 13;
            }
            else
            {
                this.value = value - '0';
            }
            
        }
        private void AssignSymbol(char cardSymbol)
        {
            symbol = (Suit)cardSymbol;
        }
        private void HandleJoker()
        {
            //todo: might need to change
            if (symbol == Suit.Joker)
                value = 16;
        }
        
    }
}
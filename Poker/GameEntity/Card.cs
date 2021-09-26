using System;

namespace Poker.GameEntity
{
    public class Card
    {

        private int value;
        private CardSymbol symbol;
        
        public Card(string cardInfo)
        {
            AssignValue(cardInfo[0]);
            AssignSymbol(cardInfo[1]);
            HandleJoker();
        }

        public void PrintCard()
        {
            Console.WriteLine(value);
            Console.WriteLine(symbol);
            Console.WriteLine("-------");
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
                this.value = 10;
            } else if (value == 'Q')
            {
                this.value = 10;
            } else if (value == 'K')
            {
                this.value = 10;
            }
            else
            {
                this.value = value - '0';
            }
            
        }
        private void AssignSymbol(char cardSymbol)
        {
            symbol = (CardSymbol)cardSymbol;
        }
        private void HandleJoker()
        {
            //todo: might need to change
            if (symbol == CardSymbol.Joker)
                value = 0;
        }
        
    }
}
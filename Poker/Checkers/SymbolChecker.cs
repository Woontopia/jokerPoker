using System;
using System.Collections.Generic;
using System.Linq;
using Poker.GameEntity;

namespace Poker.Checkers
{
    public class SymbolChecker
    {
        public bool ContainsSameSymbolCards(IEnumerable<Card> cards, int numberOfTimes)
        {
            return GetCardsOfMostFrequentSymbol(cards).Count() >= numberOfTimes;
        }
        
        private IEnumerable<Card> GetCardsOfSameSymbol(IEnumerable<Card> cards, Suit symbol)
        {
            return cards.Select(card => card).Where(x => x.GetCardSymbol() == symbol);
        }

        private IEnumerable<Card> GetCardsOfMostFrequentSymbol(IEnumerable<Card> cards)
        {
            var highestFrequency = 0;
            var cardSymbol = Suit.Club;
            foreach (var symbol in Enum.GetValues(typeof(Suit)))
            {
                var list = GetCardsOfSameSymbol(cards, (Suit)symbol);
                if (highestFrequency < list.Count())
                {
                    highestFrequency = list.Count();
                    cardSymbol = (Suit)symbol;
                }
            }
            return GetCardsOfSameSymbol(cards, cardSymbol);
        }
    }
}
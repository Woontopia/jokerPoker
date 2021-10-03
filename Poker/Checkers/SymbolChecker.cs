using System;
using System.Collections.Generic;
using System.Linq;
using Poker.GameEntity;

namespace Poker.Checkers
{
    public class SymbolChecker
    {
        public bool ContainsXNumberOfSameSymbol(IEnumerable<Card> cards, int numberOfTimes)
        {
            return GetCardsOfMostFrequentSymbol(cards).Count() >= numberOfTimes - CountJokers(cards);
        }
        
        private IEnumerable<Card> GetCardsOfSameSymbol(IEnumerable<Card> cards, Suit symbol)
        {
            return cards.Select(card => card).Where(x => x.GetCardSymbol() == symbol);
        }

        private IEnumerable<Card> GetCardsOfMostFrequentSymbol(IEnumerable<Card> cards)
        {
            //todo: check to do with group by then order by
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

        private int CountJokers(IEnumerable<Card> cards)
        {
            return GetCardsOfSameSymbol(cards, Suit.Joker).Count();
        }
    }
}
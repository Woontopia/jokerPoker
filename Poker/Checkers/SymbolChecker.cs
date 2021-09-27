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
            return GetCardsOfMostFrequentSymbol(cards).Count() >= numberOfTimes;
        }
        
        private IEnumerable<Card> GetCardsOfSameSymbol(IEnumerable<Card> cards, CardSymbol symbol)
        {
            return cards.Select(card => card).Where(x => x.GetCardSymbol() == symbol);
        }

        private IEnumerable<Card> GetCardsOfMostFrequentSymbol(IEnumerable<Card> cards)
        {
            //todo: check to do with group by then order by
            var highestFrequency = 0;
            var cardSymbol = CardSymbol.Club;
            foreach (var symbol in Enum.GetValues(typeof(CardSymbol)))
            {
                var list = GetCardsOfSameSymbol(cards, (CardSymbol)symbol);
                if (highestFrequency < list.Count())
                {
                    highestFrequency = list.Count();
                    cardSymbol = (CardSymbol)symbol;
                }
            }
            return GetCardsOfSameSymbol(cards, cardSymbol);
        }
    }
}
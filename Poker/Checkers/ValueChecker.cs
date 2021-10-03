using System;
using System.Collections.Generic;
using System.Linq;
using Poker.GameEntity;

namespace Poker.Checkers
{
    public class ValueChecker
    {
        public bool ContainsSameValueCardXTimes(IEnumerable<Card> cards, int numberOfTimes)
        {
            var numberOfJokers = CountJokers(cards);
            var cardValues = cards.Select(card => card.GetCardValue());
            foreach (var value in cardValues.Distinct())
            {
                if (cardValues.Count(x => x == value) == numberOfTimes)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsSeriesOfCards(IEnumerable<Card> cards, IEnumerable<int> values)
        {
            var cardValues = cards.Select(card => card.GetCardValue());
            return cardValues.Intersect(values).Count() == cards.Count() - CountJokers(cards);
        }

        public bool ContainsPairs(IEnumerable<Card> cards, int numberOfPairs)
        {
            var cardValues = cards.Select(card => card.GetCardValue()).Distinct();
            return cardValues.Count() + numberOfPairs == 5;
        }
        
        private int CountJokers(IEnumerable<Card> cards)
        {
            return cards.Select(card => card.GetCardSymbol()).Count(x => x == Suit.Joker);
        }
    }
}
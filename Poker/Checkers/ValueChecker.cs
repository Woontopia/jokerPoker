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
            // var orderedCards = cards.GroupBy(card => card.GetCardSymbol()).SelectMany(card => card);
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
            return cardValues.Intersect(values).Count() == cards.Count();
        }
    }
}
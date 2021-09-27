using System;
using System.Collections.Generic;
using System.Linq;
using Poker.GameEntity;

namespace Poker.Checkers
{
    public class ValueChecker
    {
        public bool sameValueCard()
        {
            // var orderedCards = cards.GroupBy(card => card.GetCardSymbol()).SelectMany(card => card);
            throw new NotImplementedException();
        }

        public bool ContainsSeriesOfCards(IEnumerable<Card> cards, IEnumerable<int> values)
        {
            var cardValues = cards.Select(card => card.GetCardValue());
            return cardValues.Intersect(values).Count() == cards.Count();
        }
    }
}
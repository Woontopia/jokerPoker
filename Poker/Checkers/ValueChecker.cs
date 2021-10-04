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

        public bool ContainsSeriesOfCards(IEnumerable<Card> cards, IEnumerable<int> values, int cardsRemaining)
        {
            var cardValues = cards.Select(card => card.GetCardValue());
            return cardValues.Intersect(values).Count() == cardsRemaining;
        }

        public bool ContainsPairs(IEnumerable<Card> cards, int numberOfPairs)
        {
            // todo: change so it doesnt take a pair of jokers as a pair;
            var cardValues = cards.Select(card => card.GetCardValue()).Distinct();
            return cardValues.Count() + numberOfPairs == 5;
        }
    }
}
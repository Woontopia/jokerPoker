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
            var cardValues = cards.Select(card => card.GetCardValue()).Distinct();
            return cardValues.Count() + numberOfPairs == 5;
        }

        public bool ContainsDistinctCards(IEnumerable<Card> cards, int numberOfCards)
        {
            // Gets all the card values then removes the cards that are jokers
            return cards.Select(card => card.GetCardValue()).Where(value => value != Face.Joker.GetHashCode()).Distinct().Count() == numberOfCards;
        }
    }
}
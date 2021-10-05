using System;
using System.Collections.Generic;
using System.Linq;
using Poker.GameEntity;

namespace Poker.Checkers
{
    public class StraightChecker
    {
        public bool ContainsStraight(IEnumerable<Card> cards, int straightLength)
        {
            var cardValues = cards.Select(card => card.GetCardValue()).Where(value => value != Face.Joker.GetHashCode()).OrderBy(x => x).ToList();
            if (cardValues.Contains(1) && cardValues.Max() == 13)
            {
                cardValues.Add(14);
                cardValues.Remove(1);
            }
            var noGapList = Enumerable.Range(cardValues.Min(), cardValues.Max() - cardValues.Min() + 1);
            var missingValues = noGapList.Except(cardValues).Select(x => x);
            return missingValues.Count() == cards.Count() - straightLength;
        }

        public bool Hi(IEnumerable<Card> cards, int straightLength)
        {
            var nbJoker = cards.Select(card => card.GetCardSymbol()).Count(x => x == Suit.Joker);
            var cardValues = cards.Select(card => card.GetCardValue()).Where(value => value != Face.Joker.GetHashCode()).OrderBy(x => x).ToList();
            if (cardValues.Contains(1) && cardValues.Max() == 13)
            {
                cardValues.Add(14);
                cardValues.Remove(1);
            }
            Console.WriteLine(cardValues.Max());
            Console.WriteLine(cardValues.Min());
            return cardValues.Max() - cardValues.Min() == straightLength;
        }
    }
}
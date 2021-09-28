using System;
using System.Collections.Generic;
using System.Linq;
using Poker.GameEntity;

namespace Poker.Checkers
{
    public class StraightChecker
    {
        public bool ContainsStraight(IEnumerable<Card> cards, int numberOfCards)
        {
            var cardValues = cards.Select(card => card.GetCardValue()).OrderBy(x => x).ToList();
            var count = 0;
            for (int i = 1; i < cardValues.Count(); i++)
            {
                if (cardValues[i] - 1 == cardValues[i - 1])
                {
                    count++;
                }
            }
            // Console.WriteLine(count);
            return count >= numberOfCards;
        }
    }
}
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
            if(cardValues.Contains(1))
                cardValues.Add(14);

            int count = 1;
            int maxCount = 0;
            for (int i = 0; i < cardValues.Count(); i++)
            {
                if (i + 1 < cardValues.Count())
                {
                    count = (cardValues[i] + 1 == cardValues[i + 1]) ? count + 1 : 0;
                    if (count == numberOfCards)
                        return true;
                }
            }

            return false;
        }
    }
}
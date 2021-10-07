using System.Collections.Generic;
using System.Linq;
using Poker.GameEntity;

namespace Poker.Checkers
{
    public class StraightChecker
    {
        public bool ContainsStraight(IEnumerable<Card> cards, int straightLength)
        {
            var missingValues = GetMissingValues(cards);
            return missingValues.Count() == cards.Count() - straightLength;
        }

        public bool ContainsStraightWithJoker(IEnumerable<Card> cards)
        {
            var nbJoker = cards.Select(card => card.GetCardSymbol()).Count(x => x == Suit.Joker);
            var missingValues = GetMissingValues(cards);
            if (missingValues.Count() == nbJoker || missingValues.Count() + 1 == nbJoker)
                return true;

            return false;
        }

        private IEnumerable<int> GetMissingValues(IEnumerable<Card> cards)
        {
            var cardValues = cards.Select(card => card.GetCardValue()).Where(value => value != Face.Joker.GetHashCode()).OrderBy(x => x).ToList();
            if (cardValues.Contains(1) && cardValues.Max() == 13)
            {
                cardValues.Add(14);
                cardValues.Remove(1);
            }
            var noGapList = Enumerable.Range(cardValues.Min(), cardValues.Max() - cardValues.Min() + 1);
            return noGapList.Except(cardValues).Select(x => x);
        }
    }
}
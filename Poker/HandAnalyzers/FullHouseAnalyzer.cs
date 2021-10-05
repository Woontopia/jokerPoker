using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class FullHouseAnalyzer : Analyzer
    {
        private ValueChecker _valueChecker;
        public FullHouseAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _valueChecker = new ValueChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (BaseCondition(cards) || JokerCondition(cards))
                return Hand.FullHouse;
            
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            return _valueChecker.ContainsSameValueCard(cards, 3) &&
                   _valueChecker.ContainsSameValueCard(cards, 2);
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            // Can only contain one Joker, FullHouse with 2 jokers is impossible
            return CountJokers(cards) == 1 && _valueChecker.ContainsPairs(cards, 2);
        }
    }
}
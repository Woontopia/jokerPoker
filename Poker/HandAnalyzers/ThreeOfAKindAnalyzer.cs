using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class ThreeOfAKindAnalyzer : Analyzer
    {
        private ValueChecker _valueChecker;
        public ThreeOfAKindAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _valueChecker = new ValueChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (_valueChecker.ContainsSameValueCardXTimes(cards, 3))
                return Hand.ThreeOfAKind;
            
            return nextAnalyzer.AnalyzeHand(cards);
        }
    }
}
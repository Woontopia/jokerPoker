using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class FourOfAKindAnalyzer : Analyzer
    {
        private ValueChecker _valueChecker;
        public FourOfAKindAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _valueChecker = new ValueChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (_valueChecker.ContainsSameValueCardXTimes(cards, 4))
                return Hand.FourOfAKind;
                
            return nextAnalyzer.AnalyzeHand(cards);
        }
    }
}
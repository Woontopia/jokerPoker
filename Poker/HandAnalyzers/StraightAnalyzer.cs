using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class StraightAnalyzer : Analyzer
    {
        private StraightChecker _straightChecker;
        public StraightAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _straightChecker = new StraightChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (_straightChecker.ContainsStraight(cards, 5))
                return Hand.Straight;
                
            return nextAnalyzer.AnalyzeHand(cards);
        }
    }
}
using System.Collections.Generic;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class StraightAnalyzer : Analyzer
    {
        public StraightAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            return nextAnalyzer.AnalyzeHand(cards);
        }
    }
}
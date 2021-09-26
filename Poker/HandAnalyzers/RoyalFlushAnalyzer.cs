using System.Collections.Generic;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class RoyalFlushAnalyzer : Analyzer
    {
        public RoyalFlushAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            return nextAnalyzer.AnalyzeHand(cards);
        }
    }
}
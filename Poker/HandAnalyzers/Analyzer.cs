using System.Collections.Generic;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public abstract class Analyzer
    {
        public Analyzer nextAnalyzer;

        public Analyzer(Analyzer next)
        {
            nextAnalyzer = next;
        }

        public abstract Hand AnalyzeHand(IEnumerable<Card> cards);
    }
}
using System.Collections.Generic;
using System.Linq;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class FlushAnalyzer : Analyzer
    {
        private SymbolChecker _symbolChecker;
        public FlushAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _symbolChecker = new SymbolChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (_symbolChecker.ContainsXNumberOfSameSymbol(cards, 5))
                return Hand.Flush;
            
            return nextAnalyzer.AnalyzeHand(cards);
        }
    }
}
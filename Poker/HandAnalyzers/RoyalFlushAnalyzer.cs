using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class RoyalFlushAnalyzer : Analyzer
    {
        private SymbolChecker _symbolChecker;
        private ValueChecker _valueChecker;
        public RoyalFlushAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _symbolChecker = new SymbolChecker();
            _valueChecker = new ValueChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (_symbolChecker.ContainsXNumberOfSameSymbol(cards, 5) &&
                _valueChecker.ContainsSeriesOfCards(cards, new int[] { 1, 10, 11, 12, 13 }))
            {
                return Hand.RoyalFlush;
            }
            return nextAnalyzer.AnalyzeHand(cards);
        }

    }
}
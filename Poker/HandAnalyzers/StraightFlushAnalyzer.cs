using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class StraightFlushAnalyzer : Analyzer
    {
        private StraightChecker _straightChecker;
        private SymbolChecker _symbolChecker;
        public StraightFlushAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _straightChecker = new StraightChecker();
            _symbolChecker = new SymbolChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (_straightChecker.ContainsStraight(cards, 5) && _symbolChecker.ContainsXNumberOfSameSymbol(cards, 5))
                return Hand.StraightFlush;
            
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            throw new System.NotImplementedException();
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            throw new System.NotImplementedException();
        }
    }
}
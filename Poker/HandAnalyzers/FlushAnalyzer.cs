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
            if (BaseCondition(cards) || JokerCondition(cards))
                return Hand.Flush;
            
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            return _symbolChecker.ContainsSameSymbolCards(cards, 5);
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            return _symbolChecker.ContainsSameSymbolCards(cards, 5 - CountJokers(cards));
        }
    }
}
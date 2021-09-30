using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class OnePairAnalyzer : Analyzer
    {
        private readonly ValueChecker _valueChecker;
        public OnePairAnalyzer(Analyzer next) : base(next)
        {
            
            nextAnalyzer = next;
            _valueChecker = new ValueChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (_valueChecker.ContainsPairs(cards, 1))
                return Hand.Pair;
                
            return nextAnalyzer.AnalyzeHand(cards);
        }
    }
}
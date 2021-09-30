using System.Collections.Generic;
using System.Linq;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class TwoPairAnalyzer : Analyzer
    {
        private readonly ValueChecker _valueChecker;
        public TwoPairAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _valueChecker = new ValueChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (_valueChecker.ContainsPairs(cards, 2))
                return Hand.TwoPair;
                
            return nextAnalyzer.AnalyzeHand(cards);
        }
    }
}
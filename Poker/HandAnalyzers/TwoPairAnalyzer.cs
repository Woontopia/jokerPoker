using System.Collections.Generic;
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
            if (BaseCondition(cards) || JokerCondition(cards))
                return Hand.TwoPair;
                
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            return _valueChecker.ContainsPairs(cards, 2);
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            // Base Condition for 2 Jokers
            return CountJokers(cards) == 2;
        }
    }
}
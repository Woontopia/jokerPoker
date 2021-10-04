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
            if (BaseCondition(cards) || JokerCondition(cards))
                return Hand.Pair;
                
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            return _valueChecker.ContainsPairs(cards, 1);
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            // Base Condition for One Joker
            return CountJokers(cards) == 1;
        }
    }
}
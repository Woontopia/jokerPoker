using System;
using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class FourOfAKindAnalyzer : Analyzer
    {
        private ValueChecker _valueChecker;
        private int numberOfJokers;
        public FourOfAKindAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _valueChecker = new ValueChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            numberOfJokers = CountJokers(cards);
            if (BaseCondition(cards) || JokerCondition(cards))
                return Hand.FourOfAKind;
                
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            return _valueChecker.ContainsSameValueCardXTimes(cards, 4);
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            return OneJokerCondition(cards) || TwoJokerCondition(cards);
        }
        
        private bool OneJokerCondition(IEnumerable<Card> cards)
        {
            return numberOfJokers == 1 && _valueChecker.ContainsSameValueCardXTimes(cards, 3);
        }

        private bool TwoJokerCondition(IEnumerable<Card> cards)
        {
            return numberOfJokers == 2 && (_valueChecker.ContainsPairs(cards, 1) ||
                                           _valueChecker.ContainsSameValueCardXTimes(cards, 3));
        }
    }
}
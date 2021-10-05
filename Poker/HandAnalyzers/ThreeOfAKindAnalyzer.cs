using System;
using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class ThreeOfAKindAnalyzer : Analyzer
    {
        private ValueChecker _valueChecker;
        private int numberOfJokers;
        
        public ThreeOfAKindAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _valueChecker = new ValueChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (BaseCondition(cards) || JokerCondition(cards))
                return Hand.ThreeOfAKind;
            
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            return _valueChecker.ContainsSameValueCardXTimes(cards, 3);
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            numberOfJokers = CountJokers(cards);
            return OneJokerCondition(cards) || TwoJokerCondition(cards);
        }

        private bool OneJokerCondition(IEnumerable<Card> cards)
        {
            return numberOfJokers == 1 && _valueChecker.ContainsPairs(cards, 1);
        }

        private bool TwoJokerCondition(IEnumerable<Card> cards)
        {
            return numberOfJokers == 2 && _valueChecker.ContainsDistinctCards(cards, 3);
        }
    }
}
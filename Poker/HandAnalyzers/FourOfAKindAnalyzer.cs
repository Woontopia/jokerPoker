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
            if (BaseCondition(cards) || JokerCondition(cards))
                return Hand.FourOfAKind;
                
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            return _valueChecker.ContainsSameValueCard(cards, 4);
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            numberOfJokers = CountJokers(cards);
            return OneJokerCondition(cards) || TwoJokerCondition(cards);
        }
        
        private bool OneJokerCondition(IEnumerable<Card> cards)
        {
            return numberOfJokers == 1 && _valueChecker.ContainsSameValueCard(cards, 3);
        }

        private bool TwoJokerCondition(IEnumerable<Card> cards)
        {
            // Normally it is one Pair but since we also have a pair of Jokers it needs to be 2 pairs
            return numberOfJokers == 2 && (_valueChecker.ContainsPairs(cards, 2) ||
                                           _valueChecker.ContainsSameValueCard(cards, 3));
        }
    }
}
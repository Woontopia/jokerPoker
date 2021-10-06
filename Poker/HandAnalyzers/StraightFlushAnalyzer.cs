using System;
using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class StraightFlushAnalyzer : Analyzer
    {
        private StraightChecker _straightChecker;
        private SymbolChecker _symbolChecker;
        private int numberOfJokers;
        public StraightFlushAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _straightChecker = new StraightChecker();
            _symbolChecker = new SymbolChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (BaseCondition(cards) || JokerCondition(cards))
                return Hand.StraightFlush;
            
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            return _straightChecker.ContainsStraight(cards, 5) && _symbolChecker.ContainsSameSymbolCards(cards, 5);
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            numberOfJokers = CountJokers(cards);
            return OneJokerCondition(cards) || TwoJokerCondition(cards);
        }

        private bool OneJokerCondition(IEnumerable<Card> cards)
        {
            return numberOfJokers == 1 && _straightChecker.ContainsStraightWithJoker(cards) &&
                   _symbolChecker.ContainsSameSymbolCards(cards, 5 - numberOfJokers);
        }

        private bool TwoJokerCondition(IEnumerable<Card> cards)
        {
            return numberOfJokers == 2 && _straightChecker.ContainsStraightWithJoker(cards) &&
                   _symbolChecker.ContainsSameSymbolCards(cards, 5 - numberOfJokers);
        }
    }
}
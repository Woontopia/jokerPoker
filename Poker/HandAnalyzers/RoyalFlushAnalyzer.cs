using System;
using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class RoyalFlushAnalyzer : Analyzer
    {
        private readonly SymbolChecker _symbolChecker;
        private readonly ValueChecker _valueChecker;
        public RoyalFlushAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _symbolChecker = new SymbolChecker();
            _valueChecker = new ValueChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (BaseCondition(cards) || JokerCondition(cards))
                return Hand.RoyalFlush;
            
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            return _symbolChecker.ContainsSameSymbolCards(cards, 5) &&
                   _valueChecker.ContainsSeriesOfCards(cards, new int[] { 1, 10, 11, 12, 13 }, 5);
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            var numberOfJokers = CountJokers(cards);
            return _symbolChecker.ContainsSameSymbolCards(cards, 5 - numberOfJokers) &&
                   _valueChecker.ContainsSeriesOfCards(cards, new int[] { 1, 10, 11, 12, 13 }, 5 - numberOfJokers);
        }

    }
}
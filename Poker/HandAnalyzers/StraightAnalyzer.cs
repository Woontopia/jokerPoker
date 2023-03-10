using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class StraightAnalyzer : Analyzer
    {
        private StraightChecker _straightChecker;
        private ValueChecker _valueChecker;
        private int numberOfJokers;
        public StraightAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _straightChecker = new StraightChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (BaseCondition(cards) || JokerCondition(cards))
                return Hand.Straight;
                
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            return _straightChecker.ContainsStraight(cards, 5);
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            numberOfJokers = CountJokers(cards);
            _valueChecker = new ValueChecker();
            return OneJokerCondition(cards) || TwoJokerCondition(cards);
        }

        private bool OneJokerCondition(IEnumerable<Card> cards)
        {
            return numberOfJokers == 1 && _straightChecker.ContainsStraightWithJoker(cards) &&
                   _valueChecker.ContainsDistinctCards(cards, 5 - numberOfJokers);
        }

        private bool TwoJokerCondition(IEnumerable<Card> cards)
        {
            return numberOfJokers == 2 && _valueChecker.ContainsDistinctCards(cards, 5 - numberOfJokers) &&
                   _straightChecker.ContainsStraightWithJoker(cards);
        }
    }
}
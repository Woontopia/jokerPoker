using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class FullHouseAnalyzer : Analyzer
    {
        private ValueChecker _valueChecker;
        public FullHouseAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
            _valueChecker = new ValueChecker();
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            if (_valueChecker.ContainsSameValueCardXTimes(cards, 3) && _valueChecker.ContainsSameValueCardXTimes(cards, 2))
                return Hand.FullHouse;
            
            return nextAnalyzer.AnalyzeHand(cards);
        }

        protected override bool BaseCondition(IEnumerable<Card> cards)
        {
            throw new System.NotImplementedException();
        }

        protected override bool JokerCondition(IEnumerable<Card> cards)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class HighCardAnalyzer : Analyzer
    {
        public HighCardAnalyzer(Analyzer next) : base(next)
        {
            nextAnalyzer = next;
        }

        public override Hand AnalyzeHand(IEnumerable<Card> cards)
        {
            return Hand.HighCard;
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
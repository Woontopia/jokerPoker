using System.Collections.Generic;
using System.Linq;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public abstract class Analyzer
    {
        public Analyzer nextAnalyzer;

        public Analyzer(Analyzer next)
        {
            nextAnalyzer = next;
        }

        public abstract Hand AnalyzeHand(IEnumerable<Card> cards);
        protected abstract bool BaseCondition(IEnumerable<Card> cards);
        protected abstract bool JokerCondition(IEnumerable<Card> cards);

        protected int CountJokers(IEnumerable<Card> cards)
        {
            return cards.Select(card => card.GetCardSymbol()).Count(x => x == Suit.Joker);
        }
    }
}
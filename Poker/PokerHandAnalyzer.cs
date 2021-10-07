using System.Collections.Generic;
using Poker.Checkers;
using Poker.GameEntity;
using Poker.HandAnalyzers;

namespace Poker
{
    public class PokerHandAnalyzer
    {
        public Hand AnalyzeHand(string[] hand)
        {
            new InputChecker(hand);
            IEnumerable<Card> cards = CreateCardList(hand);
            return new AnalyzerChain().GetHand(cards);
        }

        private List<Card> CreateCardList(string[] hand)
        {
            var cards = new List<Card>();
            foreach (var card in hand)
            {
                cards.Add(new Card(card.ToUpper()));
            }
            return cards;
        }
    }
}

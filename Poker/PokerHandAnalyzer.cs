using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Checkers;
using Poker.GameEntity;
using Poker.HandAnalyzers;

namespace Poker
{
    public class PokerHandAnalyzer
    {
        static readonly string Faces = "AKQJT98765432";
        static readonly string Suits = "HDSC";

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
            //todo: remove this part and in the Card class
            // foreach (var card in cards)
            // {
            //     card.PrintCard();
            // }
            return cards;
        }
    }
}

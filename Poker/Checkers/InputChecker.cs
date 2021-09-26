using System;
using System.Collections.Generic;

namespace Poker.Checkers
{
    public class InputChecker
    {
        static readonly string Faces = "AKQJT98765432";
        
        //TODO: change the string to get all available values in CardSymbol enum
        static readonly string Suits = "HDSC";
        
        public InputChecker(string[] hand)
        {
            VerifyLength(hand);
            VerifyDuplicates(hand);
            VerifyFaces(hand);
            VerifySymbols(hand);
        }
        
        private void VerifyLength(string[] hand)
        {
            if (hand.Length != 5)
                throw new ArgumentException("invalid hand: wrong number of cards");
        }

        private void VerifyDuplicates(string[] hand)
        {
            if (new HashSet<string>(hand).Count != hand.Length)
                throw new ArgumentException("invalid hand: duplicates");
        }

        private void VerifyFaces(string[] hand)
        {
            foreach(var card in  hand)
            {
                int face = Faces.IndexOf(card[0]);
                if (face == -1)
                    throw new ArgumentException("invalid hand: non existing face");
            }
        }

        private void VerifySymbols(string[] hand)
        {
            foreach(var card in  hand)
            {
                if (Suits.IndexOf(card[1]) == -1)
                    throw new ArgumentException("invalid hand: non-existing suit");
            }
        }
        
    }
}
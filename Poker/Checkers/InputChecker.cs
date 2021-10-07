using System;
using System.Collections.Generic;
using System.Linq;
using Poker.GameEntity;

namespace Poker.Checkers
{
    public class InputChecker
    {
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
            var hashSet = new HashSet<string>(hand);
            hashSet.Remove("JK");
            if (hashSet.Count + hand.Count(value => value.Equals("JK")) != hand.Length)
                throw new ArgumentException("Invalid hand: duplicates");
        }

        private void VerifyFaces(string[] hand)
        {
            foreach(var card in  hand)
            {
                if (!Enum.IsDefined(typeof(Face), card[0] - '0') && !Enum.IsDefined(typeof(Face), card[0].ToString()))
                    throw new ArgumentException("Invalid hand: non-existing Face");
            }
        }

        private void VerifySymbols(string[] hand)
        {
            foreach(var card in  hand)
            {
                if (!Enum.IsDefined(typeof(Suit), (int)card[1]))
                    throw new ArgumentException("Invalid hand: non-existing suit");
            }
        }
        
    }
}
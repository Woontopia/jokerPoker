﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandAnalyzer
    {
        static readonly string Faces = "AKQJT98765432";
        static readonly string Suits = "HDSC";

        public Hand AnalyzeHand(string[] hand)
        {
            if (hand.Length != 5)
                throw new ArgumentException("invalid hand: wrong number of cards");

            if (new HashSet<string>(hand).Count != hand.Length)
                throw new ArgumentException("invalid hand: duplicates");

            int[] faceCount = new int[Faces.Length];
            long straight = 0, flush = 0;
            foreach(var card in  hand)
            {
                int face = Faces.IndexOf(card[0]);
                if (face == -1)
                    throw new ArgumentException("invalid hand: non existing face");
                straight |= (uint)(1 << face);

                faceCount[face]++;

                if (Suits.IndexOf(card[1]) == -1)
                    throw new ArgumentException("invalid hand: non-existing suit");
                flush |= (uint)(1 << card[1]);
            }

            // shift the bit pattern to the right as far as possible
            while (straight % 2 == 0)
                straight >>= 1;

            // straight is 00011111; A-2-3-4-5 is 1111000000001
            bool hasStraight = straight == 0b11111 || straight == 0b1111000000001;

            // unsets right-most 1-bit, which may be the only one set
            bool hasFlush = (flush & (flush - 1)) == 0;

            if (hasStraight && hasFlush)
                return Hand.StraightFlush;

            int total = 0;
            foreach(var count in faceCount)
            {
                if (count == 4)
                    return Hand.FourOfAKind;
                if (count == 3)
                    total += 3;
                else if (count == 2)
                    total += 2;
            }

            if (total == 5)
                return Hand.FullHouse;

            if (hasFlush)
                return Hand.Flush;

            if (hasStraight)
                return Hand.Straight;

            if (total == 3)
                return Hand.ThreeOfAKind;

            if (total == 4)
                return Hand.TwoPair;

            if (total == 2)
                return Hand.Pair;

            return Hand.HighCard;
        }
    }
}

using System.Collections.Generic;
using Poker.GameEntity;

namespace Poker.HandAnalyzers
{
    public class AnalyzerChain
    {
        private Analyzer chain;

        public AnalyzerChain()
        {
            // How Chain Should be is we dont allow chain
            chain = new RoyalFlushAnalyzer(new StraightFlushAnalyzer(new FourOfAKindAnalyzer(
                new FullHouseAnalyzer(new FlushAnalyzer(new StraightAnalyzer(
                    new ThreeOfAKindAnalyzer(
                        new TwoPairAnalyzer(new OnePairAnalyzer(new HighCardAnalyzer(null))))))))));
            
            // Chain with Jokers Allowed: Flush and FourAKind Switched in chain
            // chain = new RoyalFlushAnalyzer(new StraightFlushAnalyzer(new FlushAnalyzer(
            //     new FourOfAKindAnalyzer(new FullHouseAnalyzer(new StraightAnalyzer(
            //         new ThreeOfAKindAnalyzer(
            //             new TwoPairAnalyzer(new OnePairAnalyzer(new HighCardAnalyzer(null))))))))));
        }

        public Hand GetHand(IEnumerable<Card> cards)
        {
            return chain.AnalyzeHand(cards);
        }
    }
}
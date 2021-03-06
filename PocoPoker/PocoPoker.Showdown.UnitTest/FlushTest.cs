﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocoPoker.Showdown;

namespace PocoPoker.Showdown.UnitTest
{
    [TestClass]
    public class FlushTest
    {
        [TestClass]
        public class DoesFit
        {
            [TestMethod]
            public void Hearths()
            {
              // ARRANGE
                var game = Helper.HearthsFlush();

                // ACT
                var result = new Flush().Evaluate(game);

                // ASSERT
                Assert.IsTrue(result.Success());
                Assert.AreSame(game.Cards, result.UsedCards);
            }

        }

        [TestClass]
        public class DoesNotFit
        {
            [TestMethod]
            public void NoHearthsFlushByOneCard()
            {
                // ARRANGE
                var cards = Helper.HearthsFlush().Cards.ToArray();

                var game = new Game(
                    cards[0],
                    cards[1],
                    cards[2],
                    cards[3],
                    new Card(cards[4].Rank, Suit.CLUBS));

                // ACT
                var result = new Flush().Evaluate(game);

                // ASSERT
                Assert.IsFalse(result.Success());
            }
        }

        class Helper
        {
            public static Game HearthsFlush()
            {
                return new Game(
                    CardBuilder.Three().Hearths(),
                    CardBuilder.Ace().Hearths(),
                    CardBuilder.Four().Hearths(),
                    CardBuilder.Ten().Hearths(),
                    CardBuilder.Queen().Hearths());
            }
        }

    }
}
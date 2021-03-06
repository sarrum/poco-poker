﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocoPoker.Showdown
{
    public class Game : IGame
    {
        private List<Card> cards;

        public Game(Card a, Card b, Card c, Card d, Card e)
        {
            this.cards = new List<Card>(new Card[] { a, b, c, d, e });
        }

        public bool SameSuit()
        {
            return Fun.SameSuit(this.cards);
        }

        public void EvaluationResult(IGameEvaluationResult result)
        {
            Category = result.Category;
            UsedCards = result.UsedCards;
        }

        public GameCategory? Category { get; private set; }
        public IEnumerable<Card> UsedCards { get; private set; }

        public IEnumerable<Card> Cards
        {
            get
            {
                return this.cards.AsEnumerable();
            }
        }

    }
}

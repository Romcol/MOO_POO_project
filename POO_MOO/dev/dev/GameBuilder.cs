using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class GameBuilder
    {
        public Game buildGame(int nb_tours)
        {
            Game game = Game.INSTANCE;
            game.turnsLeft = nb_tours;
            return game;
        }
    }
}
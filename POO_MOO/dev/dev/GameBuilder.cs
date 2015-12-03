using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class GameBuilder
    {
        public Game buildGame()
        {
            Game game = new Game();
            game.turnsLeft = 0;
            return game;
        }
    }
}
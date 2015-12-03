using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class GameBuilder
    {
        public Game buildGame(string map_type)
        {
            Game game = Game.INSTANCE;

			MapTilesFactory factory = new MapTilesFactory(map_type);
			game.map = factory.createMap();
			game.turns_left = factory.map_strategy.nb_turns;
            
            return game;
        }


    }
}
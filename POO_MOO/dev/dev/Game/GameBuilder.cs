using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class GameBuilder
    {
		public void setPlayer1(string name, string race)
		{
			Game.INSTANCE.player1 = new Player(name, race);
		}

		public void setPlayer2(string name, string race)
		{
			Game.INSTANCE.player2 = new Player(name, race);
		}

		public void createMap(string map_type)
		{
			if (Game.INSTANCE.player1 == null || Game.INSTANCE.player2 == null)
			{
				throw new Exception("Players must be initialized before the map filling.");
			}

			MapTilesFactory factory = new MapTilesFactory(map_type);
			Game.INSTANCE.map = factory.createMap();
			Game.INSTANCE.turns_left = factory.map_strategy.nb_turns;
            
		}

	}
}
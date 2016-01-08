using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
	public class MapTilesFactory
	{
		public MapStrategy map_strategy {get;}


		public MapTilesFactory(MapType type)
		{
			this.map_strategy = getMapStrategy(type);
		}

		public MapAPI createMap(GameAPI game)
		{
			return this.map_strategy.createMap(game);
		}

		public static MapStrategy getMapStrategy(MapType type)
		{
			MapStrategy strategy;
			switch (type)
			{
				case MapType.Demo:
					strategy = new DemoMapStrategy();
					break;
				case MapType.Small:
					strategy = new SmallMapStrategy();
					break;
				case MapType.Standard:
					strategy = new StandardMapStrategy();
					break;
				default:
					throw new ArgumentException("Incorrect map type.");
			}
			return strategy;

		}
	}
}

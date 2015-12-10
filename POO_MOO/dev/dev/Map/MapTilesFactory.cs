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


		public MapTilesFactory(string type)
		{
			this.map_strategy = getMapStrategy(type);
		}

		public MapAPI createMap()
		{
			return this.map_strategy.createMap();
		}

		public static MapStrategy getMapStrategy(string type)
		{
			MapStrategy strategy;
			switch (type)
			{
				case "demo":
					strategy = new DemoMapStrategy();
					break;
				case "small":
					strategy = new SmallMapStrategy();
					break;
				case "standard":
					strategy = new StandardMapStrategy();
					break;
				default:
					throw new ArgumentException("Incorrect map type : " + type + ". Must be \"demo#\", \"small\" or \"standard\".");
			}
			return strategy;

		}
	}
}

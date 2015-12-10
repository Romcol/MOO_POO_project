using Microsoft.VisualStudio.TestTools.UnitTesting;
using dev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev.Tests
{
	[TestClass()]
	public class MapStrategyTests
	{
		[TestMethod()]
		public void createMapTest()
		{
			MapStrategy demoStrategy = new DemoMapStrategy();

			Map demoMap = demoStrategy.createMap();

			Assert.AreEqual(demoMap.size, 6);
			Assert.AreEqual(demoMap.tiles.Length, 6*6);
			

			int forest = 0;
			int water = 0;
			int plain = 0;
			int mountain = 0;

			// tests if the types of tile are fairly spread (same number of each tile type)
			for (int i = 0; i < demoMap.tiles.GetLength(0); i++)
			{
				for (int j = 0; j < demoMap.tiles.GetLength(1); j++)
				{
					switch (((Tile)demoMap.tiles[i,j]).getType())
					{
						case TileType.Forest:
							forest++;
							break;
						case TileType.Water:
							water++;
							break;
						case TileType.Plain:
							plain++;
							break;
						case TileType.Mountain:
							mountain++;
							break;
						default:
							break;
					}


				}
			}

			Assert.AreEqual(forest + water + plain + mountain, demoMap.tiles.Length);
            Assert.AreEqual(forest, water);
            Assert.AreEqual(water, plain);
            Assert.AreEqual(plain, mountain);
        }
	}
}
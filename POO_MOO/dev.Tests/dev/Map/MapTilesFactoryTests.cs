using Microsoft.VisualStudio.TestTools.UnitTesting;
using dev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API;

namespace dev.Tests
{
	[TestClass()]
	public class MapTilesFactoryTests
	{
		[TestMethod()]
		public void demoMapTest()
		{
			typeMapTest(MapType.Demo, 6, 5, 4);
		}
		[TestMethod()]
		public void smallMapTest()
		{
			typeMapTest(MapType.Small, 10, 20, 6);
		}

		[TestMethod()]
		public void standardMapTest()
		{
			typeMapTest(MapType.Standard, 14, 30, 8);
		}


		private void typeMapTest(MapType type, int size, int nb_turns, int nb_units)
		{
			MapTilesFactory factory = new MapTilesFactory(type);
			Assert.AreEqual(factory.map_strategy.nb_turns, nb_turns);
			Assert.AreEqual(factory.map_strategy.nb_units, nb_units);
			Assert.AreEqual(factory.map_strategy.size, size);
			
		}
	}
}
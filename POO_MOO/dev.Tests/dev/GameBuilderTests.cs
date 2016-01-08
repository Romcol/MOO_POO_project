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
	public class GameBuilderTests
	{
		[TestMethod()]
		public void demoGameTest()
		{
			typeMapTest("demo", 6, 5);
		}

		[TestMethod()]
		public void smallGameTest()
		{
			typeMapTest("small", 10, 20);
		}

		[TestMethod()]
		public void standardGameTest()
		{
			typeMapTest("standard", 14, 30);
		}

		private void typeMapTest(string type, int size, int turns_left)
		{
			GameBuilder builder = new GameBuilder();
			builder.setPlayer1("john", Race.Orc);
			builder.setPlayer2("james", Race.Human);

			builder.createMap(type);
			Assert.AreEqual(Game.INSTANCE.turns_left, turns_left);
			Assert.AreEqual(Game.INSTANCE.map.size, size);

		}

		[TestMethod()]
		public void setPlayerTest()
		{
			GameBuilder builder = new GameBuilder();
			builder.setPlayer1("john", Race.Orc);
			Assert.AreEqual(Game.INSTANCE.player1.name, "john");
			Assert.AreEqual(Game.INSTANCE.player1.race, Race.Orc);
			builder.setPlayer2("james", Race.Human);
			Assert.AreEqual(Game.INSTANCE.player2.name, "james");
			Assert.AreEqual(Game.INSTANCE.player2.race, Race.Human);

		}

		[TestMethod()]
		public void populateMapTest()
		{
			GameBuilder builder = new GameBuilder();
			try
			{
				builder.createMap("demo");
				Assert.Fail();
			}
			catch (Exception e) { }

			builder.setPlayer1("james", Race.Human);

			try
			{
				builder.createMap("demo");
				Assert.Fail();
			}
			catch (Exception e) { }

			builder.setPlayer2("james", Race.Human);

			try
			{
				builder.createMap("demo");
			}
			catch (Exception e) { Assert.Fail(); }

			createMapTest();


		}

		private void createMapTest()
		{
			MapAPI demoMap = Game.INSTANCE.map;
			Assert.AreEqual(demoMap.size, 6);
			Assert.AreEqual(demoMap.tiles.Length, 6 * 6);


			int forest = 0;
			int water = 0;
			int plain = 0;
			int mountain = 0;

			// tests if the types of tile are fairly spread (same number of each tile type)
			for (int i = 0; i < demoMap.tiles.GetLength(0); i++)
			{
				for (int j = 0; j < demoMap.tiles.GetLength(1); j++)
				{
					switch (((Tile)demoMap.tiles[i, j]).getType())
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


			Assert.AreEqual(Game.INSTANCE.player1.units.Count(), 4);
			Assert.AreEqual(Game.INSTANCE.player2.units.Count(), 4);
		}

		[TestMethod()]
		public void saveLoadTest()
		{
			typeMapTest("standard", 14, 30);

			GameBuilder builder = new GameBuilder();
			builder.setPlayer1("john", Race.Orc);
			builder.setPlayer2("james", Race.Human);

			builder.createMap("standard");

			builder.save("test.dat");

			builder = new GameBuilder();
			GameAPI game = builder.load("test.dat");
			Assert.AreEqual("john", game.player1.name);
			Assert.AreEqual(Race.Orc, game.player1.race);
			Assert.AreEqual("james", game.player2.name);
			Assert.AreEqual(Race.Human, game.player2.race);

		}
		
	}
}
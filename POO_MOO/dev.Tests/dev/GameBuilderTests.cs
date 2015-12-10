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
			try {
				builder.createMap("demo");
				Assert.Fail();
			}
			catch (Exception e) { }

			builder.setPlayer1("james", Race.Human);

			try {
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

		}
	}
}
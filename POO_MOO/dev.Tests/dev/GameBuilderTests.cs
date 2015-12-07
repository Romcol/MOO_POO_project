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
			builder.setPlayer1("john", "orc");
			builder.setPlayer2("james", "human");

			builder.createMap(type);
			Assert.AreEqual(Game.INSTANCE.turns_left, turns_left);
			Assert.AreEqual(Game.INSTANCE.map.size, size);

		}

		[TestMethod()]
		public void setPlayerTest()
		{
			GameBuilder builder = new GameBuilder();
			builder.setPlayer1("john", "orc");
			Assert.AreEqual(Game.INSTANCE.player1.name, "john");
			Assert.AreEqual(Game.INSTANCE.player1.race, "orc");
			builder.setPlayer2("james", "human");
			Assert.AreEqual(Game.INSTANCE.player2.name, "james");
			Assert.AreEqual(Game.INSTANCE.player2.race, "human");

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

			builder.setPlayer1("james", "human");

			try {
				builder.createMap("demo");
				Assert.Fail();
			}
			catch (Exception e) { }

			builder.setPlayer2("james", "human");

			try
			{
				builder.createMap("demo");
			}
			catch (Exception e) { Assert.Fail(); }

		}
	}
}
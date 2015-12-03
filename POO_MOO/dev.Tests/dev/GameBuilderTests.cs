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
			typeGameTest("demo", 6, 5);
		}

		[TestMethod()]
		public void smallGameTest()
		{
			typeGameTest("small", 10, 20);
		}

		[TestMethod()]
		public void standardGameTest()
		{
			typeGameTest("standard", 14, 30);
		}

		private void typeGameTest(string type, int size, int turns_left)
		{
			GameBuilder builder = new GameBuilder();
			Game game = builder.buildGame(type);
			Assert.AreEqual(game.turns_left, turns_left);
			Assert.AreEqual(game.map.size, size);

		}
	}
}
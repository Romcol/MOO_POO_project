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
	public class GameTests
	{
		[TestMethod()]
		public void GameTest()
		{
			Assert.AreEqual(1, 1);
		}

		[TestMethod()]
		public void saveTest()
		{

			GameBuilder builder = new GameBuilder();
			builder.setPlayer1("john", "orc");
			builder.setPlayer2("james", "human");
			builder.createMap("small");

			Game.INSTANCE.save();


		}
	}
}
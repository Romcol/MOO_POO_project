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
	public class UnitTests
	{
		[TestMethod()]
		public void canMoveTest()
		{

			GameBuilder builder = new GameBuilder();
			builder.setPlayer1("john", Race.Human);
			builder.setPlayer2("john", Race.Orc);

			TileFlyweight tilesFly = new TileFlyweight();
			TileAPI M = tilesFly.getTile(TileType.Mountain);
			TileAPI F = tilesFly.getTile(TileType.Forest);
			TileAPI P = tilesFly.getTile(TileType.Plain);
			TileAPI W = tilesFly.getTile(TileType.Water);

			TileAPI[,] tiles =
				{//  0 1 2
					{P,P,P},//0
					{M,P,W},//1
					{P,F,P},//2
			};

			builder.game.map = new Map(tiles);
			builder.game.player1.units = new List<UnitAPI>();
			builder.game.player2.units = new List<UnitAPI>();
			Game.INSTANCE = builder.game;
			builder.game.map.getTile(0, 1);
			Human h1 = new Human(1, 1);
			builder.game.player1.units.Add(h1);
			Assert.IsTrue(h1.canMove(0, 1));
			Assert.IsTrue(h1.canMove(1, 0));
			Assert.IsTrue(h1.canMove(2, 1));
			Assert.IsTrue(h1.canMove(1, 2));
			Assert.IsFalse(h1.canMove(0, 0));
			Assert.IsFalse(h1.canMove(0, 2));
			Assert.IsFalse(h1.canMove(2, 0));
			Assert.IsFalse(h1.canMove(2, 2));
			h1.move(0, 1);
			Assert.AreEqual(0,h1.x);
			Assert.AreEqual(1, h1.y);
			Assert.AreEqual(1, h1.movePoints);

			h1.move(1, 1);
			Assert.AreEqual(1, h1.x);
			Assert.AreEqual(1, h1.y);
			Assert.AreEqual(0, h1.movePoints);

			// Not enough move points
			Assert.IsFalse(h1.canMove(0, 1));


			builder.game.player2.units = new List<UnitAPI>();
			Orc o1 = new Orc(1, 1);
			builder.game.player1.units.Add(o1);



			Assert.IsTrue(o1.canMove(0, 1));
			Assert.IsTrue(o1.canMove(1, 0));
			Assert.IsTrue(o1.canMove(2, 1));
			Assert.IsFalse(o1.canMove(1, 2));
			Assert.IsFalse(o1.canMove(0, 0));
			Assert.IsFalse(o1.canMove(0, 2));
			Assert.IsFalse(o1.canMove(2, 0));
			Assert.IsFalse(o1.canMove(2, 2));


			

		}
	}
}
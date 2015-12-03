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
        public void buildGameTest()
        {
            GameBuilder builder = new GameBuilder();
            Game game = builder.buildGame(10);
            Assert.AreEqual(game.turnsLeft, 10);
            

        }
    }
}
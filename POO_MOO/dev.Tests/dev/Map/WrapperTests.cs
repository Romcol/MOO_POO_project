﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using dev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev.Tests
{
    [TestClass()]
    public class WrapperTests
    {
        [TestMethod()]
        public void getMovesTest()
        {

            GameBuilder builder = new GameBuilder();
            builder.setPlayer1("john", Race.Orc);
            builder.setPlayer2("james", Race.Human);

            builder.createMap(MapType.Demo);
            Wrapper wrapper = new Wrapper();

            int[] moves = wrapper.getMoves(MapTilesFactory.getMapStrategy(MapType.Demo), Game.INSTANCE.player1.units[0], Game.INSTANCE.player1, Game.INSTANCE.player2, 1, Game.INSTANCE);

           // Assert.IsNull(moves);
           // Assert.Fail();
        }
    }
}
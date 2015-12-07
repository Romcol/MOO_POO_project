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
    public class TileFlyweightTests
    {
        [TestMethod()]
        public void TileFlyweightTest()
        {
            TileFlyweight tileFlyweight = new TileFlyweight();

            // Test types coherence
            Assert.AreEqual(tileFlyweight.getTile(TileType.Mountain).GetType(), typeof(Mountain));
            Assert.AreEqual(tileFlyweight.getTile(TileType.Plain).GetType(), typeof(Plain));
            Assert.AreEqual(tileFlyweight.getTile(TileType.Forest).GetType(), typeof(Forest));
            Assert.AreEqual(tileFlyweight.getTile(TileType.Water).GetType(), typeof(Water));

            // Test references equality
            Assert.AreEqual(tileFlyweight.getTile(TileType.Mountain), tileFlyweight.getTile(TileType.Mountain));
            Assert.AreEqual(tileFlyweight.getTile(TileType.Plain), tileFlyweight.getTile(TileType.Plain));
            Assert.AreEqual(tileFlyweight.getTile(TileType.Forest), tileFlyweight.getTile(TileType.Forest));
            Assert.AreEqual(tileFlyweight.getTile(TileType.Water), tileFlyweight.getTile(TileType.Water));
        }
    }
}
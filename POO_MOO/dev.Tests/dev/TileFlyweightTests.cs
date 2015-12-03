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
            Assert.AreEqual(tileFlyweight.getTile("mountain").GetType(), typeof(Mountain));
            Assert.AreEqual(tileFlyweight.getTile("plain").GetType(), typeof(Plain));
            Assert.AreEqual(tileFlyweight.getTile("forest").GetType(), typeof(Forest));
            Assert.AreEqual(tileFlyweight.getTile("water").GetType(), typeof(Water));

            // Test references equality
            Assert.AreEqual(tileFlyweight.getTile("mountain"), tileFlyweight.getTile("mountain"));
            Assert.AreEqual(tileFlyweight.getTile("plain"), tileFlyweight.getTile("plain"));
            Assert.AreEqual(tileFlyweight.getTile("forest"), tileFlyweight.getTile("forest"));
            Assert.AreEqual(tileFlyweight.getTile("water"), tileFlyweight.getTile("water"));
        }
    }
}
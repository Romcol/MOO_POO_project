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
	public class MapTests
	{
		[TestMethod()]
		public void distanceTest()
		{
			Assert.AreEqual(0, Map.distance(1, 3, 1, 3));
			Assert.AreEqual(1, Map.distance(1, 4, 1, 3));
			Assert.AreEqual(7, Map.distance(2, 4, 7, 2));
		}

		[TestMethod()]
		public void areAdjacentTest()
		{
			Assert.IsTrue(Map.areAdjacent(1, 3, 1, 4));
			Assert.IsTrue(Map.areAdjacent(2, 3, 2, 2));
			Assert.IsFalse(Map.areAdjacent(2, 2, 2, 2));
			Assert.IsFalse(Map.areAdjacent(0,1,2,3));
		}
	}
}
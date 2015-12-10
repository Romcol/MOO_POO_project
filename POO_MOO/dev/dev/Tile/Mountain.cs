using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Mountain : Tile
    {
		public override TileType getType()
		{
			return TileType.Mountain;
		}

		public override double moveCost(Race race)
		{
			throw new NotImplementedException();
		}
	}
}

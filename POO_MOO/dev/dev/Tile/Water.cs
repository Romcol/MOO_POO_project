using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Water : Tile
    {
		public override TileType getType()
		{
			return TileType.Water;
		}
	}
}

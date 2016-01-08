using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
	[Serializable()]
    public class Water : Tile
    {
		public override TileType getType()
		{
			return TileType.Water;
		}

		public override int getVictoryPoints(Race race)
		{
			return 0;
		}

		public override double moveCost(Race race)
		{
			switch (race)
			{
				case Race.Human:
					return 1;
				default:
					return -1;
			}
		}
	}
}
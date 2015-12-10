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

		public override int getVictoryPoints(Race race)
		{
			switch (race)
			{
				case Race.Human:
					return 1;
				case Race.Elf:
					return 0;
				case Race.Orc:
					return 2;
				default:
					return 0;
			}
		}

		public override double moveCost(Race race)
		{
			switch (race)
			{
				case Race.Elf:
					return 2;
				default:
					return 1;
			}
		}
	}
}

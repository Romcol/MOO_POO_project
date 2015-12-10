using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Plain : Tile
    {
		public override TileType getType()
		{
			return TileType.Plain;
		}
		
		public override int getVictoryPoints(Race race)
		{
			switch (race)
			{
				case Race.Human:
					return 2;
				case Race.Elf:
					return 1;
				case Race.Orc:
					return 1;
				default:
					return 0;
			}
		}

		public override double moveCost(Race race)
		{
			switch (race)
			{
				case Race.Orc:
					return 0.5;
				default:
					return 1;
			}
		}
	}
}

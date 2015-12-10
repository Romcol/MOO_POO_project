using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
	public class Forest : Tile
	{
		public override TileType getType()
		{
			return TileType.Forest;
		}

		public override int getVictoryPoints(Race race)
		{
			switch (race)
			{
				case Race.Human:
					return 1;
				case Race.Elf:
					return 3;
				case Race.Orc:
					return 1;
				default:
					return 0;
			}
		}

		public override double moveCost(Race race)
		{
			return 1;
		}
	}
}
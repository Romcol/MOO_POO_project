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

		public double moveCost(Race race)
		{
			switch (race)
			{
				case Race.Human:

					break;
				case Race.Elf:
					break;
				case Race.Orc:
					break;
				default:
					break;
			}
			throw new NotImplementedException();
		}
	}
}

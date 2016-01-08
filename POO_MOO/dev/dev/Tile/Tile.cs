using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
	[Serializable()]
	public abstract class Tile : TileAPI
	{
		public abstract TileType getType();

		/// <summary>
		/// Calculates the number of move points a unit needs to move to a tile
		/// </summary>
		/// <returns>Number of move points a unit needs to move to a tile</returns>
		public abstract double moveCost(Race race);

		public abstract int getVictoryPoints(Race race);
	}
}

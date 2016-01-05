using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public interface MapAPI
    {
		/// <summary>
		/// Tiles of the map
		/// </summary>
        TileAPI[,] tiles{ get; set; }

		/// <summary>
		/// Size of the map
		/// </summary>
		int size { get; set; }

		/// <summary>
		/// Verifies if a coord is bounded between 0 and the size of the map
		/// </summary>
		/// <param name="x">The coord to verify</param>
		/// <returns>a boolean saying if the coord is correct or not</returns>
		bool verifyCoord(int x);

		TileAPI getTile(int x, int y);

	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public class Map : MapAPI
	{


        public int size
        {
            get;
            set;
        }


        public TileAPI[,] tiles
        {
            get;
            set;
        }


		public Map(int size)
		{
			this.size = size;
			this.tiles = new Tile[this.size, this.size];
		}



		public TileAPI getTile(int x, int y)
		{
			if(!verifyCoord(x) || !verifyCoord(y))
			{
				throw new ArgumentException("x or y out of bounds.");
			}

			return this.tiles[x,y];
		}

		public bool verifyCoord(int x)
		{
			return x >= 0 && x < this.size;
        }
    }
}

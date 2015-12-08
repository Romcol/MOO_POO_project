using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;
using System.Threading.Tasks;

namespace dev
{
    public class Map : MapAPI
	{

        public Map(TileAPI[,] tiles)
        {
            Tiles = tiles;
        }

        public int size
        {
            get;
            set;
        }

        public TileAPI[,] Tiles
        {
            get;
            set;
        }

        public Map(int size)
		{
			this.size = size;
			this.Tiles = new Tile[this.size, this.size];
		}



		public TileAPI getTile(int x, int y)
		{
			if(!verifyCoord(x) || !verifyCoord(y))
			{
				throw new ArgumentException("x or y out of bounds.");
			}

			return this.Tiles[x,y];
		}

		public bool verifyCoord(int x)
		{
			return x >= 0 && x < this.size;
        }
    }
}

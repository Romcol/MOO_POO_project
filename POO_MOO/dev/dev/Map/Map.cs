using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;
using System.Threading.Tasks;

namespace dev
{
	[Serializable()]
	public class Map : MapAPI
	{

        public Map(TileAPI[,] tiles)
        {
			this.size = tiles.Length;
            this.tiles = tiles;
        }

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

		public static bool areAdjacent(int x1, int y1, int x2, int y2)
		{
			return Map.distance(x1,y1,x2, y2) == 1;
		}

		public static int distance(int x1, int y1, int x2, int y2)
		{
			return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

		internal static bool inline(int x1, int y1, int x2, int y2)
		{
			return x1 == x2 || y1 == y2;
		}

	}
}

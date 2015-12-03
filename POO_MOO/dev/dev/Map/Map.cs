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

    }
}

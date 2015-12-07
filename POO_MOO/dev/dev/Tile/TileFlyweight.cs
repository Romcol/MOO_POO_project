using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
	public class TileFlyweight
	{

		private Dictionary<TileType, Tile> tiles
		{
			get;
			set;
		}

		public TileFlyweight()
		{
			this.tiles = new Dictionary<TileType, Tile>();
            this.tiles.Add(TileType.Mountain, new Mountain());
            this.tiles.Add(TileType.Plain, new Plain());
            this.tiles.Add(TileType.Forest, new Forest());
            this.tiles.Add(TileType.Water, new Water());
        }


        public Tile getTile(TileType type)
		{
            return this.tiles[type];
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
	public class TileFlyweight
	{

		private Dictionary<String, Tile> tiles
		{
			get;
			set;
		}

		public TileFlyweight()
		{
			this.tiles = new Dictionary<string, Tile>();
            this.tiles.Add("mountain", new Mountain());
            this.tiles.Add("plain", new Plain());
            this.tiles.Add("forest", new Forest());
            this.tiles.Add("water", new Water());
        }


        public Tile getTile(string key)
		{
            return this.tiles[key];
		}
	}
}
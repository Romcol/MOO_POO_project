using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
	public abstract class Tile : TileAPI
	{
		public abstract TileType getType();
	}
}

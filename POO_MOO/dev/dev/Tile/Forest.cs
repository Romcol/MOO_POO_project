﻿using System;
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
	}
}

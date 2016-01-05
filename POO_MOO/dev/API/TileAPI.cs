using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public interface TileAPI
    {
        TileType getType();
		double moveCost(Race race);

	}
}
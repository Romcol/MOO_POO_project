using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public interface MapAPI
    {
        TileAPI[,] tiles{ get; set; }

		int size { get; set; }
	}
}
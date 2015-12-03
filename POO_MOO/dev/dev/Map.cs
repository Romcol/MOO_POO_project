using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public class Map : API.MapAPI
    {


        public int size
        {
            get;
            set;
        }

        TileAPI[][] MapAPI.Tiles
        {
            get;

            set;
        }

    }
}

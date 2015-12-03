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
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        TileAPI[][] MapAPI.Tiles
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

    }
}

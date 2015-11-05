using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public abstract class Tile : TileAPI
    {
        public List<Unit> Units
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}

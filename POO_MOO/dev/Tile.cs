using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public  abstract class Tile
    {
        public string kind
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
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

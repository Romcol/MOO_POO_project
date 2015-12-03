using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public abstract class MapStrategy
    {
		public abstract int size { get; }
		public abstract int nb_turns { get; }
		public abstract int nb_units { get; }

		public Map createMap()
		{
			Map map = new Map(this.size);
			return map;
		}

    }
}
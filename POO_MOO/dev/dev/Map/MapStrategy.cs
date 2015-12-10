using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace dev
{
    public abstract class MapStrategy
    {
		public abstract int size { get; }
		public abstract int nb_turns { get; }
		public abstract int nb_units { get; }

        private Wrapper wrapper;
        

		public MapStrategy()
		{
            wrapper = new Wrapper();
		}


		/*
		* Create a map using the C++ library
		*/
		public MapAPI createMap()
		{
            return wrapper.createMap(this, Game.INSTANCE);
        }
        
	}
}
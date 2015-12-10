using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace dev
{
    public abstract class MapStrategy:IDisposable
    {
		public abstract int size { get; }
		public abstract int nb_turns { get; }
		public abstract int nb_units { get; }



		bool disposed = false;
		IntPtr nativeAlgo;

		public MapStrategy()
		{
			nativeAlgo = Algo_new();
		}


		/*
		* Create a map using the C++ library
		*/
		public Map createMap()
		{
			Map map = new Map(this.size);
			TileFlyweight tileFlyweight = new TileFlyweight();
			TileType[] tiles1D = new TileType[this.size * this.size];

            // Call to the dll method
            Algo_fillMap(nativeAlgo, tiles1D, this.size);


			// Converts TileType (enum) 2D array into a Tile (object) array
			for (int i = 0; i < this.size; i++)
			{
				for (int j = 0; j < this.size; j++)
				{
					map.tiles[i, j] = tileFlyweight.getTile(tiles1D[i+size*j]);
				}
			}

			return map;
		}

		~MapStrategy()
		{
			Dispose(false);
			Algo_delete(nativeAlgo);
		}


		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
				return;
			if (disposing)
			{
				Algo_delete(nativeAlgo);
			}
			disposed = true;
		}

        [DllImport("C:\\Users\\Romcol\\MOO_POO_project\\POO_MOO\\Debug\\libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
		extern static void Algo_fillMap(IntPtr algo, TileType[] tiles, int nbTiles);

		[DllImport("C:\\Users\\Romcol\\MOO_POO_project\\POO_MOO\\Debug\\libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
		extern static IntPtr Algo_new();

		[DllImport("C:\\Users\\Romcol\\MOO_POO_project\\POO_MOO\\Debug\\libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
		extern static IntPtr Algo_delete(IntPtr algo);
	}
}
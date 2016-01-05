using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dev
{
    public class Wrapper : IDisposable
    {

        bool disposed = false;
        IntPtr nativeAlgo;

        public Wrapper()
        {
            nativeAlgo = Algo_new();
        }


        /*
		* Create a map using the C++ library
		*/

        public int[] getMoves(MapStrategy strategy, UnitAPI unit, PlayerAPI p1, PlayerAPI p2, int curr_p)
        {
            int[] curr_pos = { unit.x, unit.y };
            Race race = (curr_p == 1) ? p1.race : p2.race;
            int[] moves = new int[strategy.size * strategy.size];
            TileType[] tiles = new TileType[strategy.size * strategy.size];
            int[] pos = new int[strategy.size * strategy.size];


            foreach (var tmpUnit in p1.units)
            {
                pos[tmpUnit.y * strategy.size + tmpUnit.x] = 1;
            }
            foreach (var tmpUnit in p1.units)
            {
                pos[tmpUnit.y * strategy.size + tmpUnit.x] = 2;
            }


            for (int i = 0; i < strategy.size; i++)
            {
                for (int j = 0; j < strategy.size; j++)
                {
                    tiles[i + strategy.size * j] = Game.INSTANCE.map.tiles[i, j].getType();
                }
            }

            Algo_getMoves(nativeAlgo, tiles, strategy.size, pos, curr_pos, curr_p, race, moves);
            return moves;
        }
        public MapAPI createMap(MapStrategy strategy, GameAPI game)
        {
            MapAPI map = new Map(strategy.size);
            TileFlyweight tileFlyweight = new TileFlyweight();
            TileType[] tiles1D = new TileType[strategy.size * strategy.size];
            int[] pos = new int[strategy.size * strategy.size];
            int[] posp1 = new int[2]; // posp1[0],posp1[1] : position (x,y) of unit's player1 at the beginning
            int[] posp2 = new int[2];
            // Call to the dll method
            Algo_fillMap(nativeAlgo, tiles1D, strategy.size, pos);

            // Converts TileType (enum) 2D array into a Tile (object) array
            for (int i = 0; i < strategy.size; i++)
            {
                for (int j = 0; j < strategy.size; j++)
                {
                    map.tiles[i, j] = tileFlyweight.getTile(tiles1D[i + strategy.size * j]);
                    if (pos[i + strategy.size * j] == 1)
                    {
                        posp1[0] = i;
                        posp1[1] = j;
                    }
                    else if (pos[i + strategy.size * j] == 2)
                    {
                        posp2[0] = i;
                        posp2[1] = j;
                    }
                }
            }

            //Define units for each player
            placeUnits(map, game.player1, strategy.nb_units, posp1);
            placeUnits(map, game.player2, strategy.nb_units, posp2);
            return map;
        }

        private void placeUnits(MapAPI map, PlayerAPI player, int nb_units, int[] posUnits)
        {
            UnitAPI unit;

            for (int i = 0; i < nb_units; i++)
            {
                Race race = player.race;
                switch (race)
                {
                    case Race.Human:
                        unit = new Human();
                        break;
                    case Race.Elf:
                        unit = new Elf();
                        break;
                    case Race.Orc:
                        unit = new Orc();
                        break;
                    default:
                        throw new ArgumentException();
                }
                unit.x = posUnits[0];
                unit.y = posUnits[1];
                player.units.Add(unit);
            }
        }

        ~Wrapper()
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

        [DllImport("C:\\Users\\Guillaume\\MOO_POO_project\\POO_MOO\\Debug\\libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_getMoves(IntPtr algo, TileType[] tiles, int nbTiles, int[] pos, int[] curr_pos, int curr_p, Race race, int[] moves);

        [DllImport("C:\\Users\\Guillaume\\MOO_POO_project\\POO_MOO\\Debug\\libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_fillMap(IntPtr algo, TileType[] tiles, int nbTiles, int[] pos);

        [DllImport("C:\\Users\\Guillaume\\MOO_POO_project\\POO_MOO\\Debug\\libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("C:\\Users\\Guillaume\\MOO_POO_project\\POO_MOO\\Debug\\libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algo);
    }
}
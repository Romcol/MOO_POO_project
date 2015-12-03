using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public abstract class Unit : API.UnitAPI
    {
        TileAPI UnitAPI.Tile
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

        bool UnitAPI.attack(UnitAPI unit)
        {
            throw new NotImplementedException();
        }

        List<TileAPI> UnitAPI.getPossibleMoves()
        {
            throw new NotImplementedException();
        }



        int UnitAPI.getVictoryPoints()
        {
            throw new NotImplementedException();
        }

        bool UnitAPI.move(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public interface UnitAPI
    {
        TileAPI Tile { get; set; }

        bool attack(UnitAPI unit);
        List<TileAPI> getPossibleMoves();
        int getVictoryPoints();
        bool move(int x, int y);
    }
}

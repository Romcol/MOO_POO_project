using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public interface UnitAPI
    {
        TileAPI Tile { get; set; }

        bool attack(Unit unit);
        List<Tile> getPossibleMoves();
        int getVictoryPoints();
        bool move(int x, int y);
    }
}

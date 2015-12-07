﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
	public interface UnitAPI
	{

		int x { get; set; }
		int y { get; set; }

		int lifePoints { get; set; }
		int attackPoints { get; set; }
		int defencePoints { get; set; }
		int movePoints { get; set; }

		bool attack(UnitAPI unit);
        List<TileAPI> getPossibleMoves();
        int getVictoryPoints();
        bool move(int x, int y);

		void initMovePoints();
    }
}

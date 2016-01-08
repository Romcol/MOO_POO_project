using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dev;

namespace API
{
	public interface UnitAPI
	{

		int x { get; set; }
		int y { get; set; }

		int lifePoints { get; set; }
		int attackPoints { get; set; }
		int defencePoints { get; set; }
		double movePoints { get; set; }

        //List<TileAPI> getPossibleMoves();

		void initMovePoints();


		bool canMove(int x, int y);
		void move(int x, int y);
		bool canAttack(UnitAPI unit);
		void attack(UnitAPI unit);
		void kill();

		Race getRace();
	}
}

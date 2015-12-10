using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public abstract class Unit : UnitAPI
    {
		public int x {
            get;
            set;
		}
		public int y
		{
            get;
            set;
		}

		public int lifePoints { get; set; }
		public int attackPoints { get; set; }
		public int defencePoints { get; set; }
		public double movePoints { get; set; }

		const double MOV_PTS = 2;

		public bool attack(UnitAPI unit)
        {
            throw new NotImplementedException();
        }

        public List<TileAPI> getPossibleMoves()
        {
            throw new NotImplementedException();
        }


        public bool move(int x, int y)
        {
            throw new NotImplementedException();
        }

		public abstract Race getRace();

		public void initMovePoints()
		{
			this.movePoints = MOV_PTS;
		}
    }
}
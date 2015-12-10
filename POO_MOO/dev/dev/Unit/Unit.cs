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
			get { return this.x; }
			set {
				if (Game.INSTANCE.map.verifyCoord(value))
				{
					this.y = value;
				}
				else
				{
					throw new ArgumentException("Value " + value + " for x is out of bounds [0," + Game.INSTANCE.map.size + "]");
				}
			}
		}
		public int y
		{
			get { return this.y; }
			set
			{
				if (Game.INSTANCE.map.verifyCoord(value))
				{
					this.y = value;
				}
				else
				{
					throw new ArgumentException("Value " + value + " for y is out of bounds [0," + Game.INSTANCE.map.size + "]");
				}
			}
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



        public int getVictoryPoints()
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

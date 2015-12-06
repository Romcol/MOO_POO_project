using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public abstract class Unit : API.UnitAPI
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

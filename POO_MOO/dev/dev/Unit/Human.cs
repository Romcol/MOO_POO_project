using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
	[Serializable()]
	public class Human : Unit
    {
		public override int InitialLifePoints { get { return 15; } }

		public Human(int x, int y) : base(x,y)
		{
			this.lifePoints = InitialLifePoints;
			this.attackPoints = 6;
			this.defencePoints = 3;
			this.initMovePoints();
		}

		/// <summary>
		/// Humans can only attack at a distance of 1
		/// </summary>
		/// <param name="unit"></param>
		/// <returns></returns>
		public override bool canAttack(UnitAPI unit)
		{
			return  unit.getRace() != this.getRace() && Map.areAdjacent(unit.x, unit.y, this.x, this.y);
		}

		public override Race getRace()
		{
			return Race.Human;
        }
	}
}

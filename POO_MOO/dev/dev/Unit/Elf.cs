using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
	[Serializable()]
	public class Elf : Unit
    {
		public override int InitialLifePoints { get { return 12; } }

		public Elf(int x, int y) : base(x,y)
		{
			this.lifePoints = InitialLifePoints;
			this.attackPoints = 4;
			this.defencePoints = 3;
			this.initMovePoints();
		}

		public override Race getRace()
		{
			return Race.Elf;
        }


		public override bool canAttack(UnitAPI unit) {
			return this.canMove(unit.x,unit.y) && unit.getRace() != this.getRace() && Map.distance(unit.x, unit.y, this.x, this.y) <=2;
		}
	}
}

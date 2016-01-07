using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Elf : Unit
    {
		public override int InitialLifePoints { get { return 12; } }

		public Elf()
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
			return unit.getRace() != this.getRace() && Map.distance(unit.x, unit.y, this.x, this.y) <=2;
		}
	}
}

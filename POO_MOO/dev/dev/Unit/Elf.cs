using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Elf : Unit
    {
		public Elf()
		{
			this.lifePoints = 12;
			this.attackPoints = 4;
			this.defencePoints = 3;
			this.initMovePoints();
		}

		public override Race getRace()
		{
			return Race.Elf;
        }

	}
}

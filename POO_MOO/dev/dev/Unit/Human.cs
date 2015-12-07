using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Human : Unit
    {
		public Human()
		{
			this.lifePoints = 15;
			this.attackPoints = 6;
			this.defencePoints = 3;
			this.initMovePoints();
		}

		public override Race getRace()
		{
			return Race.Human;
        }
	}
}

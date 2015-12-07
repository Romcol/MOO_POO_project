using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
	public class Orc : Unit
	{
		public Orc()
		{
			this.lifePoints = 17;
			this.attackPoints = 5;
			this.defencePoints = 2;
			this.initMovePoints();
		}

		public override Race getRace()
		{
			return Race.Orc;
		}
	}
}

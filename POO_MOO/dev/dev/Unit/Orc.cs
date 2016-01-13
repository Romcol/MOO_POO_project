using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
	[Serializable()]
	public class Orc : Unit
	{
		public override int InitialLifePoints { get { return 17; } }

		public Orc(int x, int y) : base(x,y)
		{
			this.lifePoints = InitialLifePoints;
			this.attackPoints = 5;
			this.defencePoints = 2;
			this.initMovePoints();
		}
		

		public override bool canAttack(UnitAPI unit)
		{
			
			if (this.movePoints < 1 || unit.getRace() == this.getRace()) return false;

			if (Game.INSTANCE.map.getTile(this.x,this.y).getType() == TileType.Mountain)
			{
				return Map.distance(unit.x, unit.y, this.x, this.y) <= 2;
            } else
			{
				return Map.distance(unit.x, unit.y, this.x, this.y) <= 1;
			}
		}

		public override Race getRace()
		{
			return Race.Orc;
		}
	}
}

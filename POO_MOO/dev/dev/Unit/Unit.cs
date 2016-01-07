using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public abstract class Unit : UnitAPI
    {
		public abstract int InitialLifePoints { get; }
		public int x {get;set;}
		public int y {get;set;}
		public int lifePoints { get; set; }
		public int attackPoints { get; set; }
		public int defencePoints { get; set; }
		public double movePoints { get; set; }
		const double MOV_PTS = 2;

		//public abstract List<TileAPI> getPossibleMoves();
		public bool canMove(int x, int y)
		{
			double moveCost = Game.INSTANCE.map.getTile(x, y).moveCost(this.getRace());
			// checks if enough move point/tile is free
			if (moveCost == -1 || moveCost > this.movePoints || Game.INSTANCE.getUnit(x,y) != null)
			{
				return false;
			}
			// checks if adjacent tile
			return Map.areAdjacent(x, y, this.x, this.y);
		}
		public void move(int x, int y)
		{
			if(this.canMove(x,y))
			{
				return;
			}
			this.x = x;
			this.y = y;
			this.movePoints -= Game.INSTANCE.map.getTile(x, y).moveCost(this.getRace());
		}
		public void attack(UnitAPI unit)
		{
			if (!this.canAttack(unit)) return;


			double attackerPoints = (this.lifePoints / this.InitialLifePoints) * this.attackPoints;
			double defenderPoints = (this.lifePoints / this.InitialLifePoints) * this.defencePoints;

			double attackerRate = attackerPoints / (attackerPoints + defenderPoints)*100;
			double defenderRate = defencePoints / (attackerPoints + defenderPoints)*100;

			int random = new Random().Next(1,100);
			
			if(random<=attackerRate) // attacker wins
			{
				unit.lifePoints--;
			}
			else // defender wins
			{
				unit.lifePoints--;
			}

		}
		public abstract bool canAttack(UnitAPI unit);

		public void initMovePoints()
		{
			this.movePoints = MOV_PTS;
		}
		public void kill() { this.getPlayer().units.Remove(this); }

		public PlayerAPI getPlayer()
		{
			if(Game.INSTANCE.player1.race == this.getRace())
			{
				return Game.INSTANCE.player1;
            } else
			{
				return Game.INSTANCE.player2;
			}
		}
		
		public abstract Race getRace();

	}
}
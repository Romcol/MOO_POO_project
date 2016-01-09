using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
	[Serializable()]
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


		public Unit(int x, int y) {
			this.x = x;
			this.y = y;
		}

        //public abstract List<TileAPI> getPossibleMoves();
        public bool hasEnemyUnits()
        {
            PlayerAPI enemy = (this.getPlayer() == Game.INSTANCE.player1) ? Game.INSTANCE.player2 : Game.INSTANCE.player1;
            List<UnitAPI> l = Game.INSTANCE.getUnits(this.x, this.y, enemy);
            return (l.Count() > 0);
        }
        public bool canMove(int x, int y)
		{
			double moveCost = Game.INSTANCE.map.getTile(x, y).moveCost(this.getRace());
            // checks if enough move point/tile is free
			if (moveCost == -1 || moveCost > this.movePoints || this.hasEnemyUnits())
			{
				return false;
			}

			// checks if adjacent tile
			return Map.areAdjacent(x, y, this.x, this.y);
		}
		public void move(int x, int y)
		{
			if(!this.canMove(x,y))
			{
				return;
			}
			this.x = x;
			this.y = y;
            this.movePoints -= Game.INSTANCE.map.getTile(x, y).moveCost(this.getRace());
            //Add victory points to player after move
            this.getPlayer().victoryPoints += Game.INSTANCE.map.getTile(x, y).getVictoryPoints(this.getRace());
        }
		public UnitAPI attack(UnitAPI unit)
		{
			if (!this.canAttack(unit)) return null;

            this.movePoints -= Game.INSTANCE.map.getTile(x, y).moveCost(this.getRace());

            double attackerPoints = (this.lifePoints / this.InitialLifePoints) * this.attackPoints;
			double defenderPoints = (this.lifePoints / this.InitialLifePoints) * this.defencePoints;

			double attackerRate = attackerPoints / (attackerPoints + defenderPoints)*100;
			double defenderRate = defencePoints / (attackerPoints + defenderPoints)*100;

			int random = new Random().Next(1,100);

            UnitAPI loser = null;

            if (random<=attackerRate) // attacker wins
			{
                loser = unit;
			}
			else // defender wins
			{
                loser = this;
			}

            int randomDamages = new Random().Next(1, loser.lifePoints);
            loser.lifePoints -= randomDamages;

            if (unit.lifePoints < 0)
            {
                unit.kill();
                //If Defender is killed and there's no enemy on the tile the unit can move to the selected tile
                if(Game.INSTANCE.getUnits(x,y) == null)
                {
                    this.x = x;
                    this.y = y;
                }
            }
            if (this.lifePoints < 0) this.kill();

            return loser;

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
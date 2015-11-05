using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public abstract class Unit : UnitAPI
    {
        public int movePoints
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int lifePts
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int attackPts
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int defencePts
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Tile Tile
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public bool move(Tile tile)
        {
            throw new System.NotImplementedException();
        }
        public bool attack(Unit unit)
        {
            throw new System.NotImplementedException();
        }
        public bool canMove(Tile tile)
        {
            throw new System.NotImplementedException();
        }
        public List<Tile> getPossibleMoves()
        {
            throw new System.NotImplementedException();
        }

        public bool canAttack(Tile tile)
        {
            throw new System.NotImplementedException();
        }
        public int getVictoryPoints()
        {
            throw new System.NotImplementedException();
        }


    }
}

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

        public Race Race
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int x
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int y
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public TileAPI Tile { get; set; }

        public abstract bool attack(Unit unit);
        public abstract List<Tile> getPossibleMoves();
        public abstract int getVictoryPoints();
        public abstract bool move(int x, int y);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public class Game : GameAPI
    {
        public static Game INSTANCE = new Game();

        private Game()
        {

        }

        public int turns_left {
            get;
            set;
        }
        
        public MapAPI map
        {
            get;
            set;
        }

        public PlayerAPI player1
        {
            get;
            set;
        }

        public PlayerAPI player2
        {
            get;
            set;
        }

        public TurnAPI turn
        {
            get;
            set;
        }



        public void load()
        {
            throw new NotImplementedException();
        }

        public void next()
        {
			this.turn.init();
			this.turns_left--;
            throw new NotImplementedException();
        }

		public bool isFinished()
		{
			return this.turns_left == 0 || this.player1.units.Count() == 0 || this.player2.units.Count() == 0;
        }

		public PlayerAPI getResult()
		{
			if(!this.isFinished())
			{
				throw new Exception("Game is not finished.");
			}
			if (this.player1.units.Count() == 0)
				return this.player2;
			if (this.player2.units.Count() == 0)
				return this.player1;
			if (this.turns_left == 0)
				return null;

			return null;
		}

		public void save()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace dev
{
	[Serializable()]
	public class Game : GameAPI
    {
        public static Game INSTANCE = new Game();


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

		public void start()
		{
			this.turn.init();
		}

        public void next()
        {
			this.turn.next();
			this.turns_left--;
            throw new NotImplementedException();
        }

		public bool isFinished()
		{
			return this.turns_left == 0 || this.player1.units.Count() == 0 || this.player2.units.Count() == 0;
        }

		public PlayerAPI getWinner()
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



		public List<UnitAPI> getUnits(int x, int y)
		{
			List<UnitAPI> list = new List<UnitAPI>();

			for (int i = 0; i < this.player1.units.Count; i++)
			{
				if (this.player1.units[i].x == x && this.player1.units[i].y == y)
				{
					list.Add(this.player1.units[i]);
				}
			}
			if (list.Count() != 0)
				return list;

			for (int i = 0; i < this.player2.units.Count; i++)
			{
				if (this.player2.units[i].x == x && this.player2.units[i].y == y)
				{
					list.Add(this.player2.units[i]);
				}
			}

			return list;
		}

	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace dev
{
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

		public void save()
        {
			XmlSerializer xs = new XmlSerializer(typeof(Game));
			using (StreamWriter wr = new StreamWriter("person.xml"))
			{
				xs.Serialize(wr, this);
			}
			BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("save.dat", FileMode.Create, FileAccess.Write);
			formatter.Serialize(fileStream, this);
			fileStream.Close();

		}

		public UnitAPI getUnit(int x, int y)
		{
			for (int i = 0; i < this.player1.units.Count; i++)
			{
				if (this.player1.units[i].x == x && this.player1.units[i].y == y)
				{
					return this.player1.units[i];
				}
			}
			for (int i = 0; i < this.player2.units.Count; i++)
			{
				if (this.player2.units[i].x == x && this.player2.units[i].y == y)
				{
					return this.player2.units[i];
				}
			}

			return null;
		}
	}
}
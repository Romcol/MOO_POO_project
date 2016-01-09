using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
	[Serializable()]
	public class Player : PlayerAPI
    {
		public string name { get; set; }

		public Race race { get; set; }

		public List<UnitAPI> units { get; set; }

		public Player(string name, Race race)
		{
			this.name = name;
			this.race = race;
            this.units = new List<UnitAPI>();
            this.victoryPoints = 0;
		}

        public int victoryPoints { get; set; }
    }
}
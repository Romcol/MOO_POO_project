using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public class Player : PlayerAPI
    {
		public string name { get; set; }

		public Race race { get; set; }

		public List<UnitAPI> units { get; set; }

		public Player(string name, Race race)
		{
			this.name = name;
			this.race = race;
		}

        void PlayerAPI.getVictoryPoints()
        {
            throw new NotImplementedException();
        }
    }
}
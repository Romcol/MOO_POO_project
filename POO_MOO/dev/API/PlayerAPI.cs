using dev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public interface PlayerAPI
    {
		/// <summary>
		/// Units of a player
		/// </summary>
        List<UnitAPI> units { get; set; }

		/// <summary>
		/// Race of the 
		/// </summary>
		Race race { get; set; }
		string name { get; set; }
        void getVictoryPoints();
    }
}

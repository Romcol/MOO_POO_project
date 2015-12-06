using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public interface PlayerAPI
    {
        List<UnitAPI> units { get; set; }

		string race { get; set; }

		string name { get; set; }
        void getVictoryPoints();
    }
}

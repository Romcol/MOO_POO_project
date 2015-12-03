using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public interface PlayerAPI
    {
        List<UnitAPI> Units { get; set; }

        void getVictoryPoints();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public class Player : API.PlayerAPI
    {
        List<UnitAPI> PlayerAPI.Units
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        void PlayerAPI.getVictoryPoints()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Player : PlayerAPI
    {
        public string race
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
        public string name
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public UnitAPI UnitAPI
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
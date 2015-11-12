using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Attack : Action, Undoable
    {

        public Unit playerUnitClone
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Unit attackedUnitClone
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void cando()
        {
            throw new System.NotImplementedException();
        }

        public void doit()
        {
            throw new System.NotImplementedException();
        }
    }
}
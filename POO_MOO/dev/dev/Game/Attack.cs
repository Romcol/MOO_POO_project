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

        void Undoable.undo()
        {
            throw new NotImplementedException();
        }

        void Undoable.redo()
        {
            throw new NotImplementedException();
        }
    }
}
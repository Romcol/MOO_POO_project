using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Move : Action, Undoable
    {
        public int x
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int y
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

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
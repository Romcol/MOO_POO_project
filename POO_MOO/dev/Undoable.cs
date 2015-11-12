using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public interface Undoable
    {

        public void undo()
        {
            throw new System.NotImplementedException();
        }

        public void redo()
        {
            throw new System.NotImplementedException();
        }
    }
}
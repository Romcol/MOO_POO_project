using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public interface ActionAPI
    {
        bool cando();
        void doit();

		void undo();
    }
}
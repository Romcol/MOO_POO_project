using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public abstract class Action : ActionAPI
    {
        public abstract bool cando();

        public abstract void doit();
    }
}
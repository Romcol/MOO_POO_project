using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Action
    {

        public abstract void doit();
        public abstract bool cando()
        {
            throw new System.NotImplementedException();
        }
    }
}
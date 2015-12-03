using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public abstract class Action : API.ActionAPI
    {
        bool ActionAPI.cando()
        {
            throw new NotImplementedException();
        }

        void ActionAPI.doit()
        {
            throw new NotImplementedException();
        }
    }
}
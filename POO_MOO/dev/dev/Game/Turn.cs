using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public class Turn : API.TurnAPI
    {
        List<ActionAPI> TurnAPI.Actions
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

        void TurnAPI.addAction(System.Action a)
        {
            throw new NotImplementedException();
        }

        void TurnAPI.init()
        {
            throw new NotImplementedException();
        }

        void TurnAPI.undo()
        {
            throw new NotImplementedException();
        }
    }
}
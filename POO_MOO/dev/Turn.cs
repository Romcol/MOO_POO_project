using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Turn:TurnAPI
    {
        public List<Action> listAction
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        ActionAPI TurnAPI.ActionAPI
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

        public void addAction(Action a)
        {
            throw new System.NotImplementedException();
        }
    }
}
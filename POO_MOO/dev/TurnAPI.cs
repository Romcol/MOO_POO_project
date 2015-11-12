using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public interface TurnAPI
    {
        List<ActionAPI> Actions { get; set; }

        void addAction(Action a);
        void undo();
        void init();
    }
}
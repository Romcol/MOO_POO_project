using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public interface TurnAPI
    {
        Stack<ActionAPI> actions { get; set; }

		PlayerAPI currentPlayer { get; set; }
        void addAction(ActionAPI a);
        void undo();

		void next();
		void init();


    }
}
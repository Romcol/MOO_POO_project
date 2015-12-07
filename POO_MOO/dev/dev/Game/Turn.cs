using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public class Turn : TurnAPI
    {
		public PlayerAPI currentPlayer
		{
			get;
			set;
		}

		public Stack<ActionAPI> actions
        {
			get;
			set;
        }

        public void addAction(ActionAPI	a)
        {
			this.actions.Push(a);
        }

        public void init()
        {
			this.actions.Clear();
            if(this.currentPlayer == Game.INSTANCE.player1)
			{
				this.currentPlayer = Game.INSTANCE.player2;
			} else
			{
				this.currentPlayer = Game.INSTANCE.player1;
			}
        }

        public void undo()
        {
			ActionAPI action = this.actions.Pop();
			action.undo();
			throw new NotImplementedException();
        }
		
    }
}
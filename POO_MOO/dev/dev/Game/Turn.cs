﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
	[Serializable()]
	public class Turn : TurnAPI
    {
		/// <summary>
		///  Current player
		/// </summary>
		public PlayerAPI currentPlayer
		{
			get;
			set;
		}

		/// <summary>
		///  Stack of actions performed during the turn
		/// </summary>
		public Stack<ActionAPI> actions
        {
			get;
			set;
        }

		/// <summary>
		///  Adds an action performed during the turn
		/// </summary>
		public void addAction(ActionAPI	a)
        {
			this.actions.Push(a);
        }

		/// <summary>
		///  init the first turn of the game, choose a player randomly
		/// </summary>
		public void init()
        {
			if(this.actions != null) this.actions.Clear();

			Random rnd = new Random(DateTime.Now.Millisecond);
			int rand = rnd.Next(0,2);

			if(rand == 0)
			{
				this.currentPlayer = Game.INSTANCE.player1;
			}
			else
			{
				this.currentPlayer = Game.INSTANCE.player2;
			}

        }

		/// <summary>
		///  changes the turn of the game
		/// </summary>
		public void next()
		{
			if(actions != null) actions.Clear();
			if (this.currentPlayer == Game.INSTANCE.player1)
			{
				this.currentPlayer = Game.INSTANCE.player2;
			}
			else
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
 
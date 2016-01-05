using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
	/// <summary>
	/// Interface representing a Game (global object of the game)
	/// </summary>
    public interface GameAPI
    {
		/// <summary>
		/// First player of the game
		/// </summary>
        PlayerAPI player1 { get; set; }

		/// <summary>
		/// Second player of the game
		/// </summary>
        PlayerAPI player2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
        MapAPI map { get; set; }

		/// <summary>
		/// Number of remaining turns before the end of the game
		/// </summary>
		int turns_left { get; set; }

		/// <summary>
		/// current turn
		/// </summary>
        TurnAPI turn { get; set; }

		/// <summary>
		/// Tells if the game is finished
		/// </summary>
		/// <returns>A boolean saying if the game is finished or not</returns>
		bool isFinished();

		/// <summary>
		/// Returns the winner of the game
		/// </summary>
		/// <returns>The player who won the game</returns>
		PlayerAPI getWinner();


		void load();

		/// <summary>
		/// Go to the next turn
		/// </summary>
		void next();

		/// <summary>
		/// Starts the game
		/// </summary>
		void start();

		void save();
    }
}

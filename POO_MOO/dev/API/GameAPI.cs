using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public interface GameAPI
    {
        PlayerAPI player1 { get; set; }
        PlayerAPI player2 { get; set; }
        MapAPI map { get; set; }
		int turns_left { get; set; }
        TurnAPI turn { get; set; }

		bool isFinished();
		PlayerAPI getWinner();

		void load();
        void next();
        void save();
    }
}

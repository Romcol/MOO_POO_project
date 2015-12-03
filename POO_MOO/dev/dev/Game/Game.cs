using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public class Game : GameAPI
    {
        public static Game INSTANCE = new Game();

        private Game()
        {

        }

        public int turns_left {
            get;
            set;
        }
        
        public MapAPI map
        {
            get;
            set;
        }

        public PlayerAPI player1
        {
            get;
            set;
        }

        public PlayerAPI player2
        {
            get;
            set;
        }

        public TurnAPI turn
        {
            get;
            set;
        }



        void GameAPI.load()
        {
            throw new NotImplementedException();
        }

        void GameAPI.next()
        {
            throw new NotImplementedException();
        }

        void GameAPI.save()
        {
            throw new NotImplementedException();
        }
    }
}
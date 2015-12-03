using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace dev
{
    public class Game : API.GameAPI
    {
        public static Game INSTANCE = new Game();

        private Game()
        {

        }

        public int turnsLeft {
            get;
            set;
        }
        
        public MapAPI Map
        {
            get;
            set;
        }

        PlayerAPI GameAPI.Player1
        {
            get;
            set;
        }

        PlayerAPI GameAPI.Player2
        {
            get;
            set;
        }

        TurnAPI GameAPI.TurnAPI
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
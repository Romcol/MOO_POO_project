using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev
{
    public class Game : GameAPI
    {

        public int turnsLeft
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
        public bool cheatMode
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int currentPlayer
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Turn Turn
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        PlayerAPI GameAPI.Player1
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

        PlayerAPI GameAPI.Player2
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

        MapAPI GameAPI.Map
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

        public void next()
        {
            throw new System.NotImplementedException();
        }

        public static void save()
        {
            throw new System.NotImplementedException();
        }

        public static void load()
        {
            throw new System.NotImplementedException();
        }
    }
}
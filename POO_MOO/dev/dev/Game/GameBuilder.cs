using API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace dev
{
    public class GameBuilder
    {

		private const string FILE_SAVE = "save.dat";

		public Game game = new Game();
		public GameBuilder()
        {
            this.game = new Game();
        }
		public void setPlayer1(string name, Race race)
		{
			this.game.player1 = new Player(name, race);
		}

		public void setPlayer2(string name, Race race)
		{
			this.game.player2 = new Player(name, race);
		}
		
		public GameAPI createMap(string map_type)
		{
			if (this.game.player1 == null || this.game.player2 == null)
			{
				throw new Exception("Players must be initialized before the map filling.");
			}

			MapTilesFactory factory = new MapTilesFactory(map_type);
			this.game.map = factory.createMap(this.game);
			this.game.turns_left = factory.map_strategy.nb_turns;

			Game.INSTANCE = this.game;

			return game;
		}

		public void save(string file)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, this.game);
			stream.Close();
		}
		public GameAPI load(string file)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
			Game ret = (Game)formatter.Deserialize(stream);
			stream.Close();

			return ret;
		}
	}
}
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using IHM.MVVM.Infra;
using System.Windows;
using IHM.MVVM.Views;
using dev;
using API;

namespace IHM.MVVM.ViewModels
{
    /// <summary>
    /// VueModele principale
    /// </summary>
    public class StartupViewModel : ViewModelBase
    {

        public string p1Name
		{
			get; set;
		}
		public string p2Name
		{
			get; set;
		}
		public Race p1Race
		{
			get; set;
		}
		public Race p2Race
		{
			get; set;
		}

		public MapType map_type
		{
			get; set;
		}
		/// <summary>
		/// Constructeur de la VueModele pricipale
		/// </summary>
		public StartupViewModel()
        {
			
            /*engine = new Cours.Engine.Engine();
            map = engine.GetMap();

            // création pour chaque tuile de sa VueModele associée 'TileViewModel'
            for (int l = 0; l < map.Height; l++)
            {
                for (int c = 0; c < map.Width; c++)
                {
                    tiles.Add(new TileViewModel(l, c, map.Tiles[c, l]));
                }
            }
            updateUnit();*/
        }

		private ICommand play;
		public ICommand Play
		{
			get
			{
				;
				if (play == null)
					play = new RelayCommand(playAction);
				return play;
			}
		}
		private ICommand load;
		public ICommand Load
		{
			get
			{
				if (load == null)
					load = new RelayCommand(loadAction);
				return load;
			}
		}

		private void playAction()
        {

			if (p1Name == "" || p2Name == "" || p1Name == null || p2Name == null)
			{
				MessageBox.Show("You must type your names."); return;
			}
			if (p1Name == p2Name)
			{
				MessageBox.Show("You must choose different names."); return;
			}
			if (p1Race == p2Race)
			{
				MessageBox.Show("You must choose different races."); return;
			}

			GameBuilder builder = new GameBuilder();
			builder.setPlayer1(p1Name, p1Race);
			builder.setPlayer2(p2Name, p2Race);
			GameAPI game = builder.createMap(map_type);
            game.start();
			Views.MainWindow.launchGame(game);
        }

		private void loadAction()
		{

			GameBuilder builder = new GameBuilder();
			GameAPI game = builder.load("save.dat");
			if(game==null)
			{
				MessageBox.Show("No game saved."); return;
			}
			Views.MainWindow.launchGame(game);
		}


	}
}

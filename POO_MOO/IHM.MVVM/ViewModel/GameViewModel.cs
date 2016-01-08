using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using IHM.MVVM.Infra;
using System.Windows;
using API;
using dev;
using System;

namespace IHM.MVVM.ViewModels
{
    /// <summary>
    /// VueModele principale
    /// </summary>
    public class GameViewModel : ViewModelBase
    {
        GameAPI game;
        /// <summary>
        /// Constructeur de la VueModele pricipale
        /// </summary>
        public GameViewModel(GameAPI game)
        {
            this.game = game;
            for (int l = 0; l < game.map.size; l++)
            {
                for (int c = 0; c < game.map.size; c++)
                {
                    tiles.Add(new TileViewModel(l, c, game.map.tiles[c, l]));
                }
            }

            /*
            updateUnit();*/
        }

        /// <summary>
        /// Mise à jour de l'unité
        /// Principe : une unité est associée à une tuile
        /// </summary>
        private void updateUnit()
        {
           /* var unit = engine.GetUnit();
            // on enlève l'unité de son ancienne tuile
            var tile = tiles.FirstOrDefault(t => t.HasUnit);
            if (tile != null)
                tile.HasUnit = false;
            // on positionne l'unité sur sa nouvelle tuile
            tile = tiles.FirstOrDefault(t => t.Row == unit.Row && t.Column == unit.Column);
            tile.HasUnit = true;*/
        }
        /// <summary>
        /// Mise à jour des Tuiles : les resources en fer peuvent diminuer à chaque Tour
        /// </summary>
        private void updateTiles()
        {
            foreach (var tile in tiles)
                tile.Refresh();
        }
        /// <summary>
        /// Acces à la largeur de la map
        /// </summary>
        public int Width
        {
            get; set;
        }
        /// <summary>
        /// Acces à la liste des Tuiles
        /// </summary>
        List<TileViewModel> tiles = new List<TileViewModel>();
        public IEnumerable<TileViewModel> Tiles
        {
            get { return tiles; }
        }


        /// <summary>
        /// reaction à selectedTile
        /// </summary>
        private TileViewModel selectedTile;
        public TileViewModel SelectedTile
        {
            get { return selectedTile; }
            set
            {
                if (selectedTile != null)
                    selectedTile.IsSelected = false;
                selectedTile = value;
                if (selectedTile != null)
                    selectedTile.IsSelected = true;
                RaisePropertyChanged("SelectedTile");
            }
        }

		private ICommand nextTurn;
		public ICommand NextTurn
		{
			get
			{
				if (nextTurn == null)
					nextTurn = new RelayCommand(nextTurnAction);
				return nextTurn;
			}
		}



		private void nextTurnAction()
        {
            // création d'un thread pour lancer le calcul du tour suivant sans que cela soit bloquant pour l'IHM
            Task.Factory.StartNew(() =>
            {
                /*engine.NextTurn();
                updateUnit();  // les appels sont implicitment fait dans le bon thread dans le modèle MVVM
                updateTiles();
                Message = "Prochain tour";*/
            });
        }

		private ICommand save;
		public ICommand Save
		{
			get
			{
				if (save == null)
					save = new RelayCommand(saveAction);
				return save;
			}
		}
		private void saveAction()
		{
			GameBuilder builder = new GameBuilder();
			try
			{
				builder.save("save.dat");
			} catch(Exception e)
			{
				MessageBox.Show("Error while saving the game.");
			}
			
		}

		string message;
        public string Message
        {
            get { return message; }
            set
            {
                if (message == value)
                    return;
                message = value;
                RaisePropertyChanged("Message");
            }
        }
    }
}

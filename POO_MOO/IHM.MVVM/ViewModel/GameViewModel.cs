using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using IHM.MVVM.Infra;
using System.Windows;
using API;
using dev;
using System;
using IHM.MVVM.ViewModel;

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
                    tiles.Add(new TileViewModel(game.getUnits(c,l), this,l, c, game.map.tiles[c, l]));
                }
            }
            this.p1Race = game.player1.race;
            this.p2Race = game.player2.race;
            updateUnit();
            updateInfos();
            this.SelectedTile = tiles.ElementAt(game.turn.currentPlayer.units.FirstOrDefault().x + game.map.size*game.turn.currentPlayer.units.FirstOrDefault().y);
            //updateTiles();
        }

        public int TurnsLeft { get; private set; }

        public Race p1Race { get; private set; }

        public Race p2Race { get; private set; }

        public int p1Units { get; private set; }

        public int p2Units { get; private set; }

        public bool isP1Turn { get; private set; }

        public bool isP2Turn { get; private set; }

        private void updateInfos()
        {
            this.p1Units = game.player1.units.Count;
            this.p2Units = game.player2.units.Count;
            this.isP1Turn = (game.player1 == game.turn.currentPlayer);
            this.isP2Turn = (game.player2 == game.turn.currentPlayer);
            this.TurnsLeft = game.turns_left;
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
             tile.HasUnit = true; tile.hasElf= true; tile.hasOrc = tile.hasHuman*/

            for (int i = 0; i < tiles.Count(); i++)
            {
                TileViewModel tile = Tiles.ElementAt(i);
                UnitAPI unit = game.getUnits(tile.Row, tile.Column).FirstOrDefault();
                tile.CurrentUnit = unit;
            }
            
        }
        /// <summary>
        /// Mise à jour des Tuiles : les resources en fer peuvent diminuer à chaque Tour
        /// </summary>
        private void updateTiles()
        {
            for (int l = 0; l < game.map.size; l++)
            {
                for (int c = 0; c < game.map.size; c++)
                {
                    tiles.ElementAt(l + c * game.map.size).Refresh(game.getUnits(c, l));
                }
            }
            /*
            foreach (var tile in tiles)
            {
                tile.Refresh();
            }*/
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

        private UnitAPI selectedUnit;

        private void updateSUnit()
        {
            this.selectedUnit = SelectedTile.CurrentUnit;
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
                this.updateSUnit();
            }
        }

        public SelectedUnitViewModel memUnit;

        public SelectedUnitViewModel MemUnit
        {
            get { return memUnit; }
            set { this.memUnit = value; RaisePropertyChanged("MemUnit"); }
        }

        private ICommand select;
        public ICommand Select
        {
            get
            {
                if (select == null)
                    select = new RelayCommand(selectAction);
                return select;
            }
        }

        private void selectAction()
        {
            if (selectedUnit != null)
            {
                if (selectedUnit.getPlayer() == game.turn.currentPlayer)
                {
                    this.MemUnit = new SelectedUnitViewModel(selectedUnit);
                    RaisePropertyChanged("MemUnit");
                }
                else
                {
                    MessageBox.Show("Unit selection not allowed");
                }
            }
            else
            {
                MessageBox.Show("No unit to select");
            }
            // création d'un thread pour lancer le calcul du tour suivant sans que cela soit bloquant pour l'IHM
            Task.Factory.StartNew(() =>
            {
            });
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

		/*string message;
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
        }*/
    }
}

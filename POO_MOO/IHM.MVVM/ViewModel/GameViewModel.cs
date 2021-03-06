﻿using System.Collections.Generic;
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
                    tiles.Add(new TileViewModel(game.getUnits(l,c), this, l, c, game.map.tiles[l, c]));
                }
            }
            this.p1Race = game.player1.race;
            this.p2Race = game.player2.race;
            this.p1Name = game.player1.name;
            this.p2Name = game.player2.name;
            updateTiles();
            this.Refresh();
            this.SelectedTile = tiles.ElementAt(game.turn.currentPlayer.units.FirstOrDefault().x + game.map.size*game.turn.currentPlayer.units.FirstOrDefault().y);
        }

        public String p1Name { get; private set; }
        public String p2Name { get; private set; }

        public int TurnsLeft { get; private set; }

        public Race p1Race { get; private set; }

        public Race p2Race { get; private set; }

        public int p1Pts { get; private set; }

        public int p2Pts { get; private set; }

        public int p1Units { get; private set; }

        public int p2Units { get; private set; }

        public bool isP1Turn { get; private set; }

        public bool isP2Turn { get; private set; }

        private void Refresh()
        {
            this.p1Units = game.player1.units.Count;
            this.p2Units = game.player2.units.Count;
            this.isP1Turn = (game.player1 == game.turn.currentPlayer);
            this.isP2Turn = (game.player2 == game.turn.currentPlayer);
            this.TurnsLeft = game.turns_left;
            this.p1Pts = game.player1.victoryPoints;
            this.p2Pts = game.player2.victoryPoints;
            RaisePropertyChanged("p1Pts");
            RaisePropertyChanged("p2Pts");
            RaisePropertyChanged("p1Units");
            RaisePropertyChanged("p2Units");
            RaisePropertyChanged("isP1Turn");
            RaisePropertyChanged("isP2Turn");
            RaisePropertyChanged("TurnsLeft");
        }

        private void updateTiles()
        {
            for (int l = 0; l < game.map.size; l++)
            {
                for (int c = 0; c < game.map.size; c++)
                {
                    TileViewModel tile = tiles.ElementAt(c + l * game.map.size);
                    tile.Refresh(game.getUnits(l,c), game.getUnits(l,c).FirstOrDefault());

                }
            }
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

        private SelectedUnitViewModel memUnit;

        public SelectedUnitViewModel MemUnit
        {
            get { return memUnit; }
            set { this.memUnit = value; RaisePropertyChanged("MemUnit"); RaisePropertyChanged("hasMemUnit"); }
        }

        public bool hasMemUnit
        {
            get { return (MemUnit != null); }
        }

        public bool isOneOfMyUnitsSelected(List<UnitAPI> tileUnits)
        {
            return tileUnits.Any(t => (hasMemUnit &&  (t == MemUnit.getUnit())));
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
                    updateTiles();
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
            game.next();
            this.Refresh();
            this.isFinished();
        }

        private ICommand doAction;
        public ICommand DoAction
        {
            get
            {
                if (doAction == null)
                    doAction = new RelayCommand(doActionAction);
                return doAction;
            }
        }

        private void doActionAction()
        {
            if (MemUnit != null && (MemUnit.getUnit().getPlayer() == game.turn.currentPlayer))
            {
                UnitAPI currunit = memUnit.getUnit();
                if (SelectedTile.getEnemy() != null)
                {
                    if (currunit.canAttack(SelectedTile.getEnemy()))
                    {
                        UnitAPI loser = currunit.attack(SelectedTile.getEnemy());
                        MessageBox.Show(loser.getPlayer().name + " loses the battle!");
                        if(loser.lifePoints <= 0)
                        {
                            MessageBox.Show(loser.getPlayer().name + " is dead!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Attack action not possible");
                    }
                }
                else {
                    if (currunit.canMove(SelectedTile.X, SelectedTile.Y))
                    {
                        currunit.move(SelectedTile.X, SelectedTile.Y);
                    }
                    else
                    {
                        MessageBox.Show("Move action not possible");
                    }
                }
                //Global Refresh
                memUnit.Refresh();
                updateTiles();
                this.Refresh();
            }
            else
            {
                MessageBox.Show("No unit selected");
            }
            this.isFinished();
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
				MessageBox.Show("The game has been saved.");
			} catch(Exception e)
			{
				MessageBox.Show("Error while saving the game.");
			}
			
		}
        private void isFinished()
        {
            if(game.isFinished())
            {
                PlayerAPI player = game.getWinner();
                if (player == null)
                {
                    MessageBox.Show("Nobody wins!");
                }
                else {
                    MessageBox.Show(player.name + " wins!");
                }
                Views.GameWindow.goToStartup();
            }
        }
    }
}

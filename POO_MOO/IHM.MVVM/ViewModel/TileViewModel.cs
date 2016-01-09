using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dev;
using API;
using IHM.MVVM.Infra;

namespace IHM.MVVM.ViewModels
{
    public class TileViewModel : ViewModelBase
    {
        private TileAPI tile;
        private GameViewModel gameView;
        private List<UnitAPI> tileUnits { get; set; }
        public TileViewModel(List<UnitAPI> tileUnits, GameViewModel gameView, int x, int y, TileAPI tile)
        {
            this.tile = tile;
            this.gameView = gameView;
            this.tileUnits = tileUnits;
            if (tile is Plain)
            {
                Type = "Terre";
                Color = "Wheat";
            }
            if (tile is Forest)
            {
                Type = "Forêt";
                Color = "ForestGreen";
            }
            if (tile is Water)
            {
                Type = "Water";
                Color = "DarkBlue";
            }
            if (tile is Mountain)
            {
                Type = "Moutain";
                Color = "Brown";
            }
            X = x;
            Y = y;
        }


        public string Color { get; private set; }
        public string Type { get; private set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        UnitAPI currentUnit;
        public UnitAPI CurrentUnit
        {
            get { return currentUnit; }
            set
            {
                currentUnit = value;
                RaisePropertyChanged("CurrentUnit");
                RaisePropertyChanged("AttackPoints");
                RaisePropertyChanged("DefencePoints");
                RaisePropertyChanged("LifePoints");
                RaisePropertyChanged("MovePoints");
            }
        }

        public double MovePoints { get { return (currentUnit != null) ? currentUnit.movePoints : 0; } }
        public double AttackPoints { get { return (currentUnit != null) ? currentUnit.attackPoints : 0; } }
        public double DefencePoints { get { return (currentUnit != null) ? currentUnit.defencePoints : 0; } }
        public double LifePoints { get { return (currentUnit != null) ? currentUnit.lifePoints : 0; } }

        public bool HasUnitSelected { get { return gameView.isOneOfMyUnitsSelected(tileUnits); } }

        public bool HasElf
        {
            get { return (tileUnits.FirstOrDefault() != null && tileUnits.FirstOrDefault().getRace() == Race.Elf); }
        }

        public bool HasOrc
        {
            get { return (tileUnits.FirstOrDefault() != null && tileUnits.FirstOrDefault().getRace() == Race.Orc); }
        }
        public bool HasHuman
        {
            get { return (tileUnits.FirstOrDefault() != null && tileUnits.FirstOrDefault().getRace() == Race.Human); }
        }

        public int tileNbUnits
        {
            get { return tileUnits.Count(); }
        }

        public bool HasUnits
        {
            get { return (tileUnits.Count() >0); }
        }

        bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }

        /// <summary>
        /// signal que les tuiles ont pu changer d'état via la resource 'fer'
        /// </summary>
        internal void Refresh(List<UnitAPI> tileUnits, UnitAPI currentUnit)
        {
            this.tileUnits = tileUnits;
            this.CurrentUnit = currentUnit;
            RaisePropertyChanged("HasElf");
            RaisePropertyChanged("HasOrc");
            RaisePropertyChanged("HasHuman");
            RaisePropertyChanged("tileNbUnits");
            RaisePropertyChanged("HasUnits");
            RaisePropertyChanged("HasUnitSelected");
        }
    }
}

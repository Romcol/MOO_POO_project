using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dev;
using IHM.MVVM.NewModels;
using API;

namespace IHM.MVVM.ViewModels
{
    public class TileViewModel : ViewModelBase
    {
        private TileAPI tile;

        public TileViewModel(int row, int column, TileAPI tile)
        {
            this.tile = tile;

            if (tile is Plain)
            {
                Type = "Terre";
                Color = "Brown";
            }
            if (tile is Forest)
            {
                Type = "Forêt";
                Color = "DarkGreen";
            }
            if (tile is Water)
            {
                Type = "Mer";
                Color = "SlateBlue";
            }

            Row = row;
            Column = column;
        }


        public string Color { get; private set; }
        public string Type { get; private set; }

        public int Row { get; private set; }
        public int Column { get; private set; }

        bool hasUnit;
        public bool HasUnit
        {
            get { return hasUnit; }
            set
            {
                hasUnit = value;
                RaisePropertyChanged("HasUnit");
            }
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
        internal void Refresh()
        {
            RaisePropertyChanged("Iron");
        }
    }
}

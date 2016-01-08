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
        public TileViewModel(int row, int column, TileAPI tile)
        {
            this.tile = tile;

            if (tile is Plain)
            {
                Type = "Terre";
                Color = "PaleGreen";
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
            if(tile is Mountain)
            {
                Type = "Moutain";
                Color = "Brown";
            }
            Row = row;
            Column = column;
        }


        public string Color { get; private set; }
        public string Type { get; private set; }

        public int Row { get; private set; }
        public int Column { get; private set; }

        bool hasElf;
        public bool HasElf
        {
            get { return hasElf; }
            set
            {
                hasElf = value;
                RaisePropertyChanged("HasElf");
            }
        }

        bool hasOrc;
        public bool HasOrc
        {
            get { return hasOrc; }
            set
            {
                hasOrc = value;
                RaisePropertyChanged("HasElf");
            }
        }

        bool hasHuman;
        public bool HasHuman
        {
            get { return hasHuman; }
            set
            {
                hasHuman = value;
                RaisePropertyChanged("HasHuman");
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

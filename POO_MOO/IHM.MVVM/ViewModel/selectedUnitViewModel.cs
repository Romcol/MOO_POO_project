using API;
using dev;
using IHM.MVVM.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM.MVVM.ViewModel
{
    public class SelectedUnitViewModel : ViewModelBase
    {
        private UnitAPI unit;

        public SelectedUnitViewModel(UnitAPI unit)
        {
            this.unit = unit;
            this.Refresh();
        }

        public void Refresh()
        {
            RaisePropertyChanged("xUnit");
            RaisePropertyChanged("yUnit");
            RaisePropertyChanged("isHuman");
            RaisePropertyChanged("isOrc");
            RaisePropertyChanged("isElf");
            RaisePropertyChanged("raceUnit");
        }
        public UnitAPI getUnit()
        {
            return unit;
        }
        public int xUnit
        {
            get { return unit.x; }
        }
        public int yUnit
        {
            get { return unit.y; }
        }
        public Race raceUnit
        {
            get { return unit.getRace(); }
        }

        public bool isHuman
        {
            get { return (unit.getRace() == Race.Human); }
        }

        public bool isElf
        {
            get { return (unit.getRace() == Race.Elf); }
        }

        public bool isOrc
        {
            get { return (unit.getRace() == Race.Orc); }
        }
    }
}

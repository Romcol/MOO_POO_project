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
            RaisePropertyChanged("xUnit");
            RaisePropertyChanged("yUnit");
            RaisePropertyChanged("raceUnit");
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
    }
}

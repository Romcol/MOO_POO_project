using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using IHM.MVVM.Infra;
using System.Windows;

namespace IHM.MVVM.ViewModels
{
    /// <summary>
    /// VueModele principale
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public string p1Name
		{
			get; set;
		}
        public string p2Name {
			get; set;
		}

        /// <summary>
        /// Constructeur de la VueModele pricipale
        /// </summary>
        public MainViewModel()
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
            {;
				if (play == null)
                    play = new RelayCommand(playAction);
                return play;
            }
        }

        private void playAction()
        {
			// création d'un thread pour lancer le calcul du tour suivant sans que cela soit bloquant pour l'IHM
			Task.Factory.StartNew(() =>
            {
                /* engine.NextTurn();
                 updateUnit();  // les appels sont implicitment fait dans le bon thread dans le modèle MVVM
                 updateTiles();
                 Message = "Prochain tour";
             });*/
            });
        }

    }
}

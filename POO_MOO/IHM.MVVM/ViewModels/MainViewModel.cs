using IHM.MVVM.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API;
using dev;
using IHM.MVVM.Infrastructure;

namespace IHM.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        GameBuilder gameBuilder;
        GameAPI game;
        /// <summary>
        /// Constructeur de la VueModele pricipale
        /// </summary>
        /*public MainViewModel()
        {
            gameBuilder = new GameBuilder();
            gameBuilder.setPlayer1("john", Race.Orc);
            gameBuilder.setPlayer2("luc", Race.Human);
            game = gameBuilder.createMap("small");

            // création pour chaque tuile de sa VueModele associée 'TileViewModel'
            for (int l = 0; l < game.map.size; l++)
            {
                for (int c = 0; c < game.map.size; c++)
                {
                    tiles.Add(new TileViewModel(l, c, game.map.tiles[c, l]));
                }
            }
            //updateUnit();
        }
    }*/
        /// <summary>
        /// Mise à jour de l'unité
        /// Principe : une unité est associée à une tuile
        /// </summary>

    }
}

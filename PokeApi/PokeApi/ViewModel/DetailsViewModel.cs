using PokeApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PokeApi.ViewModel
{
    public class DetailsViewModel : BaseViewModel
    {
        private static DetailsViewModel _instance = new DetailsViewModel();
        public static DetailsViewModel Instance { get { return _instance; } }

        public PokemonModel _selectedPokemon;
        public PokemonModel SelectedPokemon
        {
            get { return _selectedPokemon; }
            set { _selectedPokemon = value;
                OnPropertyChanged();
                    }
        }

        public DetailsViewModel()
        {
            
        }
    }
}
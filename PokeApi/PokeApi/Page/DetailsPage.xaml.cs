using PokeApi.Model;
using PokeApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeApi.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {

        public DetailsPage(PokemonModel selectedPokemon)
        {
            InitializeComponent();
            BindingContext = DetailsViewModel.Instance;

            DetailsViewModel.Instance.SelectedPokemon = selectedPokemon;

        }
    }
}
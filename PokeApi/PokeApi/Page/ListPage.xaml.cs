using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeApiNet;
using PokeApi.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApi.Model;

namespace PokeApi.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = ListViewModel.Instance;
        }

        /*
        private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPokemon = e.CurrentSelection as PokemonModel;

            await Navigation.PushAsync(new DetailsPage());
        }*/
    }
}
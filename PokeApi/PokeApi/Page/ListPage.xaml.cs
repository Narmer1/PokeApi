using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeApiNet;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeApi.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        /*
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            PokeApiClient pokeClient = new PokeApiClient();


            for (int i = 1; i < 21; i++)
            {

                Pokemon pokemon = await Task.Run(() => pokeClient.GetResourceAsync<Pokemon>(i));
                Debug.WriteLine(pokemon.Name);
            }
        }
        */
    }
}

using PokeApi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PokeApi.ViewModel
{
    public class PokemonsViewModel : BaseViewModel
    {

        private static PokemonsViewModel _instance = new PokemonsViewModel();
        public static PokemonsViewModel Instance { get { return _instance; } }

        public ObservableCollection<Pokemon> Items
        {
            get { return GetValue<ObservableCollection<Pokemon>>(); }
            set { SetValue(value); }
        }
        public PokemonsViewModel()
        {
            /*
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
            */
        }
    }
}
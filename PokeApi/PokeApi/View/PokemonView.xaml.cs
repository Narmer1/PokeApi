using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeApi.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeApi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonView : ContentView
    {
        public PokemonView()
        {
            InitializeComponent();
            BindingContext = new PokemonViewModel();
        }
    }
}

using PokeApi.ViewModel;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeApi.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPokemon : ContentPage
    {
        public AddPokemon()
        {
            InitializeComponent();
            BindingContext = AddPokemonViewModel.Instance;
        }


    }
}
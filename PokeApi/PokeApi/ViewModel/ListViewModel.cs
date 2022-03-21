using PokeApi.Model;
using PokeApi.Page;
using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokeApi.ViewModel
{
    public class ListViewModel : BaseViewModel
    {
        private const int NUMBEROFPOKEMONS = 51;

        private static ListViewModel _instance = new ListViewModel();
        public static ListViewModel Instance { get { return _instance; } }

        public PokemonModel _selectedPokemon;
        public PokemonModel SelectedPokemon { get { return _selectedPokemon; }
            set 
            {
                _selectedPokemon = value;

                Application.Current.MainPage.Navigation.PushAsync(new DetailsPage(_selectedPokemon));
            }
        }
        public ObservableCollection<PokemonModel> ListPokemonModels
        {
            get { return GetValue<ObservableCollection<PokemonModel>>(); }
            set { SetValue(value); }
        }

        
        public ListViewModel()
        {
            ListPokemonModels = new ObservableCollection<PokemonModel>();
            InitializationList();
        }

        public async void InitializationList()
        {
            //si pas async ou await, l'appli se coupe pour redémarrer
            PokApiDataBase pokApiDataBase = await PokApiDataBase.Instance;

            if (pokApiDataBase.isEmpty().Result)
                CreatePokApiDataBase();
            else
                getListFromPokApiDataBase();
        }

        //tout ce qui touche à la database => async
        public async void getListFromPokApiDataBase()
        {
            PokApiDataBase pokApiDataBase = await PokApiDataBase.Instance;
            List<PokemonModel> listPokemonModelsLocal = await pokApiDataBase.GetPokemonModelsAsync();

            foreach(PokemonModel pokemonModel in listPokemonModelsLocal)
            {
                ListPokemonModels.Add(pokemonModel);
            }
        }

        public async void CreatePokApiDataBase()
        {
            PokApiDataBase pokApiDataBase = await PokApiDataBase.Instance;
            PokeApiClient pokeApiClient = new PokeApiClient();
            string futureType2 = "";

            for (int i = 1;i < NUMBEROFPOKEMONS; i++)
            {
                Pokemon pokemon = await Task.Run(() => pokeApiClient.GetResourceAsync<Pokemon>(i));
                if (pokemon.Types.Count > 1)
                {
                    futureType2 = pokemon.Types[1].Type.Name;
                }

                PokemonModel pokemonModel = new PokemonModel
                {
                    Name = pokemon.Name,
                    IDPokedex = pokemon.Id,
                    DefaultSprite = pokemon.Sprites.FrontDefault,
                    Type1 = pokemon.Types[0].Type.Name,
                    Type2 = futureType2,
            };
                await pokApiDataBase.SaveItemAsync(pokemonModel);
            }
            getListFromPokApiDataBase();
        }

       
    }
}
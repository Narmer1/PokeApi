using PokeApi.Model;
using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PokeApi.ViewModel
{
    public class AddPokemonViewModel : BaseViewModel
    {
        private static AddPokemonViewModel _instance = new AddPokemonViewModel();
        public static AddPokemonViewModel Instance { get { return _instance; } }

        public PokemonModel pokemonAdded { get; set; }
        public ICommand AddPokemonCommand { get; }
        public ICommand PickImageCommand { get; }

        public ObservableCollection<string> ListTypes
        {
            get { return GetValue<ObservableCollection<String>>(); }
            set { SetValue(value); }
        }
        public String NameAdded { get; set; }
        public int IdAdded { get; set; }
        public string _type1Added;
        public String Type1Added { get { return _type1Added; } 
            set
            { 
                if(value == ListTypes[0])
                {
                    _type1Added = "";
                }
                else
                {
                    _type1Added = value;
                }
            } 
        }

        public string _type2Added;
        public String Type2Added
        {
            get { return _type2Added; }
            set
            {
                if (value == ListTypes[0])
                {
                    _type2Added = "";
                }
                else
                {
                    _type2Added = value;
                }
            }
        }

        public string _mediaPath;
        public String MediaPath {
            get { return _mediaPath; }
            
            set 
            { 
                if(value != null)
                {
                    _mediaPath = value;
                    OnPropertyChanged();
                }
            } 
        }
        public AddPokemonViewModel()
        {
            AddPokemonCommand = new Command(AddPokemon);
            PickImageCommand = new Command(PickImage);
            ListTypes = new ObservableCollection<string>();
            InitializationListTypes();
           
        }

        private async void AddPokemon(object obj)
        {
            PokApiDataBase pokApiDataBase = await PokApiDataBase.Instance;

            pokemonAdded = new PokemonModel
            {
                Name = NameAdded,
                IDPokedex = IdAdded,
                DefaultSprite = MediaPath,
                Type1 = Type1Added,
                Type2 = Type2Added,
            };

            await pokApiDataBase.SaveItemAsync(pokemonAdded);
            ListViewModel.Instance.ListPokemonModels.Add(pokemonAdded);
        }

        private async void PickImage(object obj)
        {
           var photo = await MediaPicker.PickPhotoAsync();
           var stream = await LoadPhotoAsync(photo);
        }
        
        async Task<Stream> LoadPhotoAsync(FileResult photo)
        {
            if(photo == null)
            {
                return null;
            }
            //save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            var stream = await photo.OpenReadAsync();
            MediaPath = photo.FullPath;

            return stream;
        
        }

        public async void InitializationListTypes()
        {
            PokeApiClient pokeApiClient = new PokeApiClient();

            ListTypes.Add("PAS SELECTIONNE");

            for (int i = 2; i < 20; i++)
            {
                PokeApiNet.Type type = await Task.Run(() => pokeApiClient.GetResourceAsync<PokeApiNet.Type>(i-1));
                ListTypes.Add(type.Name);
            }
        }
    }
}
using PokeApi.Model;
using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokeApi.ViewModel
{
    public class RegionsListViewModel : BaseViewModel
    {
        private static RegionsListViewModel _instance = new RegionsListViewModel();
        public static RegionsListViewModel Instance { get { return _instance; } }

        public ObservableCollection<RegionModel> ListRegionModels
        {
            get { return GetValue<ObservableCollection<RegionModel>>(); }
            set { SetValue(value); }
        }
        public RegionsListViewModel()
        {
            ListRegionModels = new ObservableCollection<RegionModel>();
            InitializationList();
        }

        public async void InitializationList()
        {
            PokeApiClient pokeApiClient = new PokeApiClient();

            for (int i = 1; i < 9; i++)
            {
                PokeApiNet.Region region = await Task.Run(() => pokeApiClient.GetResourceAsync<PokeApiNet.Region>(i));
                RegionModel regionModel = new RegionModel
                {
                    Name = region.Name,
                };

                ListRegionModels.Add(regionModel);


            }
        }
    }
}
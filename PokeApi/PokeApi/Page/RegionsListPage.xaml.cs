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
    public partial class RegionsListPage : ContentPage
    {
        public RegionsListPage()
        {
            InitializeComponent();
            BindingContext = RegionsListViewModel.Instance;
        }
    }
}
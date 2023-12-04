using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GardenSpace.Models;
using GardenSpace.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GardenSpace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditGarden : ContentPage, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public EditGarden()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void GoEditGarden(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            Garden garden = imageButton.BindingContext as Garden;
            if (garden == null)
                return;
            await Shell.Current.GoToAsync($"PageEditGardenEdit?SelectedGId={garden.Id}");
        }

        private async void GoAddGarden(object sender, EventArgs e)
        {
            Adding addingPage = new Adding();
            await Navigation.PushAsync(addingPage);
        }
    }
}
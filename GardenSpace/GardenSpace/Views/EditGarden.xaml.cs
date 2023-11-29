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
        private List<Garden> gardens = new List<Garden>();

        public List<Garden> Gardens 
        { 
            get => gardens;
            set 
            { 
                gardens = value; 
                OnPropertyChanged();

            } 
        }

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

        protected override void OnAppearing()
        {
            Gardens = new List<Garden>();
            Gardens = DBInstance.GetInstance().GetAllGardens();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
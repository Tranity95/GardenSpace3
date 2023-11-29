using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GardenSpace.Models;
using GardenSpace.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GardenSpace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPlant : ContentPage, INotifyPropertyChanged
	{
        private List<Plant> plants = new List<Plant>();

        public List<Plant> Plants 
        { 
            get => plants;
            set 
            { 
                plants = value;
                OnPropertyChanged();
            }
        }
        public Plant SelectedPlant { get; set; }
        public EditPlant()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void GoEditPlant(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            Plant plant = imageButton.BindingContext as Plant;
            if (plant == null)
                return;
            await Shell.Current.GoToAsync($"PageEditPlantEdit?SelectedPId={plant.Id}");
        }

        private async void GoAddPlant(object sender, EventArgs e)
        {
            AddingPlant addingPage = new AddingPlant();
            await Navigation.PushAsync(addingPage);
        }

        protected override void OnAppearing()
        {
            Plants = new List<Plant>();
            Plants = DBInstance.GetInstance().GetAllPlants();
        }

        protected override void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
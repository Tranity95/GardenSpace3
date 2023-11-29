using System;
using System.Collections.Generic;
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
    [QueryProperty(nameof(SelectedPlantId), "SelectedPId")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEditPlant : ContentPage, INotifyPropertyChanged
    {
        private int selectedPlantId;
        private Plant selectedPlant;
        private List<Garden> gardens;
        private Garden selectedGarden;

        public int SelectedPlantId 
        { 
            get => selectedPlantId;
            set
            {
                selectedPlantId = value;
                Plant plant = DBInstance.GetInstance().FindPlantForId(SelectedPlantId);
                SelectedPlant = new Plant
                {
                    Id = plant.Id,
                    Title = plant.Title,
                    ImagePath = plant.ImagePath,
                    GardenId = plant.GardenId,
                };

            }
        }

        public Garden SelectedGarden 
        { 
            get => selectedGarden;
            set
            {
                selectedGarden = value;
                OnPropertyChanged();
            }
        }

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

        public Plant SelectedPlant 
        { 
            get => selectedPlant;
            set 
            { 
                selectedPlant = value;
                OnPropertyChanged();
            } 
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected override void OnAppearing()
        {
            Gardens = DBInstance.GetInstance().GetAllGardens();
            SelectedGarden = DBInstance.GetInstance().FindGardenByPlant(SelectedPlant);
        }

        public PageEditPlant()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void Update(object sender, EventArgs e)
        {
            if (SelectedPlant != null)
            {
                SelectedPlant.GardenId = SelectedGarden.Id;
                DBInstance.GetInstance().EditPlant(SelectedPlant);
            }
            await DisplayAlert("Внимание", "Изменения успешно сохранены!", "OK");
        }

        private async void Delete(object sender, EventArgs e)
        {
            if (SelectedPlant != null)
            {
                DBInstance.GetInstance().RemovePlant(SelectedPlant);
            }
            await DisplayAlert("Внимание", "Изменения успешно сохранены!", "OK");
            EditPlant editPlant = new EditPlant();
            await Navigation.PushAsync(editPlant);
        }
    }
}
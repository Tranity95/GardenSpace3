using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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
    [QueryProperty(nameof(SelectedGardenId), "SelectedGId")]
    public partial class PageEditGarden : ContentPage, INotifyPropertyChanged
    {
        private int selectedGardenId;
        private Garden selectedGarden;
        private GardenType selectedGardenType;
        private List<GardenType> gardenTypes;

        public int SelectedGardenId
        {
            get => selectedGardenId;
            set
            {
                selectedGardenId = value;
                Garden garden = DBInstance.GetInstance().FindGardenForId(SelectedGardenId);
                SelectedGarden = new Garden
                {
                    Id = garden.Id,
                    Name = garden.Name,
                    ImagePath = garden.ImagePath,
                    TypeId = garden.TypeId
                };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public GardenType SelectedGardenType 
        { 
            get => selectedGardenType;
            set 
            { 
                selectedGardenType = value;
                OnPropertyChanged();
            } 
        }
        public List<GardenType> GardenTypes 
        { 
            get => gardenTypes;
            set 
            { 
                gardenTypes = value;
                OnPropertyChanged();
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

        protected override void OnAppearing()
        {
            GardenTypes = DBInstance.GetInstance().GetAllGardenTypes();
            SelectedGardenType = DBInstance.GetInstance().FindGTByGarden(SelectedGarden);
        }

        public PageEditGarden()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void Update(object sender, EventArgs e)
        {
            if (SelectedGarden != null)
            {
                SelectedGarden.TypeId = SelectedGardenType.Id;
                DBInstance.GetInstance().EditGarden(SelectedGarden);
            }
            await DisplayAlert("Внимание", "Изменения успешно сохранены!", "OK");
        }

        private async void Delete(object sender, EventArgs e)
        {
            if (SelectedGarden != null)
            {
                DBInstance.GetInstance().RemoveGarden(SelectedGarden);
            }
            await DisplayAlert("Внимание", "Изменения успешно сохранены!", "OK");
            EditGarden editGarden = new EditGarden();
            await Navigation.PushAsync(editGarden);
        }
    }
}
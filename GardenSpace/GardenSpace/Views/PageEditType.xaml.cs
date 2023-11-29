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
    [QueryProperty(nameof(SelectedGardenTypeId), "SelectedTId")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEditType : ContentPage, INotifyPropertyChanged
    {
        private GardenType selectedGardenType;
        private int selectedGardenTypeId;

        public GardenType SelectedGardenType 
        { 
            get => selectedGardenType;
            set 
            { 
                selectedGardenType = value;
                OnPropertyChanged();
            }  
        }

        public int SelectedGardenTypeId
        {
            get => selectedGardenTypeId;
            set 
            {
                selectedGardenTypeId = value;
                GardenType gardenType = DBInstance.GetInstance().FindGardenTypeForId(SelectedGardenTypeId);
                SelectedGardenType = new GardenType
                {
                    Id = gardenType.Id,
                    Title = gardenType.Title
                };
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PageEditType()
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
            if (SelectedGardenType != null)
            {
                DBInstance.GetInstance().EditGardenType(SelectedGardenType);
            }
            await DisplayAlert("Внимание", "Изменения успешно сохранены!", "OK");
        }

        private async void Delete(object sender, EventArgs e)
        {
            if (SelectedGardenType != null)
            {
                DBInstance.GetInstance().RemoveGardenType(SelectedGardenType);
            }
            await DisplayAlert("Внимание", "Изменения успешно сохранены!", "OK");
            EditPlant editPlant = new EditPlant();
            await Navigation.PushAsync(editPlant);
        }
    }
}
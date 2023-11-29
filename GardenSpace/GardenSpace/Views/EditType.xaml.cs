using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
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
    public partial class EditType : ContentPage, INotifyPropertyChanged
    {
        private List<GardenType> gardenTypes;
        public List<GardenType> GardenTypes 
        { 
            get => gardenTypes;
            set 
            { 
                gardenTypes = value;
                OnPropertyChanged();
            } 
        }
        public GardenType SelectedGardenType { get; set; }
        public EditType()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private async void GoAddNewType(object sender, EventArgs e)
        {
            AddingType addingTypePage = new AddingType();
            await Navigation.PushAsync(addingTypePage);
        }

        protected override void OnAppearing()
        {
            GardenTypes = DBInstance.GetInstance().GetAllGardenTypes();
        }

        protected override void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        //
        //

        private async void GoEditType(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            GardenType type = imageButton.BindingContext as GardenType;
            if (type == null)
                return;
            await Shell.Current.GoToAsync($"PageEditGardenTypeEdit?SelectedTId={type.Id}");
        }

    }
}
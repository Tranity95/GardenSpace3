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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlowerGardens : ContentPage, INotifyPropertyChanged
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
        public Garden SelectedGarden { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public FlowerGardens()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void GoGarden(object sender, EventArgs e)
        {
            var btn = (ImageButton)sender;
            SelectedGarden = (Garden)btn.BindingContext;
            if (SelectedGarden == null)
                return;
            await Shell.Current.GoToAsync($"PageF?SGId={SelectedGarden.Id}");
        }

        protected override void OnAppearing()
        {
            Gardens = DBInstance.GetInstance().GetFlowerGardens();
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
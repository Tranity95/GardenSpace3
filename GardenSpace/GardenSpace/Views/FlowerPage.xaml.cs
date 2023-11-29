using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GardenSpace.Models;
using GardenSpace.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GardenSpace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(SelectedGardenId), "SGId")]
    public partial class FlowerPage : ContentPage
    {   
        private int selectedGardenId;
        public int SelectedGardenId 
        { 
            get => selectedGardenId;
            set
            {
                selectedGardenId = value;
                SelectedGarden = DBInstance.GetInstance().FindGardenForId(SelectedGardenId);         
            }   
        }
        public Garden SelectedGarden { get; set; }
        public List<Plant> Plants { get; set; } = new List<Plant>();
        public FlowerPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            Plants =  DBInstance.GetInstance().GetGardenPlants(SelectedGarden).ToList();
            BindingContext = this;
        }
    }
}
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
    public partial class Adding : ContentPage
    {
        //private GardenType selectedGardenType;
        //private List<GardenType> gardenTypes;

        //public GardenType SelectedGardenType 
        //{ 
        //    get => selectedGardenType;
        //    set 
        //    { 
        //        selectedGardenType = value; 
        //    } 
        //}

        //public string Name { get; set; }
        //public string ImagePath { get; set; }
        //public List<GardenType> GardenTypes 
        //{ 
        //    get => gardenTypes;
        //    set 
        //    { 
        //        gardenTypes = value;
        //        GardenTypes = DBInstance.GetInstance().GetAllGardenTypes();
        //    } 
        //}

        public Adding()
        {
            InitializeComponent();
            // BindingContext = this;
        }
        //private void AddGarden(object sender, EventArgs e)
        //{
        //    if (Name != null || selectedGardenType.Id != null || ImagePath != null)
        //    {
        //        DBInstance.GetInstance().AddGarden(new Garden
        //        {
        //            Name = Name,
        //            TypeId = selectedGardenType.Id,
        //            ImagePath = ImagePath
        //        });
        //    }
        //}
    }
}
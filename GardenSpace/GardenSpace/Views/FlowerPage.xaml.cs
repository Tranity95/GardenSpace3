using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using GardenSpace.Models;
using GardenSpace.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GardenSpace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //[QueryProperty(nameof(SelectedGardenId), "SGId")]
    public partial class FlowerPage : ContentPage
    {   
        public FlowerPage()
        {
            InitializeComponent();
        }
    }
}
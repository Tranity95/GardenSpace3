using GardenSpace.Models;
using GardenSpace.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Xamarin.Forms;

namespace GardenSpace.ViewModels
{
    
    public class FlowerPageViewModel : BaseViewModel, IQueryAttributable
    {
        public List<Plant> Plants { get => plants; set { plants = value; OnPropertyChanged(); } }
        private int selectedGardenId;
        private List<Plant> plants;

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


        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            //
            App.Current.MainPage.DisplayAlert(HttpUtility.UrlDecode(query["entry"]), HttpUtility.UrlDecode(query["entry"]), HttpUtility.UrlDecode(query["entry"]));
            SelectedGardenId = Convert.ToInt32(HttpUtility.UrlDecode(query["entry"]));
            Plants = DBInstance.GetInstance().GetGardenPlants(SelectedGarden).ToList();
        }
    }
}

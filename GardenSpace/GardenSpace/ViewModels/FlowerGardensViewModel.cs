using GardenSpace.Models;
using GardenSpace.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Xamarin.Forms;

namespace GardenSpace.ViewModels
{
    public class FlowerGardensViewModel : BaseViewModel
    {
        private Garden selectedGarden;
        private List<Garden> gardens;

        public List<Garden> Gardens { get => gardens; set { gardens = value; OnPropertyChanged(); } }
        public Garden SelectedGarden
        {
            get => selectedGarden;
            set => selectedGarden = value;
        }
        public ICommand GoGarden { get; set; }
        public FlowerGardensViewModel()
        {
            //App.DB.Gardens.Add(new Garden
            //{
            //    Name = "Name",
            //    ImagePath = "gvozdik.jpg",
            //    TypeId = 1
            //});
            //App.DB.Plants.Add(new Plant
            //{
            //    Title = "Title",
            //    ImagePath = "gvozdi.jpg",
            //    GardenId = 1,
            //    Type = "пиздец"
            //});
            //App.DB.SaveChanges();

            Gardens = DBInstance.GetInstance().GetFlowerGardens();

            GoGarden = new Command<Garden>((x) => Foo(x));
        }
        public async void Foo(Garden x)
        {
            await Shell.Current.GoToAsync($"PageF?entry={x.Id}");
        }
        
    }
}

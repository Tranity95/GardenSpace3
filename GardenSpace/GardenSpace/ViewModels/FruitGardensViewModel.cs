using GardenSpace.Models;
using GardenSpace.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GardenSpace.ViewModels
{
    public class FruitGardensViewModel: BaseViewModel
    {
        private List<Garden> gardens;

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
        public ICommand GoFruitGarden { get; set; }
        public FruitGardensViewModel()
        {
            App.DB.Gardens.Add(new Garden
            {
                Name = "Name",
                ImagePath = "fruit.jpg",
                TypeId = 2
            });
            //App.DB.Plants.Add(new Plant
            //{
            //    Title = "Title",
            //    ImagePath = "gvozdi.jpg",
            //    GardenId = 1,
            //    Type = "пиздец"
            //});
            //App.DB.SaveChanges();

            GoFruitGarden = new Command<Garden>((x) => Foo(x));
            Gardens = DBInstance.GetInstance().GetFruitGardens();
        }
        public async void Foo(Garden x)
        {
            await Shell.Current.GoToAsync($"PageFr?entry={x.Id}");
        }
    }
}

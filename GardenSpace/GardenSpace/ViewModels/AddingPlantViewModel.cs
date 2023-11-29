using GardenSpace.Models;
using GardenSpace.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenSpace.ViewModels
{
    public class AddingPlantViewModel
    {
        private Garden selectedGarden;
        private List<Garden> gardens;

        public Garden SelectedGarden
        {
            get => selectedGarden;
            set
            {
                selectedGarden = value;
            }
        }

        public string Title { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public List<Garden> Gardens
        {
            get => gardens;
            set 
            { 
                gardens = value;
                Gardens = DBInstance.GetInstance().GetAllGardens();
            }
        }


        private void AddPlant(object sender, EventArgs e)
        {
            DBInstance.GetInstance().AddPlant(new Plant
            {
                Title = Title,
                Type = Type,
                ImagePath = ImagePath,
                GardenId = selectedGarden.Id,
            });
        }
    }
}

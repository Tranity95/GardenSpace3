using GardenSpace.Models;
using GardenSpace.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenSpace.ViewModels
{
    public class AddingViewModel
    {
        private GardenType selectedGardenType;
        private List<GardenType> gardenTypes;

        public GardenType SelectedGardenType
        {
            get => selectedGardenType;
            set
            {
                selectedGardenType = value;
            }
        }

        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<GardenType> GardenTypes
        {
            get => gardenTypes;
            set
            {
                gardenTypes = value;
                GardenTypes = DBInstance.GetInstance().GetAllGardenTypes();
            }
        }
        private void AddGarden(object sender, EventArgs e)
        {
            if (Name != null || selectedGardenType.Id != null || ImagePath != null)
            {
                DBInstance.GetInstance().AddGarden(new Garden
                {
                    Name = Name,
                    TypeId = selectedGardenType.Id,
                    ImagePath = ImagePath
                });
            }
        }
    }
}

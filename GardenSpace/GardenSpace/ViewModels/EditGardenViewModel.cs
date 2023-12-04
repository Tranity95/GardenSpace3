using GardenSpace.Models;
using GardenSpace.Tools;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GardenSpace.ViewModels
{
    public class EditGardenViewModel : BaseViewModel
    {
        private List<Garden> gardens;

        public ICommand GoAddGarden { get; set; }
        public List<Garden> Gardens 
        { 
            get => gardens;
            set 
            { 
                gardens = value;
                OnPropertyChanged();
            } 
        }
        public EditGardenViewModel()
        {
            Gardens = new List<Garden>();
            Gardens = DBInstance.GetInstance().GetAllGardens();
        }
    }
}

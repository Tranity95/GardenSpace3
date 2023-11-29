using GardenSpace.Models;
using GardenSpace.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenSpace.ViewModels
{
    public class AddingTypeViewModel
    {
        public string Title { get; set; }

        private void AddType(object sender, EventArgs e)
        {
            DBInstance.GetInstance().AddType(new GardenType
            {
                Title = Title
            });
        }
    }
}

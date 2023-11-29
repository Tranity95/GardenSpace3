using System;
using System.Collections.Generic;
using System.Text;

namespace GardenSpace.Models
{
    public class Garden
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int TypeId { get; set; }
    }
}

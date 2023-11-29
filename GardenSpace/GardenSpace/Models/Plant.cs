using System;
using System.Collections.Generic;
using System.Text;

namespace GardenSpace.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public int GardenId { get; set; }
    }
}


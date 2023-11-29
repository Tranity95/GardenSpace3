using GardenSpace.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenSpace.Tools
{
    public class DboContext : DbContext
    {
        private string _filePath;

        public DboContext(string filePath)
        {
            _filePath = filePath;
        }

        public DbSet<Garden> Gardens { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<GardenType> GardenTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_filePath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenSpace.Models;
using Xamarin.Forms;

namespace GardenSpace.Tools
{
    public class DB
    {
        // Получаем все объекты:
        public List<GardenType> GetAllGardenTypes()
        {
            return new List<GardenType>(App.DB.GardenTypes).ToList();
        }
        public List<Garden> GetAllGardens()
        {
            return new List<Garden>(App.DB.Gardens.ToList());
        }
        public List<Plant> GetAllPlants()
        {
            return new List<Plant>(App.DB.Plants).ToList();
        }


        // Получаем сады по типам:
        public List<Garden> GetFruitGardens()
        {
            return new List<Garden>(App.DB.Gardens.Where(s => s.TypeId == 2).ToList());
        }
        public List<Garden> GetFlowerGardens()
        {
            return new List<Garden>(App.DB.Gardens.Where(s => s.TypeId == 1).ToList());
        }


        // Добавляем объекты:
        public void AddType(GardenType gardenType)
        {
            App.DB.GardenTypes.Add(gardenType);
            App.DB.SaveChanges();
        }
        public void AddGarden(Garden garden)
        {
            App.DB.Gardens.Add(garden);
            App.DB.SaveChanges();
        }
        public void AddPlant(Plant plant)
        {
            App.DB.Plants.Add(plant);
            App.DB.SaveChanges();
        }

        //найти тип выбранного сада
        public GardenType FindGTByGarden(Garden garden)
        {
            return App.DB.GardenTypes.FirstOrDefault(s => s.Id == garden.TypeId);
        }

        //найти сад в котором выбранное растение
        public Garden FindGardenByPlant(Plant plant)
        {
            return App.DB.Gardens.FirstOrDefault(s => s.Id == plant.GardenId);
        }

        // Найти объект по айди:
        public Garden FindGardenForId(int id)
        {
            return App.DB.Gardens.FirstOrDefault(s => s.Id == id);
        }
        public Plant FindPlantForId(int id)
        {
            return App.DB.Plants.FirstOrDefault(plant => plant.Id == id);
        }
        public GardenType FindGardenTypeForId(int id)
        {
            return App.DB.GardenTypes.FirstOrDefault(type => type.Id == id);
        }

        // Найти растения сада
        public List<Plant> GetGardenPlants(Garden garden)
        {
            return new List<Plant>(App.DB.Plants.Where(s => s.GardenId == garden.Id));
        }


        // удаление объекта
        public void RemoveGarden(Garden garden)
        {
            App.DB.Gardens.Remove(garden);
            App.DB.SaveChanges();
        }
        public void RemovePlant(Plant plant)
        {
            App.DB.Plants.Remove(plant);
            App.DB.SaveChanges();
        }
        public void RemoveGardenType(GardenType gardenType)
        {
            App.DB.GardenTypes.Remove(gardenType);
            App.DB.SaveChanges();
        }


        //редактирование объекта
        public void EditGarden(Garden newEditGarden)
        {
            Garden oldGardenToEdit = FindGardenForId(newEditGarden.Id);
            App.DB.Entry(oldGardenToEdit).CurrentValues.SetValues(newEditGarden);
            App.DB.SaveChanges();
        }
        public void EditPlant(Plant newEditPlant)
        {
            Plant oldPlantToEdit = FindPlantForId(newEditPlant.Id);
            App.DB.Entry(oldPlantToEdit).CurrentValues.SetValues(newEditPlant);
            App.DB.SaveChanges();
        }
        public void EditGardenType(GardenType newEditGardenType)
        {
            GardenType oldGardenTypeToEdit = FindGardenTypeForId(newEditGardenType.Id);
            App.DB.Entry(oldGardenTypeToEdit).CurrentValues.SetValues(newEditGardenType);
            App.DB.SaveChanges();
        }
    }
}


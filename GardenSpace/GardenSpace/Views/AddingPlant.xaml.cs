using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GardenSpace.Models;
using GardenSpace.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GardenSpace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddingPlant : ContentPage
	{
  //      private Garden selectedGarden;
  //      private List<Garden> gardens;

  //      public Garden SelectedGarden 
		//{ 
		//	get => selectedGarden;
		//	set 
		//	{ 
		//		selectedGarden = value;
		//	} 
		//}

  //      public string Title {  get; set; }
		//public string Type { get; set; }
		//public string ImagePath { get; set; }
  //      public List<Garden> Gardens 
		//{ 
		//	get => gardens;
		//	set 
		//	{ 
		//		gardens = value; 
		//		Gardens = DBInstance.GetInstance().GetAllGardens();
		//	} 
		//}

        public AddingPlant()
		{
			InitializeComponent();
			//BindingContext = this;
		}

   //     private void AddPlant(object sender, EventArgs e)
   //     {
			//DBInstance.GetInstance().AddPlant(new Plant
			//{
			//	Title = Title,
			//	Type = Type,
			//	ImagePath = ImagePath,
			//	GardenId = selectedGarden.Id,
			//}) ;
   //     }
    }
}
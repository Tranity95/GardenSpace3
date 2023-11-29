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
	public partial class AddingType : ContentPage
	{
		//public string Title { get; set; }

		public AddingType ()
		{
			InitializeComponent ();
            BindingContext = this;
		}

        //private void AddType(object sender, EventArgs e)
        //{
        //    DBInstance.GetInstance().AddType(new GardenType
        //    {
        //        Title = Title
        //    });
        //}
    }
}
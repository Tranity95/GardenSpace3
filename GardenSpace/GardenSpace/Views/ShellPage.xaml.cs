using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GardenSpace
{
    public partial class ShellPage : Shell
    {
        public ShellPage()
        {
            InitializeComponent();
            Routing.RegisterRoute("PageF", typeof(FlowerPage));

            Routing.RegisterRoute("PageFr", typeof(FlowerPage));

            Routing.RegisterRoute("PageEditGarden", typeof(EditGarden));

            Routing.RegisterRoute("PageEditPlant", typeof(EditPlant));

            Routing.RegisterRoute("PageEditType", typeof(EditType));

            Routing.RegisterRoute("PageEditGardenEdit", typeof(PageEditGarden));

            Routing.RegisterRoute("PageEditPlantEdit", typeof(PageEditPlant));

            Routing.RegisterRoute("PageEditGardenTypeEdit", typeof(PageEditType));
        }        
    }
}

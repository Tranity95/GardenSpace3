using System;
using GardenSpace.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GardenSpace
{
    public partial class App : Application
    {
        private const string FILE_NAME = "db.db";
        private static DboContext dB;
        public static DboContext DB
        {
            get
            {
                if (dB == null)
                {
                    string path = DependencyService.Get<IDBPath>().GetDBPath(FILE_NAME);
                    dB = new DboContext(path);
                    //dB.Database.EnsureDeleted();
                    dB.Database.EnsureCreated();
                }
                return dB;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new ShellPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

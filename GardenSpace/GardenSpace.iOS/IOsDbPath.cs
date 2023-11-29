using Foundation;
using GardenSpace.iOS;
using GardenSpace.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOsDbPath))]
namespace GardenSpace.iOS
{
    public class IOsDbPath : IDBPath
    {
        public string GetDBPath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments),
                filename);
        }
    }
}
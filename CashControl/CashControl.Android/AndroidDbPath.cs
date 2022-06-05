using System;
using CashControl.Droid;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDbPath))]
namespace CashControl.Droid
{
    public class AndroidDbPath : IPath
    {
        public string GetDatabasePath(string filename)
            => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
    }
}
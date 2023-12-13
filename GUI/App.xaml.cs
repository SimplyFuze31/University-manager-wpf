using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            if (!Directory.Exists(@"C:\Users\Simplyfuze\OOP-SA22"))
            {
                Directory.CreateDirectory(@"C:\Users\Simplyfuze\OOP-SA22");
                File.Create(@"C:\Users\Simplyfuze\OOP-SA22\data.json");
            }
            
        }
        
    }
}
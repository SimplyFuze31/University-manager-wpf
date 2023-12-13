using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Final_work_OOP_SA22;
using GUI.Pages;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void DataGridDoubleClick(University edu);
        public DataGridDoubleClick DataGridClickHandler { get; set; }

        public delegate void StarPageClick();
        public StarPageClick StarPageClickHandler { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            StarPageClickHandler = OpenStarPage;
            DataGridClickHandler = OpenChangeInstitutionDataPage;
            Serealizator.Save(Helper.GenerateUniversities(50));
            OpenStarPage();
            
        }
        
        private void OpenChangeInstitutionDataPage(University edu)
        {
            Main.Content = new ChangeInstitutionDataPage(edu, StarPageClickHandler);
        }

        private void OpenStarPage()
        {
            Main.Content = new StartPage(DataGridClickHandler);
        }
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
using System.Windows.Controls;
using System.Windows.Input;
using Final_work_OOP_SA22;

namespace GUI.Pages;

public partial class StartPage : Page
{

    private MainWindow.DataGridDoubleClick _click;
    public StartPage(MainWindow.DataGridDoubleClick click)
    {
        InitializeComponent();
        var universities = Helper.GenerateUniversities(10);
        
        dgEducationalInstitution.ItemsSource = universities;
        _click = click;
    }
    
    

    
    private void DgEducationalInstitution_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        _click((University)dgEducationalInstitution.SelectedItem) ;
    }
}
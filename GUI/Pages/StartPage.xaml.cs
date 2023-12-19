using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Final_work_OOP_SA22;
using Final_work_OOP_SA22.Controllers;
using Final_work_OOP_SA22.Extensions;

namespace GUI.Pages;

public partial class StartPage : Page
{
    private University _edu;
    private MainWindow.DataGridDoubleClick _click;
    public StartPage(MainWindow.DataGridDoubleClick click )
    {
        InitializeComponent();
        
        var universities = Serealizator.Load();
        
        dgEducationalInstitution.ItemsSource = universities;
        _click = click; 
    }
    
    private void DgEducationalInstitution_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        try
        {
            var uni = (University)dgEducationalInstitution.SelectedItem;
            if (uni != null)
                _click(uni);

        }
        catch (Exception exception)
        {
            return;
        }
    }

    private void BAddUniversity_OnClick(object sender, RoutedEventArgs e)
    {
        
            var uni = new University();
            _click(uni);

    }

    private void BRemoveUniversity_OnClick(object sender, RoutedEventArgs e)
    {
        var controller = new UniversityController((University)dgEducationalInstitution.SelectedItem);
        controller.RemoveUniversity();
        dgEducationalInstitution.ItemsSource = null;
        var universities = Serealizator.Load();
        dgEducationalInstitution.ItemsSource = universities;
    }
}
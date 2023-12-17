using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Final_work_OOP_SA22;
using Final_work_OOP_SA22.Extensions;
using Final_work_OOP_SA22.Factories;

namespace GUI.Pages;

public partial class ChangeInstitutionDataPage : Page
{
    private University _selected_university;
    private bool IsDepartment;
    private Institute _selected_institute;
    private EducationalInstitution _intitut;
    private MainWindow.StarPageClick _backpageclick;
    
    public ChangeInstitutionDataPage()
    {
        InitializeComponent();
    }
    public ChangeInstitutionDataPage(University currentUniversity , MainWindow.StarPageClick BackPageClick)
    {
        InitializeComponent();
        try
        {
            Refresh(currentUniversity);
        }
        catch (Exception e) { }
        lvInstitutes.ItemsSource = _selected_university.Institutes;
        _backpageclick = BackPageClick;

    }

    private void BReturnBack_OnClick(object sender, RoutedEventArgs e)
    {
        _backpageclick();
    }
    
    private void BSaveChanges_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (CheckTextBoxEmpty(StpUniversityPanel.Children))
                throw new Exception("Поля не можуть бути пустими") ;
            int val;
            int.TryParse(tbRating.Text, out val);
            
            UniversityFactory factory = new(tbUniversityName.Text , DateTime.Now, new Person(tbHeadOfInstitution.Text), 
                val, tbPhoneNumber.Text , new ExtendedList<Institute>());
            
            ExtendedList<University> uni = Serealizator.Load();
            if(uni.Exists(u => u.Id == _selected_university.Id))
                uni.Replace(factory.GetEducationalInstitution() as University);
            else
                uni.Add(factory.GetEducationalInstitution() as University);
            Serealizator.Save(uni);
            _backpageclick();
        }
        catch (Exception exception)
        {
            lErrorOutput.Content = exception.Message;
        }
        
    }
    
    private void LvInstitutes_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        lInfo.Content = string.Empty;
        IsDepartment = false;
        _selected_institute = (Institute)lvInstitutes.SelectedItem;
        lvDeparments.ItemsSource = _selected_institute.Departments;
        SwitchDepartmentTextBox();
        #region Entering data in a Textbox
        tbInstitutionName.Text = _selected_institute.Name;
        tbInstitutionRating.Text = _selected_institute.Rating.ToString();
        tbHeadOfDepartment.Text = _selected_institute.HeadOfInstitution.ToString();
        tbInstitutionPhoneNumber.Text = _intitut.PhoneNumber;
        tbNumberOfStudents.Text = _selected_institute.GetNumberOfStudents().ToString();
        #endregion
        
    }

    private void LvDeparments_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        lInfo.Content = string.Empty;
        IsDepartment = true;
        SwitchDepartmentTextBox();
        var institute = (Department)lvDeparments.SelectedItem;
       
        
        _intitut = institute;
        #region Entering data in a Textbox
        tbInstitutionName.Text = _intitut.Name;
        tbInstitutionRating.Text = _intitut.Rating.ToString();
        tbHeadOfDepartment.Text = _intitut.HeadOfInstitution.ToString();
        tbInstitutionPhoneNumber.Text = _intitut.PhoneNumber;
        tbNumberOfStudents.Text = _intitut.GetNumberOfStudents().ToString();
        SwitchDepartmentTextBox();
        #endregion

    }
    
    private void BAddInstitute_OnClick(object sender, RoutedEventArgs e)
    {
        IsDepartment = false;
        
        SwitchDepartmentTextBox();
        TextBoxCleaner(stpDepartmentPanel.Children);
        
        var factory = new InstituteFactory("Новий інститут", DateTime.Today, new Person("Директор Інституту"), 
            0 , "0000000000", new ExtendedList<Department>());
        _selected_institute = factory.GetEducationalInstitution() as Institute;
        
        _selected_university.Institutes.Add(_selected_institute);
        
        tbInstitutionName.Text = _selected_institute.Name;
        tbInstitutionRating.Text = _selected_institute.Rating.ToString();
        tbHeadOfDepartment.Text = _selected_institute.HeadOfInstitution.ToString();
        //tbInstitutionPhoneNumber.Text = _selected_institute.PhoneNumber;
        tbNumberOfStudents.Text = "0";
        
        lvInstitutes.Items.Refresh();

    }

    private void BSaveDepartment_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            int val;
            ExtendedList<University> uni = Serealizator.Load();
            _intitut.Name = tbInstitutionName.Text;
            _intitut.HeadOfInstitution = new Person(tbHeadOfDepartment.Text);
            _intitut.PhoneNumber = tbInstitutionPhoneNumber.Text;

            if (int.TryParse(tbInstitutionRating.Text, out val))
                _intitut.Rating = val;

            
            //Перевірємо чи це є кафедра
            if (IsDepartment)
            {
                var depart = _intitut as Department;
                if (int.TryParse(tbNumberOfStudents.Text, out val))
                    depart.NumberOfStudents = val;
                _selected_institute.Departments.Replace(depart);
            }
            else
            {
                _selected_institute = new Institute(_intitut as Institute);
            }
            
            
            _selected_university.Institutes.Replace(_selected_institute);
            
            
            uni.Replace(new University(_selected_university));
            Serealizator.Save(uni);
            lvInstitutes.Items.Refresh();
            lvDeparments.Items.Refresh();
            TextBoxCleaner(stpDepartmentPanel.Children);
            lInfo.Content = "Зміни збережено";
        }
        catch (Exception exception)
        {
            lInfo.Content = "Невірні дані";  
        }
        

    }

    private void SwitchDepartmentTextBox()
    {
        switch (IsDepartment)
    {
        case true :
        tbInstitutionRating.IsEnabled = false;
        tbNumberOfStudents.IsEnabled = true;
        break;
        case false: 
        tbInstitutionRating.IsEnabled = true;
        tbNumberOfStudents.IsEnabled = false;
        break;
    }
    }
    private bool CheckTextBoxEmpty(UIElementCollection collection)
    {
        foreach (var element in collection) {
            if (element is TextBox) {
                var tb = element as TextBox;
                if (tb.IsEnabled && tb.Text == string.Empty)
                    return true;
            }
        }
        return false;
    }
    private void TextBoxCleaner(UIElementCollection collection)
    {
        foreach (UIElement element in collection)
        {
            if (element is StackPanel)
            {
                var pan = (StackPanel)element;
                TextBoxCleaner(pan.Children);
            }
            if (element is TextBox)
            {
                var tb = element as TextBox;
                tb.Text = String.Empty;
            }
        }
    }
    

    private void Refresh(University uni)
    {
        
        _selected_university = new University(uni);
        tbUniversityName.Text = _selected_university.Name;
        tbRating.Text = _selected_university.Rating.ToString();
        tbHeadOfInstitution.Text = _selected_university.HeadOfInstitution.ToString();
        tbPhoneNumber.Text = _selected_university.PhoneNumber;
        lNumberOfStudents.Content = $"Кількість студентів: {_selected_university.NumberOfStudents}";
    }
    private void TbInstitutionRating_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        // var tb = (TextBox)sender;
        //
        // foreach (UIElement element in stpDepartmentPanel.Children)
        // {
        //     try
        //     {
        //         if (CheckTextBoxContent((TextBox)element) && element.IsEnabled)
        //             bSaveDepartment.IsEnabled = true;
        //         else
        //             bSaveDepartment.IsEnabled = false;
        //     }
        //     catch (Exception exception){}
        // }
        
    }

    private void BDeleteInstitute_OnClick(object sender, RoutedEventArgs e)
    {
        ExtendedList<University> uni = Serealizator.Load();
        _selected_university.Institutes.Remove(_selected_institute);
        
        uni.Replace(_selected_university);
        
        Serealizator.Save(uni);
        lvInstitutes.Items.Refresh();
        TextBoxCleaner(stpDepartmentPanel.Children);
    }

    private void BRemoveDepartment_OnClick(object sender, RoutedEventArgs e)
    {
        ExtendedList<University> uni = Serealizator.Load();
        try
        {
            _selected_institute = (Institute)lvInstitutes.SelectedItem;

            _selected_institute.Departments.Remove((Department)lvDeparments.SelectedItem);
            _selected_university.Institutes.Replace(_selected_institute);
            lvDeparments.Items.Refresh();
        }
        catch (Exception exception) { }

        uni.Replace(_selected_university);
        Serealizator.Save(uni);
        

    }
}
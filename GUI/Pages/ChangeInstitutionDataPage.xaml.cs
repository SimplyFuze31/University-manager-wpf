using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Final_work_OOP_SA22;

namespace GUI.Pages;

public partial class ChangeInstitutionDataPage : Page
{
    private University _current_university;
    private bool IsDepartment;
    private Institute _current_insitute;
    private EducationalInstitution _intitut;
    private MainWindow.StarPageClick _backpageclick;
    
    public ChangeInstitutionDataPage()
    {
        InitializeComponent();
    }
    public ChangeInstitutionDataPage(University currentUniversity , MainWindow.StarPageClick BackPageClick)
    {
        InitializeComponent();
        _current_university = currentUniversity;
        tbUniversityName.Text = _current_university.Name;
        tbRating.Text = _current_university.Rating.ToString();
        tbHeadOfInstitution.Text = _current_university.HeadOfInstitution.ToString();
        tbPhoneNumber.Text = _current_university.PhoneNumber;
        lNumberOfStudents.Content = $"Кількість студентів: {_current_university.NumberOfStudents}";
        lvInstitutes.ItemsSource = _current_university.Institutes;
        _backpageclick = BackPageClick;
    }

    private void BReturnBack_OnClick(object sender, RoutedEventArgs e)
    {
        _backpageclick();
    }

    private void LvInstitutes_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        IsDepartment = false;
        _current_insitute = (Institute)lvInstitutes.SelectedItem;
        
        lvDeparments.ItemsSource = _current_insitute.Departments;

        _intitut = _current_insitute;

        tbInstitutionName.Text = _intitut.Name;
        tbInstitutionRating.Text = _intitut.Rating.ToString();
        tbHeadOfDepartment.Text = _intitut.HeadOfInstitution.ToString();
        tbInstitutionPhoneNumber.Text = _intitut.PhoneNumber;
        tbNumberOfStudents.IsReadOnly = true;
        tbNumberOfStudents.Text = _intitut.GetNumberOfStudents().ToString();
    }

    private void BSaveChanges_OnClick(object sender, RoutedEventArgs e)
    {
        _current_university.Name = tbUniversityName.Text;
        int val;
        bool result = int.TryParse(tbRating.Text, out val);
        if (result)
            _current_university.Rating = val;
        _current_university.HeadOfInstitution = new Person(tbHeadOfInstitution.Text);
        _current_university.PhoneNumber = tbPhoneNumber.Text;

        ExtendedList<University> uni = Serealizator.Load();
        uni.Replace(_current_university);
        Serealizator.Save(uni);
        _backpageclick();
    }
    
    private void tbTextEmptyObserver(object sender, RoutedEventArgs e)
    {
        var tb = (TextBox)sender;

        if (tb.Text != String.Empty)
        {
            bSaveChanges.IsEnabled = true;
            tb.Background = Brushes.White;
            return;
        }
        else
        {
            tb.Background = Brushes.Salmon;
            bSaveChanges.IsEnabled = false;
        }
    }

    private void LvDeparments_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        IsDepartment = true;
        var institute = (Department)lvDeparments.SelectedItem;
        
        _intitut = institute;

        tbInstitutionName.Text = _intitut.Name;
        tbInstitutionRating.Text = _intitut.Rating.ToString();
        tbHeadOfDepartment.Text = _intitut.HeadOfInstitution.ToString();
        tbInstitutionPhoneNumber.Text = _intitut.PhoneNumber;
        tbNumberOfStudents.IsReadOnly = false;
        tbNumberOfStudents.Text = _intitut.GetNumberOfStudents().ToString();
    }

    private void BSaveDepartment_OnClick(object sender, RoutedEventArgs e)
    {
        int val;
        _intitut.Name = tbInstitutionName.Text;
        if (int.TryParse(tbInstitutionRating.Text, out val))
            _intitut.Rating = val;
        _intitut.HeadOfInstitution = new Person(tbHeadOfDepartment.Text);
        _intitut.PhoneNumber = tbInstitutionPhoneNumber.Text;
        if (int.TryParse(tbNumberOfStudents.Text, out val))
            _intitut.NumberOfStudents = val;

        if (IsDepartment)
        {
            _current_insitute.Departments.Replace((Department)_intitut);
            _current_university.Institutes.Replace(_current_insitute);
        }
        ExtendedList<University> uni = Serealizator.Load();
        uni.Replace(_current_university);
        Serealizator.Save(uni);
        
        
    }
}
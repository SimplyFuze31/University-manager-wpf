using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Final_work_OOP_SA22;
using Final_work_OOP_SA22.Controllers;
using Final_work_OOP_SA22.Extensions;
using Final_work_OOP_SA22.Factories;

namespace GUI.Pages;

public partial class ChangeInstitutionDataPage : Page
{
    private University _selected_university;
    private Institute? _selected_institute;
    private Department _selected_department;
    private bool IsDepartment;
    
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
            _selected_university = currentUniversity;
            tbUniversityName.Text = _selected_university.Name;
            tbRating.Text = _selected_university.Rating.ToString();
            tbHeadOfInstitution.Text = _selected_university.HeadOfInstitution.ToString();
            tbPhoneNumber.Text = _selected_university.PhoneNumber;
            lNumberOfStudents.Content = $"Кількість студентів: {_selected_university.NumberOfStudents}";
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
            UniversityController controller =
                new UniversityController(_selected_university);
            UniversityFactory factory = new(tbUniversityName.Text , _selected_university.FoundationDate, new Person(tbHeadOfInstitution.Text), 
                GetTextBoxInt(tbRating), tbPhoneNumber.Text , _selected_university.Institutes);
            controller.RemoveUniversity();
            _selected_university = factory.GetEducationalInstitution() as University;
            controller = new UniversityController(_selected_university);
            controller.AddUniversity();
            _backpageclick();
        }
        catch (Exception exception)
        {
            tblErrorUniversityPanel.Text = exception.Message;
        }
        
    }
    private void BAddInstitute_OnClick(object sender, RoutedEventArgs e)
    {
        IsDepartment = false;
        SwitchDepartmentTextBox();
        TextBoxCleaner(stpDepartmentPanel.Children);
        
        var factory = new InstituteFactory("Новий інститут", DateTime.Today, new Person("Директор Інституту"), 
            0 , "0000000000", new ExtendedList<Department>());
        
        var controller = new UniversityController(_selected_university);
        
        controller.AddInstitute(factory.GetEducationalInstitution() as Institute);
        
        lvInstitutes.Items.Refresh();
    }

    
    private void LvInstitutes_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        tblErrorDepartmentPanel.Text = string.Empty;
        IsDepartment = false;
        _selected_institute = (Institute)lvInstitutes.SelectedItem;
        lvDeparments.ItemsSource = _selected_institute.Departments;
        SwitchDepartmentTextBox();
        #region Entering data in a Textbox
        tbInstitutionName.Text = _selected_institute.Name;
        tbInstitutionRating.Text = _selected_institute.Rating.ToString();
        tbHeadOfDepartment.Text = _selected_institute.HeadOfInstitution.ToString();
        tbInstitutionPhoneNumber.Text = _selected_institute.PhoneNumber;
        tbNumberOfStudents.Text = _selected_institute.GetNumberOfStudents().ToString();
        #endregion
        
    }

    private void LvDeparments_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        tblErrorDepartmentPanel.Text = string.Empty;
        IsDepartment = true;
        SwitchDepartmentTextBox();
        _selected_department = (Department)lvDeparments.SelectedItem;
        #region Entering data in a Textbox
        tbInstitutionName.Text = _selected_department.Name;
        tbInstitutionRating.Text = _selected_department.Rating.ToString();
        tbHeadOfDepartment.Text = _selected_department.HeadOfInstitution.ToString();
        tbInstitutionPhoneNumber.Text = _selected_department.PhoneNumber;
        tbNumberOfStudents.Text = _selected_department.GetNumberOfStudents().ToString();
        SwitchDepartmentTextBox();
        #endregion

    }
    

    private void BSaveDepartment_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            SwitchDepartmentTextBox();
            var universitycontroller = new UniversityController(_selected_university);
            var institutecontroller = new InstituteController(_selected_institute);
            EducationalInstitutionFactory factory;
            
            //Перевірємо чи це є кафедра
            if (IsDepartment)
            {
                factory = new DepartmentFactory(tbInstitutionName.Text,GetTextBoxInt(tbNumberOfStudents),
                    GetTextBoxInt(tbNumberOfStudents),new Person(tbHeadOfDepartment.Text), tbPhoneNumber.Text);
                institutecontroller.RemoveDepartment(_selected_department);
                _selected_department = factory.GetEducationalInstitution() as Department;
                institutecontroller.AddDepartment(_selected_department);
                universitycontroller.EditInstitute(_selected_institute);
            }
            else
            {
                factory = new InstituteFactory(tbInstitutionName.Text,DateTime.MinValue,
                    new Person(tbHeadOfDepartment.Text),GetTextBoxInt(tbInstitutionRating),tbInstitutionPhoneNumber.Text,
                _selected_institute.Departments);

                
                universitycontroller.RemoveInstitute(_selected_institute);
                universitycontroller.AddInstitute(factory.GetEducationalInstitution() as Institute);
            }
            
            lvInstitutes.Items.Refresh();
            lvDeparments.Items.Refresh();
            TextBoxCleaner(stpDepartmentPanel.Children);
        }
        catch (Exception exception)
        {
            tblErrorDepartmentPanel.Text = exception.Message;  
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

    private int GetTextBoxInt(TextBox tb)
    {
        int val;
        if (int.TryParse(tb.Text, out val))
            return val;
        else
            return -1;
    }
    

    private void Refresh(University uni)
    {
        

    }

    private void BDeleteInstitute_OnClick(object sender, RoutedEventArgs e)
    {
        var universitycontroller = new UniversityController(_selected_university);
        
        universitycontroller.RemoveInstitute(_selected_institute);
        lvInstitutes.Items.Refresh();
        lvDeparments.ItemsSource = null;
        lvDeparments.Items.Refresh();
    }

    private void BRemoveDepartment_OnClick(object sender, RoutedEventArgs e)
    {
        var institutecontroller = new InstituteController(_selected_institute);
        var universitycontroller = new UniversityController(_selected_university);
        
        institutecontroller.RemoveDepartment(_selected_department);
        universitycontroller.EditInstitute(institutecontroller.GetInstitute());
        lvDeparments.Items.Refresh();
    }

    private void BAddDepartment_OnClick(object sender, RoutedEventArgs e)
    {
        if (_selected_institute != null) {
            var controller = new InstituteController(_selected_institute);
        
            var factory = new DepartmentFactory("Нова кафедра", 0, 0, 
                new Person("Ім'я Прізвище"), "0000000000000");
            
            _selected_department = factory.GetEducationalInstitution() as Department;
            controller.AddDepartment(_selected_department);
            lvDeparments.Items.Refresh();
        }
        
    }
}
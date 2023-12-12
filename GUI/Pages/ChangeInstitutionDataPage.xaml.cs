using System.Windows;
using System.Windows.Controls;
using Final_work_OOP_SA22;

namespace GUI.Pages;

public partial class ChangeInstitutionDataPage : Page
{
    private EducationalInstitution _edu;
    private MainWindow.StarPageClick _backpageclick;
    
    
    
    
    public ChangeInstitutionDataPage()
    {
        InitializeComponent();
    }
    public ChangeInstitutionDataPage(EducationalInstitution edu , MainWindow.StarPageClick BackPageClick)
    {
        InitializeComponent();
        _edu = edu;
        tbUniversityName.Text = _edu.Name;
        tbRating.Text = _edu.Rating.ToString();
        tbHeadOfInstitution.Text = _edu.HeadOfInstitution.ToString();
        tbPhoneNumber.Text = _edu.PhoneNumber;
        lNumberOfStudents.Content = $"Кількість студентів: {_edu.NumberOfStudents}";
        
        _backpageclick = BackPageClick;
    }

    private void BReturnBack_OnClick(object sender, RoutedEventArgs e)
    {
        _backpageclick();
    }
}
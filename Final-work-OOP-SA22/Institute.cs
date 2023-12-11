using System.Text;

namespace Final_work_OOP_SA22;

public class Institute : EducationalInstitution
{
    private List<Department> departmentsList;
    
    public Institute(string name, AccreditationLevels accreditationLevel, DateTime foundationDate, 
        Person headOfInstitution, List<Department> departmentsList):base(name,accreditationLevel ,foundationDate, headOfInstitution)
    {
        this.departmentsList = departmentsList;
        this._numberofstudents = GetNumberOfStudents();
    }

    public Institute(Institute institute)
    {
        this._headOfInstitution = institute._headOfInstitution;
        this._rating = institute._rating;
        this.departmentsList = institute.departmentsList;
    }
    
    public void AddDepartment(Department department)
    {
        departmentsList.Add(department);
    }

    public override int GetNumberOfStudents()
    {
        int numberofstudents = 0;

        foreach (var department in departmentsList)
        {
            numberofstudents += department.NumberOfStudents;
        }
        
        return numberofstudents;
    }
    
    public string GetAllDepartments()
    {
        StringBuilder stringBuilder = new();

        foreach (var department in departmentsList)
        {
            stringBuilder.Append(department.ToString()+"\n");
        }

        return stringBuilder.ToString();
    }

    public override string ToString()
    {
        return $"\tНазва:{Name}\n" +
               $"\tДиректор: {_headOfInstitution.ToString()}\n" +
               $"\tДата заснування: {_foundationDate.ToShortDateString()}\n" +
               $"\tРейтинг: {_rating}\n" +
               $"\tНомер телефону: {_phonenumber}\n" +
               $"\tКафедри:\n" +
               $"{GetAllDepartments()}";
    }
}
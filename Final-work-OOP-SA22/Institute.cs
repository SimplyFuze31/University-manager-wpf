using System.Text;

namespace Final_work_OOP_SA22;

internal class Institute : EducationalInstitution
{
    private List<Department> departmentsList;


    public Institute(string name, AccreditationLevels accreditationLevel,
        DateTime foundationDate, Person headOfInstitution,
        int rating, string phoneNumber,List<Department> departmentsList):base(name:name, 
        accreditationLevel ,foundationDate, headOfInstitution,rating,phoneNumber)
    {
        this.departmentsList = departmentsList;
        this._numberofstudents = GetNumberOfStudents();
    }

    public Institute(Institute institute)
    {
        this.headOfInstitution = institute.headOfInstitution;
        this.rating = institute.rating;
        this.departmentsList = institute.departmentsList;
    }
    
    public void AddDepartment(Department department)
    {
        departmentsList.Add(department);
    }
    
    public override void RemoveDepartment(string departmentName)
    {
        throw new NotImplementedException("Make remove from list");
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

    public Department GetDepartment(string departmentname)
    {
        throw new NotImplementedException("Get depatment not work");
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
    public override void PrintInfo()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"Назва:{Name}\n" +
               $"Директор: {headOfInstitution.ToString()}\n" +
               $"Кафедри:\n" +
               $"{GetAllDepartments()}";
    }
}
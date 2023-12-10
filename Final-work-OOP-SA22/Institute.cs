using System.Text;

namespace Final_work_OOP_SA22;

internal class Institute : EducationalInstitution
{
    private Dictionary<string,Department> departmentsDictionary;


    public Institute(Person headofInstitute, Dictionary<string,Department> departmentsDictionary)
    {
        this.headOfInstitution = headofInstitute;
        this.departmentsDictionary = departmentsDictionary;
    }

    public Institute(Institute institute)
    {
        this.headOfInstitution = institute.headOfInstitution;
        this.departmentsDictionary = institute.departmentsDictionary;
    }
    
    public void AddDepartment(Department department)
    {
        departmentsDictionary.Add(department.Name , department);
    }
    
    public override void RemoveDepartment(string departmentName)
    {
        departmentsDictionary.Remove(departmentName);
    }

    public Department GetDepartment(string departmentname)
    {
        try
        {
            return departmentsDictionary[departmentname];
        }
        catch (KeyNotFoundException)
        {
            throw new Exception($"Такої кафедри {departmentname} не існує");
        }
    }
    
    public string GetAllDepartments()
    {
        StringBuilder stringBuilder = new();

        foreach (var department in departmentsDictionary)
        {
            stringBuilder.Append(department.ToString());
        }

        return stringBuilder.ToString();
    }
    public override void PrintInfo()
    {
        throw new NotImplementedException();
    }
    
}
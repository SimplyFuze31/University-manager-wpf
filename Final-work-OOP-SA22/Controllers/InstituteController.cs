namespace Final_work_OOP_SA22.Controllers;

public class InstituteController{

    private Institute? _institute;

    public InstituteController() { }
    public InstituteController(Institute? institute)
    {
        if (institute != null)
            _institute = institute;
    }


    public void AddDepartment(Department department)
    {
        if (_institute != null)
        {
            _institute.Departments.Add(department);
        }
        else 
            throw new Exception("Виберіть інститут");
    }

    public void RemoveDepartment(Department department)
    {
        if (_institute != null)
        {
            _institute.Departments.Remove(department);
        }
        else
        {
            throw new Exception("Виберіть інститут");
        }
    }
}
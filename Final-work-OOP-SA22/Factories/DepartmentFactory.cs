namespace Final_work_OOP_SA22.Factories;

public class DepartmentFactory : EducationalInstitutionFactory
{
    private int _numberofstudents;
    private int _numberofemployees;
    
    public DepartmentFactory(Guid id, string name, int numberofstudents, int numberofemployees, Person headofinstitution, string phonenumber)
    {
        _id = id;
        _name = name;
        _numberofstudents = numberofstudents;
        _numberofemployees = numberofemployees;
        _headOfInstitution = headofinstitution;
        _phonenumber = phonenumber;
    }

    public override EducationalInstitution GetEducationalInstitution()
    {
        try
        {
            return new Department(_id, _name , AccreditationLevels.College , DateTime.MinValue,_headOfInstitution, _numberofemployees,_numberofstudents  )
            {
                PhoneNumber = _phonenumber
                
            };
        }
        catch (Exception e)
        {
            //TODO: Implement exeption
            throw;
        }
    }
}
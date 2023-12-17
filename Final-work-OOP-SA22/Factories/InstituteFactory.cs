namespace Final_work_OOP_SA22.Factories;

public class InstituteFactory : EducationalInstitutionFactory
{
    private ExtendedList<Department> _departmentslist;

    public InstituteFactory(string name,DateTime foundationdate,
        Person headofinstitution, int rating, string phonenumber, ExtendedList<Department> departments) : base( name,foundationdate, headofinstitution, rating, phonenumber)
    {
        _departmentslist = departments;
        _accreditationlevel = AccreditationLevels.Institute;
        
    }
    public override EducationalInstitution GetEducationalInstitution()
    {
        try
        {
            return new Institute(_id,_name, _accreditationlevel, _foundationDate, _headOfInstitution, _departmentslist)
            {
                PhoneNumber = _phonenumber,
                Rating = _rating
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
}
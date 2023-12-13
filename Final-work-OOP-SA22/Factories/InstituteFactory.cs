namespace Final_work_OOP_SA22.Factories;

public class InstituteFactory : EducationalInstitutionFactory
{
    private ExtendedList<Department> _departmentslist;

    public InstituteFactory(Guid id ,string name, AccreditationLevels accreditationLevel, DateTime foundationdate,
        Person headofinstitution, int rating, string phonenumber, ExtendedList<Department> departmentslist) : base( name, accreditationLevel, foundationdate, headofinstitution, rating, phonenumber)
    {
        _id = id;
        _departmentslist = departmentslist;
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
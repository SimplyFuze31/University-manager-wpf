namespace Final_work_OOP_SA22.Factories;

public class UniversityFactory : EducationalInstitutionFactory
{
    private ExtendedList<Institute> _instituteslist;

    public UniversityFactory(Guid id,string name, AccreditationLevels accreditationLevel, DateTime foundationdate,
        Person headofinstitution, int rating, string phonenumber, ExtendedList<Institute> instituteslist) : base(name, accreditationLevel, foundationdate, headofinstitution, rating, phonenumber)
    {
        _id = id;
        _instituteslist = instituteslist;
    }

    public override EducationalInstitution GetEducationalInstitution()
    {
        try
        {
            return new University(_id,_name, _accreditationlevel, _foundationDate, _headOfInstitution, _instituteslist)
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
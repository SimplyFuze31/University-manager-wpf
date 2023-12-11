namespace Final_work_OOP_SA22.Factories;

public abstract class EducationalInstitutionFactory
{
    protected string _name;

    protected AccreditationLevels _accreditationlevel;

    protected DateTime _foundationDate;

    protected int _numberofstudents;

    protected Person _headOfInstitution;

    protected int _rating;
    
    protected string _phonenumber;

    public EducationalInstitutionFactory() { }
    public EducationalInstitutionFactory(string name, AccreditationLevels accreditationLevel, DateTime foundationdate,
        Person headofinstitution, int rating, string phonenumber)
    {
        _name = name;
        _accreditationlevel = accreditationLevel;
        _foundationDate = foundationdate;
        _headOfInstitution = headofinstitution;
        _rating = rating;
        _phonenumber = phonenumber;
    }

    public abstract EducationalInstitution GetEducationalInstitution();
}
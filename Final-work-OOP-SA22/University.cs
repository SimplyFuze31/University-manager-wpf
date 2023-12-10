namespace Final_work_OOP_SA22;

internal class University : EducationalInstitution
{
    private List<Institute> _institutelist = new();
    
    public University(University university):base(university)
    {
        this._institutelist = university._institutelist;
    }
    
    public University(string name, AccreditationLevels accreditationLevel,
        DateTime foundationDate, Person headOfInstitution,
        int rating, string phoneNumber, List<Institute> institutes) : base(name, accreditationLevel, foundationDate,
        headOfInstitution, rating, phoneNumber)
    {
        _institutelist = institutes;
        _numberofstudents = GetNumberOfStudents();
    }


    public void AddDepartment(Institute institute)
    {
        // TODO: Make implementation
        return;
    }

    public override void RemoveDepartment(string departmentName)
    {
        throw new NotImplementedException();
    }

    public override int GetNumberOfStudents()
    {
        int numberofstudents = 0;
        foreach (var institute in _institutelist)
        {
            numberofstudents += institute.NumberOfStudents;
        }

        return numberofstudents;
    }
    
}
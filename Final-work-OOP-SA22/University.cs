namespace Final_work_OOP_SA22;

internal class University : EducationalInstitution
{
    private Dictionary<string, Institute> _institutesdictionary = new();


    public University(University university):base(university)
    {
        this._institutesdictionary = university._institutesdictionary;
    }
    
    // public University(string name, AccreditationLevels accreditationLevel,
    //     DateTime foundationDate, int studentQuantity, Person headOfInstitution,
    //     int rating, string phoneNumber, Dictionary<string,Institute> institutes) : base(name, accreditationLevel, foundationDate, studentQuantity,
    //     headOfInstitution, rating, phoneNumber)
    // {
    //     _institutesdictionary = institutes;
    // }


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
        throw new NotImplementedException();
    }

    public override void PrintInfo()
    {
        throw new NotImplementedException();
    }
}
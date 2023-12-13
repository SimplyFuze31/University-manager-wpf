namespace Final_work_OOP_SA22;

public class Department : EducationalInstitution
{
    private int _numberofemployees;
    public int NumberOfEmployees
    {
        get { return _numberofemployees; }
        set
        {
            if (value > 0)
                _numberofemployees = value;
        }
    }
    private new int _numberofstudents;
        
    public  new int NumberOfStudents
    {
        get { return _numberofstudents; }
        set
        {
            if (value > 0)
                _numberofstudents = value;
        }
    }
    
    public Department(){}
    public Department(Guid id, string name, AccreditationLevels accreditationlevel, DateTime foundationDate, 
        Person headOfInstitution, int numberofemployees,int numberofstudents ) : base(id,name, accreditationlevel, 
        foundationDate, headOfInstitution) 
    {
        _numberofstudents = numberofstudents;
        _numberofemployees = numberofemployees;
    }

    public Department(Department department)
    {
        _name = department._name;
        _phonenumber = department._phonenumber;
        _numberofstudents = department._numberofstudents;
        _numberofemployees = department._numberofemployees;
        _headOfInstitution = department._headOfInstitution;
    }


    public override string ToString()
    {
        return $"\t\tНазва: {Name}\n" +
               $"\t\tЗавідувач кафедри: {HeadOfInstitution.ToString()}\n" +
               $"\t\tКількість співробітників: {NumberOfEmployees}\n" +
               $"\t\tКількість студентів: {GetNumberOfStudents()}\n" +
               $"\t\tНомер телефону: {PhoneNumber}\n";
    }

    public override int GetNumberOfStudents()
    {
        return NumberOfStudents;
    }
}
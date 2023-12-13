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
    
    
    
    
    public Department(){}
    public Department(string name, int numberofstudents, int numberofemployees, Person headOfInstitution) 
    {
        _name = name;
        _numberofstudents = numberofstudents;
        _numberofemployees = numberofemployees;
        _headOfInstitution = headOfInstitution;
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
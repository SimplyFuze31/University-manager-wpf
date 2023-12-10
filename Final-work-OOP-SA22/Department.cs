namespace Final_work_OOP_SA22;

public class Department 
{
    private string _name;
        
    public string Name
    {
        get { return _name; }
    }
    private int _numberofemployees;
    public int NumberOfEmployees
    {
        get { return _numberofemployees; }
    }
    private int _numberofstudents;
    public int NumberOfStudents
    {
        get { return _numberofstudents; }
    }
    private Person headOfInstitution;
    private string phoneNumber;
    public Department(){}
    public Department(string name, int numberofstudents, int numberofemployees, Person headOfInstitution,string phoneNumber) 
    {
        this._name = name;
        this._numberofstudents = numberofstudents;
        this._numberofemployees = numberofemployees;
        this.headOfInstitution = headOfInstitution;
        this.phoneNumber = phoneNumber;

    }

    public Department(Department department) 
    {
        _name = department._name;
        this._numberofstudents = department._numberofstudents;
        this._numberofemployees = department._numberofemployees;
        this.headOfInstitution = department.headOfInstitution;
        this.phoneNumber = department.phoneNumber;
    }


    public override string ToString()
    {
        return $"\tНазва: {_name}\n" +
               $"\tЗавідувач кафедри: {headOfInstitution.ToString()}\n" +
               $"\tКількість співробітників: {NumberOfEmployees}\n" +
               $"\tКількість студентів: {_numberofstudents}\n" +
               $"\tНомер телефону: {phoneNumber}\n";
    }
}
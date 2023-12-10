namespace Final_work_OOP_SA22;

public class Department 
{
    private string name;
        
    public string Name
    {
        get { return name; }
    }
    private int employeesnumber;
    private int studentQuantity;

    private Person headOfInstitution;
    private string phoneNumber;
    public Department(){}
    public Department(string name, int studentQuantity, int employeesnumber, Person headOfInstitution,string phoneNumber) 
    {
        this.name = name;
        this.studentQuantity = studentQuantity;
        this.employeesnumber = employeesnumber;
        this.headOfInstitution = headOfInstitution;
        this.phoneNumber = phoneNumber;

    }

    public Department(Department department) 
    {
        name = department.name;
        this.studentQuantity = department.studentQuantity;
        this.employeesnumber = department.employeesnumber;
        this.headOfInstitution = department.headOfInstitution;
        this.phoneNumber = department.phoneNumber;
    }


    public override string ToString()
    {
        return $"Назва: {name}\n" +
               $"Завідувач кафедри: {headOfInstitution.ToString()}\n" +
               $"Кількість співробітників: {employeesnumber}\n" +
               $"Кількість студентів: {studentQuantity}\n" +
               $"Номер телефону: {phoneNumber}\n";
    }
}
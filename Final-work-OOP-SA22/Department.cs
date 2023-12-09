namespace Final_work_OOP_SA22;

public class Department : EducationalInstitution
{
    
    protected int employeesnumber;


    public Department(){}
    public Department(string name, int studentQuantity, int employeesnumber, Person headOfInstitution,string phoneNumber) 
    {
        base.name = name;
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
        base.headOfInstitution = department.headOfInstitution;
        base.phoneNumber = department.phoneNumber;
    }
    public override void PrintInfo()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"Назва кафедри: {name}\n" +
               $"Завідувач кафедри: {headOfInstitution.ToString()}\n" +
               $"Кількість співробітників: {employeesnumber}\n" +
               $"Кількість студентів: {studentQuantity}\n" +
               $"Номер телефону: {phoneNumber}\n";
    }
}
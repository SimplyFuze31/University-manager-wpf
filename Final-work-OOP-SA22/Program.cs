
using System.Text;
using Final_work_OOP_SA22;


Console.OutputEncoding = Encoding.UTF8;
Department department = new Department("Кафедра інформаційних систем та мереж", 1400, 200, 
    new Person("Василь", "Литвин"), "0322582538");
Console.WriteLine(department.ToString());
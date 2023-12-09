
using System.Text;
using Final_work_OOP_SA22;


Console.OutputEncoding = Encoding.UTF8;


Dictionary<string, Department> departmentsDictionary = new();

departmentsDictionary.Add(
    "Кафедра інформаційних систета мереж", new Department("Кафедра інформаційних систем та мереж", 1400, 200, 
        new Person("Василь", "Литвин"), "0322582538"));

Console.WriteLine(departmentsDictionary["Кафедра інформаційних систем та мереж"].ToString());
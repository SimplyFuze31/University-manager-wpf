
using System.Text;
using Final_work_OOP_SA22;


Console.OutputEncoding = Encoding.UTF8;



var universities = Helper.GenerateUniversities(5);

foreach (var university in universities)
{
    //Console.WriteLine(university.ToString());
    Console.WriteLine(university.NumberOfStudents);
}


using System.Text;
using Final_work_OOP_SA22;


Console.OutputEncoding = Encoding.UTF8;


var institutes = Helper.GenerateInstitutes(3);

foreach (var item in institutes)
{
    Console.WriteLine(item.ToString());
    
}



using System.Text;
using Final_work_OOP_SA22;
using Final_work_OOP_SA22.Extensions;


Console.OutputEncoding = Encoding.UTF8;



var universities = Helper.GenerateUniversities(5);

University findPrestigeUniversity()
{
    return universities.Aggregate((uni1, uni2) => uni1.Rating > uni2.Rating ? uni1 : uni2);
}
University FindBigestNumberOfStudent()
{
    return universities.Aggregate((uni1, uni2) => uni1.NumberOfStudents > uni2.NumberOfStudents ? uni1 : uni2);
}


using (StreamWriter writer = new StreamWriter(@"C:\Users\Simplyfuze\Desktop\CourseWorkOutput.txt"))
{
    writer.WriteLine($"Університет з найбільшою кількістю студентів \n {FindBigestNumberOfStudent().ToString()}" );
    writer.WriteLine($"Унівирситет з найбільшим рейтингом: \n {findPrestigeUniversity().ToString()}");
}

Console.WriteLine($"Університет з найбільшою кількістю студентів \n {FindBigestNumberOfStudent().ToString()}" );
Console.WriteLine($"Унівирситет з найбільшим рейтингом: \n {findPrestigeUniversity().ToString()}");
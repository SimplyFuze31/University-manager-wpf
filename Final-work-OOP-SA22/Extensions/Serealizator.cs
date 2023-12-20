using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Final_work_OOP_SA22.Extensions;

public class Serealizator
{
    private static string _path = @"C:\Users\Simplyfuze\OOP-SA22\data.json";


    public static void Save(ExtendedList<University> edu)
    {
        using (StreamWriter writer = new StreamWriter(_path))
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true,
                IncludeFields = true
            };
                writer.WriteLine(JsonSerializer.Serialize(edu,options));
            
           
        }
    }

    public static ExtendedList<University> Load()
    {
        ExtendedList<University>? edu = new ExtendedList<University>();
        using (StreamReader reader = new StreamReader(_path))
        {
            try
            {
                edu =  JsonSerializer.Deserialize<ExtendedList<University>>(reader.ReadToEnd());
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
            }
            
        }
        
        return edu;
    }
    
   
}
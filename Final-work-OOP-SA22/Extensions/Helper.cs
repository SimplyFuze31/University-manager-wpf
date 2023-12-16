using System.Text.RegularExpressions;
using Final_work_OOP_SA22.Factories;

namespace Final_work_OOP_SA22;
public static class Helper{
    public const string MatchNamePattern = "^[А-ЯІЇЄҐа-яіїєґ]{2,}$";
    public const string MatchFullNamePattern = @"^[А-ЯІЇЄҐа-яіїєґ]{2,}(?:\s[А-ЯІЇЄҐа-яіїєґ]{3,})$";
    public const string MatchPhoneNumber = @"^\+?[0-9\s()-]{10,}$";
    
    static DateTime RandomDay()
    {
        Random gen = new Random();
        DateTime start = new DateTime(1995, 1, 1);
        int range = (DateTime.Today - start).Days;           
        return start.AddDays(gen.Next(range));
    }
    
    public static string GeneratePhoneNumber()
    {
        var random = new Random();
        string s = string.Empty;
        for (int i = 0; i <= 10; i++)
            s = String.Concat(s, random.Next(10).ToString());
        return s;
    }
    
    public static string GenerateIdNumber()
    {
        var random = new Random();
        string s = string.Empty;
        for (int i = 0; i <= 24; i++)
            s = String.Concat(s, random.Next(10).ToString());
        return s;
    }

    public static string GenerateUniversityName()
    {
        Random random = new Random();
        return $"Університет імені {Names[random.Next(0, Names.Length)]} {LastNames[random.Next(0, LastNames.Length)]}";
    }
    private static string[] InstitutesName = new[]
    {
        "Інститут комп'ютерних наук та інформаційних технологій",
        "Інститут комп'ютерних технологій, автоматики та метрології",
        "Інститут архітектури та дизайну",
        "Інститут гуманітарних та соціальних наук",
        "Інститут розробки та дослідження штучного інтелекту"
    };
    
    
    private static string[] DepartmentsName = new[]
    {
        "Кафедра комп'ютерних наук",
        "Кафедра інформаційних технологій",
        "Кафедра комп'ютерних технологій",
        "Кафедра автоматики та метрології",
        "Кафедра архітектури та дизайну",
        "Кафедра гуманітарних наук",
        "Кафедра соціальних наук",
        "Кафедра розробки штучного інтелекту"
    };

    private static string[] Names = new[]
    {
        "Богдан", "Андрій", "Олександр", "Сергій", "Микола","Василь","Ігор","Владислав","Олег","Надія"
    };

    private static string[] LastNames = new[]
    {
        "Черкес","Медиковський","Микийчук","Костів","Кондратюк","Юзьвак","Стахів","Литвин","Філевич"
    };
    private static Person GeneratePerson()
    {
        Random random = new();
        string name = Names[random.Next(0, Names.Length)];
        string lastname = LastNames[random.Next(0, LastNames.Length)];
        return new Person(name, lastname);
    }
    
    private static ExtendedList<Institute> GenerateInstitutes(int count)
    {
        ExtendedList<Institute> institutes = new();

        EducationalInstitutionFactory factory;
        Random random = new();
        
        for (int i = 0; i < count; i++)
        {
            string institutename = InstitutesName[random.Next(0, InstitutesName.Length)];
            int rating = random.Next(50, 100);
            var id = Guid.NewGuid();
            factory = new InstituteFactory(id,institutename, AccreditationLevels.Institute, RandomDay(),
                GeneratePerson(),rating,GeneratePhoneNumber(),GenerateDepartments(random.Next(3,7)));
            institutes.Add((Institute)factory.GetEducationalInstitution());
        }
    
        return institutes;
    }
    
    //
    private static ExtendedList<Department> GenerateDepartments(int count)
    {
        ExtendedList<Department> departments = new();
        Random random = new();
        EducationalInstitutionFactory factory;
        for (int i = 0; i < count; i++)
        { 
            string name = DepartmentsName[random.Next(0, DepartmentsName.Length)];
            factory = new DepartmentFactory(Guid.NewGuid(),name, random.Next(400, 2000), random.Next(40, 200), GeneratePerson(),
                GeneratePhoneNumber());
            departments.Add((Department)factory.GetEducationalInstitution());
        }
    
        return departments;
    }
    //
    public static ExtendedList<University> GenerateUniversities(int count)
    {
        EducationalInstitutionFactory factory;
        ExtendedList<University> universities = new();
        Random random = new();
        for (int i = 0; i < count; i++)
        {
            string univertyname = InstitutesName[random.Next(0, InstitutesName.Length)];
            int rating = random.Next(50, 100);
            var institutes = GenerateInstitutes(random.Next(3,10));
            factory = new UniversityFactory(Guid.NewGuid(),GenerateUniversityName(), AccreditationLevels.University, RandomDay(),
                GeneratePerson(),rating,GeneratePhoneNumber(),institutes);
            universities.Add((University)factory.GetEducationalInstitution());
        }
    
        return universities;
    }
}
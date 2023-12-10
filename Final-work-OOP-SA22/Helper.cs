namespace Final_work_OOP_SA22;

public static class Helper
{
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
        "Богдан", "Андрій", "Олександр", "Сергій", "Микола","Стахів"
    };

    private static string[] LastNames = new[]
    {
        "Черкес","Медиковський","Микийчук","Костів",
    };
    public static Person GeneratePerson()
    {
        Random random = new();
        string name = Names[random.Next(0, Names.Length - 1)];
        string lastname = LastNames[random.Next(0, LastNames.Length - 1)];
        return new Person(name, lastname);
    }
    
    public static List<EducationalInstitution> GenerateInstitutes(int count)
    {
        List<EducationalInstitution> institutes = new();
        Random random = new();
        
        for (int i = 0; i < count; i++)
        {
            var departments = GenerateDepartments(5);
            institutes.Add(new Institute(InstitutesName[i],AccreditationLevels.Institute, DateTime.Now ,
                GeneratePerson(),random.Next(90,100),random.Next(10000000,900000000).ToString(),departments));
        }

        return institutes;
    }
    
    
    public static List<Department> GenerateDepartments(int count)
    {
        List<Department> departments = new();
        Random random = new();
        for (int i = 0; i < count; i++)
        {
            
            departments.Add(new Department(DepartmentsName[random.Next(0,DepartmentsName.Length)],random.Next(300,2000),
                random.Next(20,400),GeneratePerson(),random.Next(10000000,900000000).ToString()));
        }

        return departments;
    }
}
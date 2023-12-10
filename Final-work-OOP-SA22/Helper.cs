namespace Final_work_OOP_SA22;

internal static class Helper
{
    private static string[] InstitutesName = new[]
    {
        "Інститут комп'ютерних наук та інформаційних технологій",
        "Інститут комп'ютерних технологій, автоматики та метрології",
        "Інститут архітектури та дизайну"
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
        string lastname = LastNames[random.Next(0, Names.Length - 1)];
        return new Person(name, lastname);
    }
    
    public static Dictionary<string, Institute> GenerateInstitutes(int count)
    {
        Dictionary<string, Institute> institutes = new();
        for (int i = 0; i < count; i++)
        {
            institutes.Add(InstitutesName[i],new Institute(GeneratePerson(), new Dictionary<string, Department>()));
        }

        return institutes;
    }
}
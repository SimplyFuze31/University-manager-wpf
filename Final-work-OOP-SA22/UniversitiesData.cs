namespace Final_work_OOP_SA22;

public sealed class UniversitiesData
{
    public List<University> _universities { get; set; }
    
    private UniversitiesData()
    {
        
    }
    
    private static UniversitiesData _instance;


    public static UniversitiesData GetInstance()
    {
        if (_instance == null)
        {
            _instance = new UniversitiesData();
            return _instance;
        }
        else
        {
            return null;
        }
    }
    public void AddUniversity(University uni)
    {
        _universities.Add(uni);
    }




}
using System.Text;

namespace Final_work_OOP_SA22;

public class University : EducationalInstitution
{
    private ExtendedList<Institute> _institutelist;
    
    public ExtendedList<Institute> Institutes
    {
        get { return _institutelist; }
        set
        {
            _institutelist = value;
        }
    }

    public University()
    {
    }
    public University(University university):base(university)
    {
        this._institutelist = university._institutelist;
        NumberOfStudents = this.GetNumberOfStudents();
    }
    
    public University(Guid id, string name, AccreditationLevels accreditationlevel, DateTime foundationDate, 
        Person headOfInstitution, ExtendedList<Institute> institutes) : base(id,name, accreditationlevel, 
        foundationDate, headOfInstitution)
    {
        _institutelist = institutes;
        _numberofstudents = GetNumberOfStudents();
    }
    
    public sealed override int GetNumberOfStudents()
    {
        
        int numberofstudents = 0;
        if (this.Institutes != null)
        {
            foreach (var institute in _institutelist)
            {
                numberofstudents += institute.NumberOfStudents;
            }
        }
        return numberofstudents;
    }
    
    public string GetAllDepartments()
    {
        StringBuilder stringBuilder = new();

        foreach (var institute in _institutelist)
        {
            stringBuilder.Append(institute.ToString()+"\n");
        }

        return stringBuilder.ToString();
    }

    public override string ToString()
    {
        return$"Назва:{Name}\n" +
              $"Директор: {_headOfInstitution.ToString()}\n" +
              $"Дата заснування: {_foundationDate.ToShortDateString()}\n" +
              $"Рейтинг: {_rating}\n" +
              $"Номер телефону: {_phonenumber}\n" +
              $"Кількість студентів {GetNumberOfStudents()}\n" +
              $"Інститути:\n" +
              $"{GetAllDepartments()}";
    }
}
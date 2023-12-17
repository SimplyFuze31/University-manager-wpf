using Final_work_OOP_SA22.Extensions;

namespace Final_work_OOP_SA22.Controllers;

public class UniversityController{
    private University? _university;

    public UniversityController(University university)
    {
        _university = university;
    }

    public void AddUniversity()
    {
        if (_university != null)
        {
            ExtendedList<University> uni = Serealizator.Load();
            if(uni.Exists(u => u.Id == _university.Id))
                EditUniversity();
            else
            {
                uni.Add(_university);
                Serealizator.Save(uni);
            }
        }
    }

    public void EditUniversity()
    {
        if (_university != null)
        {
            ExtendedList<University> uni = Serealizator.Load();
            uni.Replace(_university);
            Serealizator.Save(uni);
        }
    }

    public void RemoveUniversity()
    {
        if (_university != null)
        {
            ExtendedList<University> uni = Serealizator.Load();
            uni.Remove(_university);
            Serealizator.Save(uni);
        }
    }

    public void AddInstitute(Institute? institute)
    {
        if (institute != null && _university != null)
        {
            if (_university.Institutes.Exists(ins => ins.Id == institute.Id))
            {
                _university.Institutes.Replace(institute);
            }
            else
            {
                _university.Institutes.Add(institute);
            }
            AddUniversity();
        }
    }

    public void RemoveInstitute(Institute? institute)
    {
        if (institute != null && _university != null)
        {
            if (_university.Institutes.Exists(ins => ins.Id == institute.Id))
            {
                _university.Institutes.Remove(institute);
                AddUniversity();
            }
        }
    }
}
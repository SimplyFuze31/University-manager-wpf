using Final_work_OOP_SA22.Extensions;

namespace Final_work_OOP_SA22.Controllers;

public class UniversityController{
    private University? _university;

    public UniversityController()
    {
        
    }
    public UniversityController(University university)
    {
        _university = university;
    }

    public void AddUniversity()
    {
        if (_university != null)
        {
            var uni = Serealizator.Load();
            
            uni.Insert(0,_university);
            Serealizator.Save(uni);
        }
    }

    public void EditUniversity()
    {
        if (_university != null)
        {
            var uni = Serealizator.Load();
            uni.Replace(_university);
            Serealizator.Save(uni);
        }
    }

    public IEnumerable<University> SortUniversities(int parametr,bool OrderBy)
    {

            IEnumerable<University> sorted;
            var uni = Serealizator.Load();
            switch (parametr)
            {
                case 0:
                    if (!OrderBy)
                        sorted = uni.OrderByDescending(s => s.Name);
                    else
                        sorted = uni.OrderBy(s => s.Name);
                    return sorted;
                case 1:
                    if (!OrderBy)
                        sorted = uni.OrderByDescending(s => s.HeadOfInstitution.ToString());
                    else
                        sorted = uni.OrderBy(s => s.HeadOfInstitution.ToString());
                    return sorted;
                case 2:
                    if (!OrderBy)
                        sorted = uni.OrderByDescending(s => s.Rating);
                    else
                        sorted = uni.OrderBy(s => s.Rating);
                    return sorted;
                case 3:
                    if (!OrderBy)
                        sorted = uni.OrderByDescending(s => s.NumberOfStudents);
                    else
                        sorted = uni.OrderBy(s => s.NumberOfStudents);
                    return sorted;
                // case 4:
                //     if (!OrderBy)
                //         sorted = uni.OrderByDescending(s => s.ShelfLife);
                //     else
                //         sorted = uni..OrderBy(s => s.ShelfLife);
                //     return sorted;
            }
            return null;
        
    }

    public void RemoveUniversity()
    {
        if (_university != null)
        {
            var uni = Serealizator.Load();
                uni.RemoveAt(uni.FindIndex(univer => univer.Id == _university.Id));
                Serealizator.Save(uni);
            
        }
    }

    public void AddInstitute(Institute? institute)
    {
        if (_university != null)
        {
            _university.Institutes.Insert(0,institute);
            EditUniversity();
        }
    }

    public void EditInstitute(Institute institute)
    {
        if (_university != null)
        {
            _university.Institutes.Replace(institute);
            EditUniversity();   
        }
        
    }

    public void RemoveInstitute(Institute? institute)
    {
        if (institute != null && _university != null)
            if (_university.Institutes.Exists(ins => ins.Id == institute.Id))
            {
                _university -= institute;
                EditUniversity();
            }
    }
    
    
    
}
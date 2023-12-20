﻿using Final_work_OOP_SA22.Extensions;

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

    public void RemoveUniversity()
    {
        if (_university != null)
        {
            
            var uni = Serealizator.Load();
            if (uni.Exists(univer => univer.Id == _university.Id))
            {
                uni.RemoveAt(uni.FindIndex(univer => univer.Id == _university.Id));
            }
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
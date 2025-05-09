﻿using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Departments;

namespace schoolapp.Domain.Entities.People
{
    public class Teacher : Person
    {
        public string? TeacherId { get; set; }
        public string? RegNo { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public List<Department> Departments { get; set; }
        public List<SchoolSubject> SubjectsQualified { get; set; } = [];
        public List<ClassRoom> ClassesResponsibleFor { get; set; } = new List<ClassRoom>();
        public Teacher()
        {
            SubjectsQualified = new List<SchoolSubject>();
            ClassesResponsibleFor = new List<ClassRoom>();
        }
        public void AssignAsClassTeacher(ClassRoom classroom)
        {
            classroom.ClassTeacher = this;
            if (!ClassesResponsibleFor.Contains(classroom))
            {
                ClassesResponsibleFor.Add(classroom);
            }
        }

    }
}

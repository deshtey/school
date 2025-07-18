﻿using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class Parent : Person
    {
        public int SchoolId { get; set; }
        public int StudentId { get; set; }
        public List<Student> Students { get; set; } = [];
        public List<StudentParent> StudentParents { get; set; } = [];
        public School School { get; set; }

        public Parent(string firstName, string lastName, string phone,  int schoolId, Gender gender) : base(firstName, lastName, schoolId, gender)
        {
            Phone = phone?.Trim();
        }
        public static Parent? Create(string firstName, string lastName, string phone,  int schoolId, Gender gender)
        {
            return new Parent(firstName, lastName, phone,  schoolId, gender);
        }
    }
}

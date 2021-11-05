using System;
using System.Collections.Generic;
using FamilyTies.Enums;

namespace FamilyTies.Models
{
    public class Person
    {
        public Person(string name, DateTime birthdate, Gender gender, Person mother, Person father, Person spouse)
        {
            Name = name;
            Birthdate = birthdate;
            Gender = gender;
            Mother = mother;
            Father = father;
            Spouse = spouse;
            Children = new List<Person>();
        }

        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public Person Mother { get; set; }
        public Person Father { get; set; }
        public List<Person> Children { get; set; }

        /// <summary>
        /// С кем состоит в отношениях
        /// </summary>
        public Person Spouse { get; set; }
    }
}
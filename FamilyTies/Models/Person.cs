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
            _mother = mother;
            _father = father;
            _spouse = spouse;
            _children = new List<Person>();
        }

        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }

        private Person _mother;
        private Person _father;
        private List<Person> _children;

        public Person Mother
        {
            get => _mother;
            set
            {
                if (!_children.Contains(value))
                    _mother = value;
            }
        }

        public Person Father
        {
            get => _father;
            set
            {
                if (!_children.Contains(value))
                    _father = value;
            }
        }


        /// <summary>
        /// С кем состоит в отношениях
        /// </summary>
        private Person _spouse;

        public Person Spouse
        {
            get => _spouse;
            set
            {
                if (_spouse is null && value.Spouse is null)
                    _spouse = value;
            }
        }

        public void AddChild(Person child)
        {
            if (child?.Mother == this || child?.Father == this)
                _children.Add(child);
        }

        public List<Person> GetChildren() => _children;
    }
}
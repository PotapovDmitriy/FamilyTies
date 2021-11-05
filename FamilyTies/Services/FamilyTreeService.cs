using System;
using System.Collections.Generic;
using System.Linq;
using FamilyTies.Enums;
using FamilyTies.Models;

namespace FamilyTies.Services
{
    public static class FamilyTreeService
    {
        public static Person CreatePerson(string name, DateTime birthdate, Gender gender, Person mother = null,
            Person father = null, Person spouse = null)
        {
            var person = new Person(name, birthdate, gender, mother, father, spouse);
            mother?.Children.Add(person);
            father?.Children.Add(person);
            if (spouse is not null)
                spouse.Spouse = person;

            return person;
        }

        public static IList<Person> GetParentsList(Person person)
            => new List<Person>
            {
                person.Father, person.Mother
            };

        public static IEnumerable<Person> GetUnclesAndAuntsList(Person person)
        {
            var parents = GetParentsList(person);
            var grandParents = new List<Person>();
            foreach (var parent in parents)
            {
                if (parent is null)
                    continue;

                grandParents.AddRange(GetParentsList(parent));
            }

            return grandParents.SelectMany(i => i?.Children)
                .Where(i => !parents.Contains(i))
                .ToHashSet();
        }

        public static IEnumerable<Person> GetCousinsList(Person person)
        {
            var result = new List<Person>();

            var unclesAndAunts = GetUnclesAndAuntsList(person);
            foreach (var item in unclesAndAunts)
                result.AddRange(item.Children);

            return result.ToHashSet();
        }

        public static IEnumerable<Person> GetInLawsList(Person person)
            => person.Spouse is null ? null : GetParentsList(person.Spouse);
    }
}
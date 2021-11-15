using System;
using FamilyTies.Enums;
using FamilyTies.Services;

namespace FamilyTies
{
    class Program
    {
        static void Main(string[] args)
        {
            var grandMotherM = FamilyTreeService.CreatePerson("Бабушка м", DateTime.Now, Gender.Female);
            var grandFatherM = FamilyTreeService.CreatePerson("Дедушка м", DateTime.Now, Gender.Male);
            var grandMotherF = FamilyTreeService.CreatePerson("Бабушка п", DateTime.Now, Gender.Female);
            var grandFatherF = FamilyTreeService.CreatePerson("Дедушка п", DateTime.Now, Gender.Male);
            var mother = FamilyTreeService.CreatePerson("Мама", DateTime.Now, Gender.Female,
                grandMotherM, grandMotherM);
            var father = FamilyTreeService.CreatePerson("Папа", DateTime.Now, Gender.Male,
                grandMotherF, grandFatherF);
            var uncleF = FamilyTreeService.CreatePerson("Дядя п", DateTime.Now, Gender.Male,
                grandMotherF, grandFatherF);
            var auntF = FamilyTreeService.CreatePerson("Тетя П", DateTime.Now, Gender.Female,
                grandMotherF, grandFatherF);
            var auntM = FamilyTreeService.CreatePerson("Тетя M", DateTime.Now, Gender.Female,
                grandMotherM, grandFatherM);
            var cousin1 = FamilyTreeService.CreatePerson("кузин 1", DateTime.Now, Gender.Male,
                auntM);
            var cousin2 = FamilyTreeService.CreatePerson("кузина 2", DateTime.Now, Gender.Female,
                auntF);
            var cousin3 = FamilyTreeService.CreatePerson("кузин 3 ", DateTime.Now, Gender.Male,
                null, uncleF);
            
            
            var person = FamilyTreeService.CreatePerson("Тот самый", DateTime.Now, Gender.Male);


            var parents = FamilyTreeService.GetParentsList(person);
            var unclesAndAunts = FamilyTreeService.GetUnclesAndAuntsList(person);
            var cousins = FamilyTreeService.GetCousinsList(person);

            var inLaws = FamilyTreeService.GetInLawsList(person);


        }
    }
}
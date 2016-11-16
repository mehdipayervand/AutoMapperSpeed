using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using AutoMapper;
using AutoMapperSpeed.Domain.Tests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperSpeed.Domain.Tests
{
    [TestClass]
    public class MappingPersonToPersonDtoTests
    {
        private ReadOnlyCollection<Person> persons;
        public MappingPersonToPersonDtoTests()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Person, PersonDto>());
        }

[TestMethod]
public void FillPersonDtoList_AutoMapperShouldMapPersonListToPersonDtoList_WhenLargeAmountOfPerson()
{
    // arrange
    var personDtoList = new List<PersonDto>(); persons = new PersonList().GetPersons();

    // act
    personDtoList = Mapper.Map<List<PersonDto>>(persons);

    //assert
    Assert.AreEqual(persons.Count, personDtoList.Count);
}

[TestMethod]
public void FillPersonDtoList_UsingHandlyAssignment_WhenLargeAmountOfPerson()
{
    // arrange
    var personDtoList = new List<PersonDto>(); persons = new PersonList().GetPersons();

    // act
    foreach (var person in persons)
    {
        personDtoList.Add(new PersonDto(person.PersonId, person.Name, person.Family, person.PersonType));
    }

    //assert
    Assert.AreEqual(persons.Count, personDtoList.Count);
}
    }
}

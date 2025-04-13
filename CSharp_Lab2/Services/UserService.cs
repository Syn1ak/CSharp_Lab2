using CSharp_Lab2.Exceptions;
using CSharp_Lab2.Models;
using CSharp_Lab2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab2.Services
{
    class UserService
    {
        private UserRepository Repository = new UserRepository();

        public List<Person> GetAllUsers()
        {
            var res = new List<Person>();
            foreach (var person in Repository.GetAll())
            {
                res.Add(new Person(person.Name, person.Surname, person.Email, person.BirthDate));
            }
            return res;
        }

        public async Task<bool> AddPerson(Person person)
        {
            UserDto dBUser = await Repository.GetAsync(person.Email);
            if (dBUser != null)
            {
                throw new PersonValidationException("User already exist");
            }
            var dbUser = new UserDto(person.Name, person.Surname, person.Email, person.Birthdate);
            await Repository.AddAsync(dbUser);
            return true;
        }

        public async Task<bool> UpdatePerson(Person person, string email)
        {
            DeletePerson(email);
            var dbUser = new UserDto(person.Name, person.Surname, person.Email, person.Birthdate);
            await Repository.AddAsync(dbUser);
            return true;
        }

        public bool DeletePerson(string email)
        {
            Repository.Delete(email);
            return true;
        }
    }
}

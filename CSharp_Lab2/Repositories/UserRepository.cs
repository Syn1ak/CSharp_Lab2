using CSharp_Lab2.Exceptions;
using CSharp_Lab2.Models;
using CSharp_Lab2.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSharp_Lab2.Repositories
{
    class UserRepository
    {
        private static readonly string BaseFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UsersStorage");
        public UserRepository()
        {
            if (Directory.Exists(BaseFolder)) return;
            Directory.CreateDirectory(BaseFolder);
            UserCreator.getUsers().ForEach(u => AddAsync(u));
        }

        public async Task AddAsync(UserDto dbUser)
        {
            var stringObj = JsonSerializer.Serialize(dbUser);

            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, dbUser.Email), false))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public void Delete(string email)
        {
            if (File.Exists(Path.Combine(BaseFolder, email)))
            {
                File.Delete(Path.Combine(BaseFolder, email));
            }
            else
            {
                throw new PersonNotFoundException("Person with email " + email + " doesn't exist!");
            }
        }

        public async Task<UserDto> GetAsync(string email)
        {
            string stringObj = null;
            string filePath = Path.Combine(BaseFolder, email);

            if (!File.Exists(filePath))
                return null;

            using (StreamReader sw = new StreamReader(filePath))
            {
                stringObj = await sw.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<UserDto>(stringObj);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var res = new List<UserDto>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = await sw.ReadToEndAsync();
                }

                res.Add(JsonSerializer.Deserialize<UserDto>(stringObj));
            }

            return res;
        }

        public List<UserDto> GetAll()
        {
            var res = new List<UserDto>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = sw.ReadToEnd();
                }

                res.Add(JsonSerializer.Deserialize<UserDto>(stringObj));
            }

            return res;
        }
    }
}

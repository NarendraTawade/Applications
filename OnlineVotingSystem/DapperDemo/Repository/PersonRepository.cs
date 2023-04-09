using DapperDemo.Data;
using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Repository
{
    public class PersonRepository : IPersonRepository1
    {
        private readonly IDataAccess _db;
        public PersonRepository(IDataAccess db)
        {
            _db = db;
        }
        public async Task<bool> AddPerson(Person person)
        {
            try
            {
                string query = @"insert into dbo.users values (@Name, @Email)";
                await _db.SaveData(query, new { Name = person.Name, Email = person.Email });
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> DeletePerson(int id)
        {
            try
            {
                string query = @"delete from users where id=@Id";
                await _db.SaveData(query,new {Id=id});
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            string query = @"Select * from dbo.users";
            var people = await _db.GetData<Person, dynamic>(query, new { });
            return people;
                
        }

        public async Task<Person> GetPersonById(int id)
        {
            string query = @"Select * from dbo.users where id = @Id";
            IEnumerable<Person> people = await _db.GetData<Person, dynamic>(query, new { Id =id});
            return people.FirstOrDefault();
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            try
            {
                string query = @"update dbo.users set name=@Name,email=@Email where id=@Id";
                await _db.SaveData(query,person);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}

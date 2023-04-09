using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Repository
{
    public interface IPersonRepository1
    {
        Task<Person> AddPerson(Person person);
        Task<bool> UpdatePerson(Person person);

        Task<Person> GetPersonById(int id);
        Task<bool> DeletePerson(int id);


        Task<IEnumerable<Person>> GetPeople();

    }
}

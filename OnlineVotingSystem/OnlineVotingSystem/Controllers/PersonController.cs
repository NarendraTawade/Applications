using DapperDemo.Models;
using DapperDemo.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineVotingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository1 _personRepository;

        public PersonController(IPersonRepository1 personRepository)
        {
            _personRepository = personRepository;
        }
        
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var people = await _personRepository.GetPeople();
            return Ok(people);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _personRepository.GetPersonById(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            var result = await _personRepository.AddPerson(person);
            if (!result)
                return BadRequest("Could not save data");
            return Ok(result);  
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person newPerson)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            var person = await _personRepository.GetPersonById(id);
            if (person is null)
                return NotFound();
            newPerson.Id = id;
            var result = await _personRepository.UpdatePerson(newPerson);
            if (!result)
                return BadRequest("Could not save data");
            return Ok(result);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            var person = await _personRepository.GetPersonById(id);
            if (person is null)
                return NotFound();
            var result = await _personRepository.DeletePerson(id);
            if (!result)
                return BadRequest("Could not save data");
            return Ok(result);
        }
    }
}

using AvanceradDotNetLabb4.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AvanceradDotNetLabb4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonDataController : ControllerBase
    {
        private readonly IPersonDataRepository _personDataRepository;

        public PersonDataController(IPersonDataRepository personDataRepository)
        {
            _personDataRepository = personDataRepository;
        }

        [HttpGet("ListAllPersons")]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                var persons = await _personDataRepository.GetAllPersons();
                return Ok(persons);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("ListInterestsByPerson")]
        public async Task<IActionResult> ListInterestsByPerson(int personId)
        {
            try
            {
                var interests = await _personDataRepository.GetPersonsInterests(personId);
                return Ok(interests);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("ListLinksByPerson")]
        public async Task<IActionResult> ListLinksByPerson(int personId)
        {
            try
            {
                var links = await _personDataRepository.GetAllPersonsLinks(personId);
                return Ok(links);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost("AddNewInterestPerson")]
        public async Task<IActionResult> AddNewInterestPerson(int interestId, int personId)
        {
            try
            {
                var result = await _personDataRepository.AddNewInterestToPerson(interestId, personId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost("AddNewLink")]
        public async Task<IActionResult> AddNewLink(string url, int fkInterestPersonId)
        {
            try
            {
                var result = await _personDataRepository.AddNewLink(url, fkInterestPersonId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApplication.Models;
namespace webApplication.Controllers
{
    [Route("api/animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private AnimalContext _context;

        public AnimalController(AnimalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimalList()
        {
            return await _context.Animal.ToListAsync();
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Animal>> GetAnimal(int ID)
        {
            try
            {
                var animal = await _context.Animal.FindAsync(ID);
                if (animal == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(animal);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Animal>> AddAnimal(Animal animal)
        {
            int idToAdd = (from n in _context.Animal orderby n.ID descending select n.ID).FirstOrDefault();

            animal.ID = idToAdd + 1;
            _context.Animal.Add(animal);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Give")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimalList([FromBody] List<int> animallist)
        {
            List<Animal> animalllist = _context.Animal.ToList();
            List<Animal> returnlist = new List<Animal>();
            foreach (int ID in animallist)
            {
                Animal animal = animalllist.Find(x => x.ID == ID);
                if (animal != null) 
                {
                    returnlist.Add(animal);
                }
            }
            return Ok(returnlist);
        }
    }
}

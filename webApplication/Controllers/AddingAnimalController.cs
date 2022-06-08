using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApplication.Models;
namespace webApplication.Controllers
{
    [Route("api/addinganimal")]
    public class AddingAnimalController : ControllerBase
    {
        private AnimalPictureFrontContext _context;
        private AnimalContext _context1;
        private PictureContext _context2;
        private AnimalPicContext _context3;
        private AnimalUserContext _context4;

        public AddingAnimalController(AnimalPictureFrontContext context, AnimalContext context1, PictureContext context2, AnimalPicContext context3, AnimalUserContext context4)
        {
            _context = context;
            _context1 = context1;
            _context2 = context2;
            _context3 = context3;
            _context4 = context4;
        }

        [HttpPost]
        public async Task<ActionResult<AnimalPictureFront>> AddAnimal([FromBody]AnimalPictureFront animalall)
        {
            Animal animal = new Animal();
            AnimalPic animalpic = new AnimalPic();
            Picture picture = new Picture();
            AnimalUser animalUser = new AnimalUser();

            int idToAdd = (from n in _context1.Animal orderby n.ID descending select n.ID).FirstOrDefault();
            int idToAdd2 = (from n in _context2.Pictures orderby n.PicID descending select n.PicID).FirstOrDefault();
            int idToAdd3 = (from n in _context3.AnimalPic orderby n.ID descending select n.ID).FirstOrDefault();
            int idToAdd4 = (from n in _context4.AnimalUser orderby n.ID descending select n.ID).FirstOrDefault();

            animal.ID = idToAdd + 1;
            animal.Price = animalall.Price;
            animal.Breed = animalall.Breed;
            animal.Age = animalall.Age;
            animal.AnimalType = animalall.AnimalType;
            animal.Coord = animalall.Coord;
            animal.Description = animalall.description;

            if (animalall.Image != null)
            {
                picture.PicID = idToAdd2 + 1;
                picture.Image = animalall.Image;

                animalpic.ID = idToAdd2 + 1;
                animalpic.PicID = idToAdd3 + 1;
                animalpic.AnimalID = animal.ID;

                _context2.Pictures.Add(picture);
                _context3.AnimalPic.Add(animalpic);

                await _context2.SaveChangesAsync();
                await _context3.SaveChangesAsync();
            }

            animalUser.ID = idToAdd4 + 1;
            animalUser.AnimalID = animalall.ID;
            animalUser.UserID = animalall.userID;

            _context1.Animal.Add(animal);
            _context4.AnimalUser.Add(animalUser);

            await _context1.SaveChangesAsync();
            await _context4.SaveChangesAsync();
            return Ok();
        }

    }
}

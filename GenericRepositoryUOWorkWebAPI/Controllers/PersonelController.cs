using GenericRepositoryUOWorkWebAPI.Configuration;
using GenericRepositoryUOWorkWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryUOWorkWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public PersonelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Personel> personeller = await _unitOfWork.Personel.GetirHepsi();
            
            
            return Ok(personeller);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonel(Guid id)
        {
            var item = await _unitOfWork.Personel.GetirById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
        // POST: api/personel
        [HttpPost]
        public async Task<IActionResult> CreatePersonel(Personel personel)
        {
            if (ModelState.IsValid)
            {
                personel.Id = Guid.NewGuid();

                await _unitOfWork.Personel.Ekle(personel);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetEmployee", new { personel.Id }, personel);
            }

            return new JsonResult("Hata Oluştu") { StatusCode = 500 };
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonel(Guid id)
        {
            Personel personel= await _unitOfWork.Personel.GetirById(id);

            if (personel == null)
                return BadRequest();

            await _unitOfWork.Personel.Sil(id);
            await _unitOfWork.CompleteAsync();

            return Ok(personel);
        }


    }
}

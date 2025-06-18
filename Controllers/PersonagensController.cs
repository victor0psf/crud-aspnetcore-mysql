using CrudVF.Data;
using CrudVF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudVF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonagensController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appDbContext.PB.Add(personagem);
            await _appDbContext.SaveChangesAsync();

            return Created("Personagem Criado com sucesso!", personagem);
        }
        /*
        [HttpGet]
        public async Task<IActionResult> GetPersonagens()
        {
            var personagens = await _appDbContext.PB.ToListAsync();
            return Ok(personagens);
        } 
        */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
        {
            var personagens = await _appDbContext.PB.ToListAsync();
            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personagem>> GetPersonagem(int id)
        {
            var personagem = await _appDbContext.PB.FindAsync(id);
            if (personagem == null)
            {
                return NotFound("Personagem não encontrado.");
            }
            return Ok(personagem);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePersonagem(int id)
        {
            var personagem = await _appDbContext.PB.FindAsync(id);
            if (personagem == null)
            {
                return NotFound();
            }
            _appDbContext.PB.Remove(personagem);
            await _appDbContext.SaveChangesAsync();
            return Ok("Personagem excluído com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePeronagem(int id, [FromBody] Personagem updatePersonagem)
        {
            var personagem = await _appDbContext.PB.FindAsync(id);

            if (personagem == null)
            {
                return NotFound("Personagem não encontrado.");
            }

            _appDbContext.Entry(personagem).CurrentValues.SetValues(updatePersonagem);
            await _appDbContext.SaveChangesAsync();
            
            return Ok("Personagem atualizado com sucesso.");
        }      
    }
}
using CRUD_SQL.Context;
using CRUD_SQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly MyContext _context;

        public PessoasController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Pessoas.ToList());
        }

        [HttpGet("pessoa")]
        public IActionResult GetName([FromQuery] string pessoa)
        {
            var pessoas = _context.Pessoas.Where(x => x.Name.Contains(pessoa));
            return Ok(pessoas);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] Guid Id)
        {
            var pessoa = _context.Pessoas.Find(Id);

            if (pessoa == null) return NotFound();

            return Ok(pessoa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Pessoa pessoa, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid || pessoa.Id != id) return BadRequest(ModelState);

            _context.Entry(pessoa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var pessoa = _context.Pessoas.Find(id);

            if (pessoa is null) return NotFound();

            _context.Pessoas.Remove(pessoa);

            _context.SaveChanges();

            return NoContent();
        }
    }
}

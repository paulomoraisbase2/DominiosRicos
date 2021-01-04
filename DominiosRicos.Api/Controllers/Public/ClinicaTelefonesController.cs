using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ModelosVisualizacao;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DominiosRicos.Api.Controllers.Public
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaTelefonesController : ControllerBase
    {
        private readonly IClinicaTelefoneRepositorio _clinicaTelefoneRepositorio;
        private readonly AuthenticatedUser _user;

        public ClinicaTelefonesController(IClinicaTelefoneRepositorio clinicaTelefoneRepositorio, AuthenticatedUser user)
        {
            _clinicaTelefoneRepositorio = clinicaTelefoneRepositorio;
            _user = user;
        }

        // GET: api/ClinicaTelefones
        [HttpGet]
        public ActionResult<IEnumerable<ClinicaTelefone>> GetclinicaTelefones()
        {
            return Ok(_clinicaTelefoneRepositorio.GetAll());
        }

        /*
        // GET: api/ClinicaTelefones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClinicaTelefone>> GetClinicaTelefone(Guid id)
        {
            var clinicaTelefone = await _clinicaTelefoneRepositorio.Find(id);

            if (clinicaTelefone == null)
            {
                return NotFound();
            }

            return clinicaTelefone;
        }

        // PUT: api/ClinicaTelefones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClinicaTelefone( ClinicaTelefone clinicaTelefone)
        {
            if (id != clinicaTelefone.Id)
            {
                return BadRequest();
            }

            _context.Entry(clinicaTelefone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicaTelefoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClinicaTelefones
        [HttpPost]
        public async Task<ActionResult<ClinicaTelefone>> PostClinicaTelefone(ClinicaTelefone clinicaTelefone)
        {
            _clinicaTelefoneRepositorio.Add(clinicaTelefone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClinicaTelefone", new { id = clinicaTelefone.Id }, clinicaTelefone);
        }

        // DELETE: api/ClinicaTelefones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClinicaTelefone>> DeleteClinicaTelefone(Guid id)
        {
            var clinicaTelefone = await _clinicaTelefoneRepositorio.FindAsync(id);
            if (clinicaTelefone == null)
            {
                return NotFound();
            }

            _clinicaTelefoneRepositorio.Remove(clinicaTelefone);
            await _context.SaveChangesAsync();

            return clinicaTelefone;
        }

        private bool ClinicaTelefoneExists(Guid id)
        {
            return _clinicaTelefoneRepositorio.Any(e => e.Id == id);
        }*/
    }
}
using DominiosRicos.Dominio;
using DominiosRicos.Dominio.Action;
using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominiosRicos.Api.Controllers.Private
{
    [Route("private/[controller]")]
    [Authorize]
    [ApiController]
    public class PacienteController : Controller
    {
        private readonly IBaseRepositorio<Paciente> _Paciente;
        private readonly IBaseRepositorio<PacienteTelefone> _PacienteTelefone;

        public PacienteController(IBaseRepositorio<Paciente> Paciente,
            IBaseRepositorio<PacienteTelefone> PacienteTelefone)
        {
            _PacienteTelefone = PacienteTelefone;
            _Paciente = Paciente;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetPacientes([FromQuery] string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var PacientesView = _Paciente
                    .Where(c => c.Nome.ToLower().Contains(search.ToLower()) || c.Cpf.NRegistro.ToLower().Contains(search.ToLower()))
                    .Select(c => new
                    {
                        c.Id,
                        descricao = c.Nome
                    })
                  .Take(10);
                return Ok(PacientesView.ToList());
            }
            else
            {
                var PacientesView = _Paciente
                      .GetAll()
                      .Select(u => new
                      {
                          u.Id,
                          u.Nome,
                          Email = u.Email.Endereco,
                          Telefone = u.PacienteTelefones.FirstOrDefault() != null ? u.PacienteTelefones.FirstOrDefault().Telefone.Numero : "",
                          PrimeiroNome = u.Nome.QuebraTexto().PrimeiroNome(),
                          SegundoNome = u.Nome.QuebraTexto().PrimeiroNome() == u.Nome.QuebraTexto().UltimoNome() ? "" : u.Nome.QuebraTexto().UltimoNome()
                      });
                return Ok(PacientesView.ToList());
            }
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public ActionResult<Paciente> GetPaciente(Guid id)
        {
            var Paciente = _Paciente
                .GetSingle(u => u.Id == id, u => u.PacienteTelefones);

            if (Paciente == null)
            {
                return NotFound();
            }

            return Ok(Paciente);
        }

        // PUT: api/Pacientes/5
        [HttpPut("{id}")]
        public IActionResult PutPaciente(Guid id, PacienteCommand paciente)
        {
            _Paciente.Update(paciente);
            _PacienteTelefone.DeleteWhere(c => c.GetType() != typeof(PacienteTelefone));
            try
            {
                _Paciente.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        // PUT: api/Pacientes/id/5
        //[HttpGet("search")]
        //public ActionResult<object> SearchPacienteString(string id)
        //{
        //    var Paciente = _Paciente
        //                  .GetSingle(u => u.Id.contais( == id, u => u.PacienteTelefones);
        //    if (Paciente == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(new { Paciente = Paciente.ToString() });
        //}
        // POST: api/Pacientes
        [HttpPost]
        public ActionResult<Paciente> PostPaciente([FromBody] PacienteCommand paciente)
        {
            if (paciente.Invalid) return BadRequest(paciente.Notifications);
            _Paciente.Add(paciente);
            _Paciente.Commit();
            return CreatedAtAction("GetPaciente", new { id = paciente.Id }, paciente);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paciente>> DeletePacienteAsync(Guid id)
        {
            var Paciente = await _Paciente.GetIdAsync(id);
            if (Paciente == null)
            {
                return NotFound();
            }

            _Paciente.Delete(Paciente);
            return Paciente;
        }

        private bool PacienteExists(Guid id)
        {
            return _Paciente.GetIdAsync(id) == null;
        }
    }
}
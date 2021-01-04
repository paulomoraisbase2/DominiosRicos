using DominiosRicos.Dominio.Comandos;
using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DominiosRicos.Api.Controllers.Private
{
    [Route("private/[controller]")]
    [Authorize]
    [ApiController]
    public class ProcedimentoController : Controller
    {
        private readonly IBaseRepositorio<Procedimento> _ProcedimentoRepositorio;

        public ProcedimentoController(IBaseRepositorio<Procedimento> ProcedimentoRepositorio)
        {
            _ProcedimentoRepositorio = ProcedimentoRepositorio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetProcedimentos()
        {
            //var ProcedimentosView = _ProcedimentoRepositorio.GetAll();
            return Ok(_ProcedimentoRepositorio.GetAll());
        }

        // GET: api/Procedimentos/5
        [HttpGet("{id}")]
        public ActionResult<Procedimento> GetProcedimento(Guid id)
        {
            var Procedimento = _ProcedimentoRepositorio
                .GetSingle(p => p.Id == id, p => p.Comissao);

            if (Procedimento == null)
            {
                return NotFound();
            }
            return Procedimento;
        }

        // PUT: api/Procedimentos/5
        [HttpPut("{id}")]
        public IActionResult PutProcedimento(Guid id, ProcedimentoCommand Procedimento)
        {
            if (id != Procedimento.Id)
            {
                return BadRequest();
            }
            _ProcedimentoRepositorio.Update(Procedimento);
            try
            {
                _ProcedimentoRepositorio.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedimentoExists(id))
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

        // POST: api/Procedimentos
        [HttpPost]
        public ActionResult<Procedimento> PostProcedimento(ProcedimentoCommand ProcedimentoCommand)
        {
            if (!ProcedimentoCommand.Valid) return BadRequest(ProcedimentoCommand.Notifications);

            _ProcedimentoRepositorio.Add(ProcedimentoCommand);
            _ProcedimentoRepositorio.Commit();
            return CreatedAtAction("GetProcedimento", new { id = ProcedimentoCommand.Id }, ProcedimentoCommand);
        }

        // DELETE: api/Procedimentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Procedimento>> DeleteProcedimentoAsync(Guid id)
        {
            var Procedimento = await _ProcedimentoRepositorio.GetIdAsync(id);
            if (Procedimento == null)
            {
                return NotFound();
            }

            _ProcedimentoRepositorio.Delete(Procedimento);
            return Procedimento;
        }

        private bool ProcedimentoExists(Guid id)
        {
            return _ProcedimentoRepositorio.GetIdAsync(id) == null;
        }
    }
}
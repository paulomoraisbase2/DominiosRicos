using DominiosRicos.Dominio.Comandos;
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
    public class OrcamentoController : ControllerBase
    {
        //private readonly DominiosRicosContexto _context;
        private readonly IBaseRepositorio<Orcamento> _Orcamento;

        public OrcamentoController(IBaseRepositorio<Orcamento> Orcamento)
        {
            _Orcamento = Orcamento;
        }

        // GET: api/Orcamentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetOrcamentos()
        {
            return _Orcamento.AllIncluding(c => c.Paciente).Select(c => new { c.Id, c.Paciente.Nome, dataAbertura = c.Periodo.Inicial, rascunho = c.Rascunho }).ToList();
        }

        // GET: api/Orcamentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orcamento>> GetOrcamento(Guid id)
        {
            var orcamento = _Orcamento.AllIncluding(c => c.Paciente, c => c.OrcamentoDentesRemovidos).FirstOrDefault(o => o.Id == id);

            if (orcamento == null)
            {
                return NotFound();
            }

            return Ok(orcamento);
        }

        // PUT: api/Orcamentoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrcamento(Guid id, OrcamentoCommand orcamento)
        {
            if (id != orcamento.Id)
            {
                return BadRequest();
            }
            if (OrcamentoExists(id))
            {
                _Orcamento.Update(orcamento);
            }
            else
            {
                _Orcamento.Add(orcamento);
            }
            try
            {
                _Orcamento.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrcamentoExists(id))
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

        // POST: api/Orcamentoes
        [HttpPost]
        public ActionResult<Orcamento> PostOrcamento(OrcamentoCommand orcamento)
        {
            _Orcamento.Add(orcamento);
            _Orcamento.Commit();

            return CreatedAtAction("GetOrcamento", new { id = orcamento.Id }, orcamento);
        }

        // DELETE: api/Orcamentoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orcamento>> DeleteOrcamento(Guid id)
        {
            var orcamento = await _Orcamento.GetIdAsync(id);
            if (orcamento == null)
            {
                return NotFound();
            }

            _Orcamento.Delete(orcamento);
            _Orcamento.Commit();

            return orcamento;
        }

        private bool OrcamentoExists(Guid id)
        {
            return _Orcamento.Any(e => e.Id == id);
        }
    }
}
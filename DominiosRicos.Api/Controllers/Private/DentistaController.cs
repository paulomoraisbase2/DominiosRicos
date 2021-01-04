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

namespace DominiosRicos.Api.Controllers.Private
{
    [Route("private/[controller]")]
    [Authorize]
    [ApiController]
    public class DentistaController : Controller
    {
        private readonly IBaseRepositorio<Dentista> _DentistaRepositorio;
        //private readonly IDentistaTelefoneRepositorio _DentistaTelefoneRepositorio;

        public DentistaController(IBaseRepositorio<Dentista> dentistaRepositorio)
        {
            _DentistaRepositorio = dentistaRepositorio;
            //_DentistaTelefoneRepositorio = dentistaTelefoneRepositorio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetDentistas()
        {
            var DentistasView = _DentistaRepositorio
                .GetAll()
                .Select(u => new
                {
                    u.Id,
                    u.Nome,
                    Email = u.Email.Endereco,
                    Telefone = u.Telefones.FirstOrDefault() != null ? u.Telefones.FirstOrDefault().Telefone.ToString() : "",
                    PrimeiroNome = u.Nome.QuebraTexto().PrimeiroNome(),
                    SegundoNome = u.Nome.QuebraTexto().PrimeiroNome() == u.Nome.QuebraTexto().UltimoNome() ? "" : u.Nome.QuebraTexto().UltimoNome()
                });
            return Ok(DentistasView.ToList());
        }

        // GET: api/Dentistas/5
        [HttpGet("{id}")]
        public ActionResult<Dentista> GetDentista(Guid id)
        {
            var Dentista = _DentistaRepositorio
                .GetSingle(u => u.Id == id);

            if (Dentista == null)
            {
                return NotFound();
            }

            return Dentista;
        }

        // PUT: api/Dentistas/5
        [HttpPut("{id}")]
        public IActionResult PutDentista(Guid id, DentistaCommand dentistaCommand)
        {
            if (!dentistaCommand.Valid) return BadRequest(dentistaCommand.Notifications);
            //foreach (var telefone in dentistaCommand.Telefones)
            //{
            //    dentista.AddTelefone(telefone);
            //}
            //var teste =;
            //_DentistaTelefoneRepositorio.Add(dentista.Telefones.Where(d => long.TryParse(d.Id.ToString(), out Guid _)));
            _DentistaRepositorio.Update(dentistaCommand);

            //var teste = _DentistaTelefoneRepositorio.GetAll().Where(c => c.GetType() == typeof(DentistaTelefone));
            //_DentistaTelefoneRepositorio.DeleteWhere(c => c.GetType() != typeof(DentistaTelefone));
            try
            {
                _DentistaRepositorio.Commit();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!DentistaExists(id))
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

        // POST: api/Dentistas
        [HttpPost]
        public ActionResult<Dentista> PostDentista(DentistaCommand dentistaCommand)
        {
            if (!dentistaCommand.Valid) return BadRequest(dentistaCommand.Notifications);
            _DentistaRepositorio.Add(dentistaCommand);
            _DentistaRepositorio.Commit();
            return CreatedAtAction("GetDentista", new { id = dentistaCommand.Id }, dentistaCommand);
        }

        // DELETE: api/Dentistas/5
        [HttpDelete("{id}")]
        public ActionResult<Dentista> DeleteDentista(Guid id)
        {
            var Dentista = _DentistaRepositorio.GetSingle(d => d.Id == id);
            if (Dentista == null)
            {
                return NotFound();
            }
            _DentistaRepositorio.Delete(Dentista);
            return Ok();
        }

        // DELETE: api/Dentistas/5
        [HttpDelete("telefone/{id}")]
        public ActionResult<DentistaTelefone> DeleteDentistaTelefone(Guid id)
        {
            //var DentistaTelefone = _DentistaTelefoneRepositorio.GetSingle(d => d.Id == id);
            //if (DentistaTelefone == null)
            //{
            //    return NotFound();
            //}
            //_DentistaTelefoneRepositorio.Delete(DentistaTelefone);
            return NoContent();
        }

        private bool DentistaExists(Guid id)
        {
            return _DentistaRepositorio.GetSingle(d => d.Id == id) != null;
        }
    }
}
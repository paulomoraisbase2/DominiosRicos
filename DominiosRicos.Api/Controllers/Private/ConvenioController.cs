using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DominiosRicos.Api.Controllers.Private
{
    [Route("private/[controller]")]
    [Authorize]
    [ApiController]
    public class ConvenioController : Controller
    {
        /*
        private readonly IConvenioRepositorio _ConvenioRepositorio;
        public ConvenioController(IConvenioRepositorio ConvenioRepositorio)
        {
            _ConvenioRepositorio = ConvenioRepositorio;
        }
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetConvenios()
        {
            var ConveniosView = _ConvenioRepositorio.GetAll();
            return Ok(ConveniosView.ToList());
        }

        // GET: api/Convenios/5
        [HttpGet("{id}")]
        public ActionResult<Convenio> GetConvenio(Guid id)
        {
            var Convenio = _ConvenioRepositorio
                .GetSingle(u => u.Id == id);

            if (Convenio == null)
            {
                return NotFound();
            }
            return Convenio;
        }

        // PUT: api/Convenios/5
        [HttpPut("{id}")]
        public IActionResult PutConvenio(Guid id, Convenio Convenio)
        {
            if (id != Convenio.Id)
            {
                return BadRequest();
            }
            _ConvenioRepositorio.Update(Convenio);
            try
            {
                _ConvenioRepositorio.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConvenioExists(id))
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

        // POST: api/Convenios
        [HttpPost]
        public ActionResult<Convenio> PostConvenio(Convenio Convenio)
        {
            if (!Convenio.Valid) return BadRequest(Convenio.Notifications);

            _ConvenioRepositorio.Add(Convenio);
            _ConvenioRepositorio.Commit();
            return CreatedAtAction("GetConvenio", new { id = Convenio.Id }, Convenio);
        }
        // DELETE: api/Convenios/5
        [HttpDelete("{id}")]
        public ActionResult<Convenio> DeleteConvenio(Guid id)
        {
            var Convenio = _ConvenioRepositorio.GetId(id);
            if (Convenio == null)
            {
                return NotFound();
            }

            _ConvenioRepositorio.Delete(Convenio);
            return Convenio;
        }

        private bool ConvenioExists(Guid id)
        {
            return _ConvenioRepositorio.GetId(id) == null;
        }*/
    }
}
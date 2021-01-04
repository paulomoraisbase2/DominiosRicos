namespace DominiosRicos.Api.Controllers.Public
{
    /*   [Route("api/[controller]")]
       [ApiController]
       public class GrupoesController : ControllerBase
       {
           private readonly DominiosRicosContexto _context;

           public GrupoesController(DominiosRicosContexto context)
           {
               _context = context;
           }

           //// GET: api/Grupoes
           //[HttpGet]
           //public async Task<ActionResult<IEnumerable<Grupo>>> GetGrupos()
           //{
           //    return await _context.Grupos.ToList();
           //}

           // GET: api/Grupoes/5
           [HttpGet("{id}")]
           public async Task<ActionResult<Grupo>> GetGrupo(Guid id)
           {
               var grupo = await _context.Grupos.FindAsync(id);

               if (grupo == null)
               {
                   return NotFound();
               }

               return grupo;
           }

           // PUT: api/Grupoes/5
           [HttpPut("{id}")]
           public async Task<IActionResult> PutGrupo(Guid id, Grupo grupo)
           {
               if (id != grupo.Id)
               {
                   return BadRequest();
               }

               _context.Entry(grupo).State = EntityState.Modified;

               try
               {
                   await _context.SaveChangesAsync();
               }
               catch (DbUpdateConcurrencyException)
               {
                   if (!GrupoExists(id))
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

           // POST: api/Grupoes
           [HttpPost]
           public async Task<ActionResult<Grupo>> PostGrupo(Grupo grupo)
           {
               _context.Grupos.Add(grupo);
               await _context.SaveChangesAsync();

               return CreatedAtAction("GetGrupo", new { id = grupo.Id }, grupo);
           }

           // DELETE: api/Grupoes/5
           [HttpDelete("{id}")]
           public async Task<ActionResult<Grupo>> DeleteGrupo(Guid id)
           {
               var grupo = await _context.Grupos.FindAsync(id);
               if (grupo == null)
               {
                   return NotFound();
               }

               _context.Grupos.Remove(grupo);
               await _context.SaveChangesAsync();

               return grupo;
           }

           private bool GrupoExists(Guid id)
           {
               return _context.Grupos.Any(e => e.Id == id);
           }
       }*/
}
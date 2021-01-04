using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Repositorio.Contexto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DominiosRicos.Api.Controllers.Public
{
    [Route("[controller]")]
    [ApiController]
    public class DropdownController : Controller
    {
        private readonly DominiosRicosContexto _context;

        public DropdownController(DominiosRicosContexto context)
        {
            _context = context;
        }

        [HttpGet("procedimentoCategoria")]
        public ActionResult GetGrupos()
        {
            return Ok(_context.Set<Procedimento>().Select(p => new
            {
                Descricao = p.Categoria,
                Id = p.Categoria
            }
            ).Distinct().ToList());
        }

        //[HttpGet("convenios")]
        //public ActionResult GetConvenios()
        //{
        //    return Ok(_context.Convenios.Select(c => new
        //    {
        //        Descricao = c.Nome,
        //        Id = c.Id
        //    }).ToList());
        //}
        //[HttpGet("dentesPermanentes")]
        //public ActionResult GetDentesPermanentes()
        //{
        //    var dentes = new List<string>();
        //    foreach (var quadrante in Dentes.PosicaoDente<Dentes.Quadrante>())
        //    {
        //        foreach (var posicao in Dentes.PosicaoDente<Dentes.Posicao>())
        //        {
        //            dentes.Add($"{quadrante}{posicao}");
        //        }
        //    }
        //    return Ok(dentes.Select(c => new
        //    {
        //        Descricao = c,
        //        Id = c
        //    }).ToList());
        //}
        [HttpGet("dentesDeciduos/{tipo}")]
        public ActionResult GetDentesDeciduos(Dentes.Tipo tipo)
        {
            var dentesSuperiores = new List<string>();
            var dentesInferiores = new List<string>();
            var dentes = new List<List<string>>();

            foreach (Dentes.Quadrante quadrante in Dentes.PosicaoDente<Dentes.Quadrante>())
            {
                foreach (Dentes.Posicao posicao in Dentes.PosicaoDente<Dentes.Posicao>())
                {
                    if (quadrante.Equals(Dentes.Quadrante.Primeiro) || quadrante.Equals(Dentes.Quadrante.Segundo))
                        dentesSuperiores.Add(new Dente(quadrante, posicao, tipo).ToString());
                    else
                        dentesInferiores.Add(new Dente(quadrante, posicao, tipo).ToString());
                }
            }
            dentes.Add(dentesSuperiores);
            dentes.Add(dentesInferiores);

            return Ok(dentes);
        }
    }
}
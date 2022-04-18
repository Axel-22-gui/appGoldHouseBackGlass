using Entity;
using Logical;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfertaController : Controller
    {
        [HttpPost]
        public bool agregaroferta(Oferta of)
        {

            loferta lu = new loferta();
            return lu.agregaroferta(of);
        }

        [HttpGet("aceptar/{id}")]
        public bool aceptaroferta(int id)
        {
            loferta lu = new loferta();
            return lu.aceptaroferta(id);

        }
        [HttpPost("rechazar")]
        public bool rechazaroferta(moferta mo)
        {
            loferta lu = new loferta();
            return lu.rechazaroferta(mo);
        }

        [HttpPost("comprador/{id}")]
        public List<Oferta> SeguiListarComprador(int id)
        {
            loferta lpub = new loferta();
            return lpub.ListarOfertaAceptadasPubli(id);
        }


        [HttpPost("vendedor/{id}")]
        public List<Oferta> ListarOfertaAceptadaporCliente(int id)
        {
            loferta lpub = new loferta();
            return lpub.ListarOfertaAceptadaporCliente(id);
        }


        [HttpGet("pendiente/{idpubli}")]
        public List<Oferta> ListarOfertasPendientes(int idpubli)
        {
            loferta lpub = new loferta();
            return lpub.ListarOfertasPendientes(idpubli);
        }

        [HttpGet("encurso/{idpubli}")]
        public List<Oferta> ListarOfertasenCurso(int idpubli)
        {
            loferta lpub = new loferta();
            return lpub.ListarOfertasenCurso(idpubli);
        }

        [HttpGet("culminado/{idpubli}")]
        public List<Oferta> listarOfertasCulminidas(int idpubli)
        {
            loferta lpub = new loferta();
            return lpub.listarOfertasCulminidas(idpubli);
        }

        [HttpGet("ofertatotal/{idpubli}")]
        public ofertatotal listarOfertastotal(int idpubli)
        {
            loferta lpub = new loferta();
            return lpub.ListarOfertas(idpubli);
        }




    }
}

using Entity;
using Logical;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class seguimientoController : Controller
    {
        [HttpPost("incidencia")]
        public bool AgregarIncidencia(Seguimiento se)
        {
            lseguimiento lu = new lseguimiento();
            return lu.AgregarIncidencia(se); 
        }


        [HttpPost("respuesta")]
        public bool AgregarRespuesta(Seguimiento se)
        {
            lseguimiento lu = new lseguimiento();
            return lu.AgregarRespuesta(se);
        }


        [HttpPost("comprador/{id}")]
        public List<Seguimiento> SeguiListarComprador(int id)
        {
            lseguimiento lpub = new lseguimiento();
            return lpub.SeguiListarComprador(id);
        }

        [HttpPost("comprador/{id}")]
        public List<Seguimiento> SeguiListarVendidos(int id)
        {
            lseguimiento lpub = new lseguimiento();
            return lpub.SeguiListarVendidos(id);
        }

        [HttpGet("listar/{id}")]
        public List<Seguimiento> Listarseguimiento(int id)
        {
            lseguimiento lpub = new lseguimiento();
            return lpub.Listarseguimiento(id);
        }



    }
}

using Entity;
using Logical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrincipalController : Controller
    {
        [HttpGet]
        public List<Publicacion> listarpub()
        {
            lpublicaciones lpub = new lpublicaciones();
            return lpub.ListarPublicacion();
        }
        [HttpGet("{id}")]
        public Publicacion SeleccionarPub(int id)
        {

            lpublicaciones lpub = new lpublicaciones();
            return lpub.publicacionSeleccionar(id);
        }
        [HttpPost]
        public List<Publicacion> filtros(Publicacion publicacion)
        {
            lpublicaciones lpub = new lpublicaciones();
            return lpub.filtros(publicacion);
        }
        [HttpGet("usuario/{id}")]
        public List<MisPublis> filtroUsuario(int id)
        {
            lpublicaciones lpub = new lpublicaciones();
            return lpub.selectById(id);
        }

        [HttpGet("publiusuario/{id}")]
        public mispubliusu publiusu(int id)
        {
            lpublicaciones lpub = new lpublicaciones();
            return lpub.misusus(id);

        }
    }
}

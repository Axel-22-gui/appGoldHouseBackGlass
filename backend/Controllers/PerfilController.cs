using Entity;
using Logical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerfilController : Controller
    {
        //colocar la ruta del id
        [HttpPut("{id}")]
        public bool editarperfil(Usuario us, int id)
        {

            us.UserId = id;
            lusuario lu = new lusuario();
            return lu.editarusuario(us);

        }

    }
}

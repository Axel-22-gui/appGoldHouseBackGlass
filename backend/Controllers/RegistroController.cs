using Entity;
using Logical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class RegistroController : Controller
    {
       [HttpPost]
       public bool UserRegistro(Usuario us)
        {
            lusuario lu = new lusuario();
            return lu.agregarUsuario(us);

        }

        [HttpGet]
        public List<Tipodocumento> ListarOfertaAceptadasPubli(int id)
        {
                ltipodocumento  ltp = new ltipodocumento();
                return ltp.listardocumento();
        }


    }
}

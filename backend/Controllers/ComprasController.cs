
using Entity;
using Logical;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : Controller
    {

        [HttpPost]
        public bool agregarpubli(Publicacion pi)
        {
            lpublicaciones lu = new lpublicaciones();
        
            return lu.AgregarPublicacion(pi);
           
        }

    }
}

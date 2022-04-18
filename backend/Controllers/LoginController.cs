using Entity;
using Logical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPut("{id}")]
        public bool olvidarcontra(Usuario us, int id)
        {
            us.UserId = id;
            lusuario lu = new lusuario();

            return lu.olvidarcontrasena(us);

        }

        [HttpPost]
        public Usuario logearse(Usuario us)
        {
            lusuario lu = new lusuario();
            return lu.Userlogin(us);
        }
    }
}

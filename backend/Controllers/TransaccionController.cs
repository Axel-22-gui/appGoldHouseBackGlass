using Entity;
using Logical;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionController : Controller
    {

        [HttpPost]
        public bool agregartransaccion(Transaccion transaccion)
        {

            ltransaccion lu = new ltransaccion();

            return lu.agregartransaccion(transaccion);

        }
    }
}

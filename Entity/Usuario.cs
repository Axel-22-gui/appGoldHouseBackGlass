using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Usuario
    {
        public int UserId { get; set; }

        public int UserTdId { get; set; }

        public string UserNumeroDoc { get; set; }

        public string UserCuenta { get; set; }

        public string Userdireccion { get; set; }

        public string UserNombre { get; set; }

        public string UserApellido { get; set; }

        public string UserTelefono { get; set; }

        public string UserCorreo { get; set; }

        public string UserPassword { get; set; }

        public int UserComprasRealizadas { get; set; }

        public int UserVentasRealizadas { get; set; }

        public int UserValoracionVenta { get; set; }

        public int UserValoracionCompra { get; set; }

    }
}

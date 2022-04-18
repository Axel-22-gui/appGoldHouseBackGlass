using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Transaccion
    {
        public int Transaid { get; set; }

        public decimal Transamonto { get; set; }

        public int iduser { get; set; }

        public string tarjeta { get; set; }

        public  string ccv { get; set; }

        public int anio { get; set; }

        public int mes { get; set; }    


        public string titular { get; set; }


    }
}

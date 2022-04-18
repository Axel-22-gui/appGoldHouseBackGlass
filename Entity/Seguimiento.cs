using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Seguimiento
    {
        public int SeguiId { get; set; } 

        public string SeguiMensaje { get; set; }

        public DateTime SeguiFechainc { get; set; }

        public string SeguiRespuesta { get; set; }

        public DateTime SeguiFecharespuesta { get; set; }  

        public Int16 SeguiStatus { get; set; }


        public string Seguiestado { get; set; }  

        public int SeguiOfid { get; set; }


    }
}

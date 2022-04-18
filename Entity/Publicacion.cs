using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Publicacion
    {
        public int Publiid { get; set; }

        public int PubliUsuid { get; set; }
        public string PubliDescripcion { get; set; }
        public string Publilocalizacion { get; set; }

        public decimal Publilongitud { get; set; }

        public decimal Publilatitud { get; set; }

        public decimal Publiprecio { get; set; }

        public string Publitipo { get; set; }

        public string Publiprovincia { get; set; }

        public decimal Publiarea { get; set; }

        public Int16 Publistatus { get; set; }

        public string Publitituloanuncio { get; set; }

        public bool Publifavoritos { get; set; }

        public List<Detallescasa> detallesCasa { get; set; }


        public List<ArchivoRequest> Imagenes { get; set; }
        public List<string> documentos { get; set; }

        public DateTime fechapostventa { get; set; }


        public decimal PubliMaximoPrecio { get; set; }

        public decimal PubliMinimoPrecio { get; set; }

        public decimal PubliMaximaArea { get; set; }


        public decimal PubliMinimaArea { get; set; }

        public int PublicantBanios { get; set; }

        public int PublicantCuarto { get; set; }

        public Int16 Publipiscina { get; set; }

        public Int16 Publipet { get; set; }
        public Int16 Publicochera { get; set; }

        public int Publifechaentera { get; set; }

    }


}

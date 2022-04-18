using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Oferta
    {
        public int OfIdoferta { get; set; }

        public DateTime OfFecha { get; set; }

        public int Ofidpublicacion { get; set; }
        public int Ofidusuario { get; set; }

        public decimal Ofmonto { get; set; }

        public Int16 Ofestado { get; set; }

        public string nombre { get; set; }
        public string apellidos { get; set; }

    }
    public class MisPublis
    {
        public int Publiid { get; set; }
        public string Publilocalizacion { get; set; }
        public decimal Publiprecio { get; set; }
        public decimal Publiarea { get; set; }
        public string Publitituloanuncio { get; set; }
        public List<ArchivoRequest> Imagenes { get; set; }
        public string PubliDescripcion { get; set; }

    }


    public class MisPubliscompras
    {
        public int Publiid { get; set; }
        public string Publilocalizacion { get; set; }
        public decimal Publiprecio { get; set; }

        public decimal Publimonto { get; set; }
        public decimal Publiarea { get; set; }
        public string Publitituloanuncio { get; set; }
        public List<ArchivoRequest> Imagenes { get; set; }

        public int Publiidusu { get; set; }

        public int Ofertasusu { get; set; }
    }


    public class moferta
    {
        public int Mofertaid { get; set; }

        public string Mofertasmensaje { get; set; }
    }


    public class ofertatotal
    {
        public List<Oferta> ofertasculminadas { get; set; }

        public List<Oferta> ofertaenproceso { get; set; }

        public List<Oferta> ofertapendiente { get; set; }

        public List<MisPubliscompras> MisPubliscompras { get; set; }
     }

    public class mispubliusu
    {
        public List<MisPublis> misPublis { get; set; }
        public List<MisPubliscompras> misPubliscompras { get; set; }

        public List<MisPubliscompras> misPublisenproceso { get; set; }
        public List<MisPubliscompras> misPublisculminadas { get; set; }

    }
}

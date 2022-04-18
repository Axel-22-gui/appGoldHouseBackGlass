
using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class lpublicaciones
    {
        public List<Publicacion> ListarPublicacion()
        {
            try
            {
                PublicacionDAO pubdao = new PublicacionDAO();
                List<Publicacion> pubS = pubdao.publicacionListar();

                foreach (Publicacion pub in pubS)
                {
                    List<ArchivoRequest> arch = pub.Imagenes;
                    pub.Imagenes[0].imagensrc = listarimagenes(arch[0]).imagensrc;
                }
                return pubS;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Publicacion publicacionSeleccionar(int publicacion)
        {
            try
            {
                PublicacionDAO pubdao = new PublicacionDAO();
                Publicacion pubS = pubdao.publicacionSeleccionar(publicacion);
                int contandor = 0;
                foreach (var pub in pubS.Imagenes)
                {
                    ArchivoRequest arch = pub;
                    pubS.Imagenes[contandor].imagensrc = listarimagenes(pub).imagensrc;
                    contandor++;
                }
                return pubS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArchivoRequest listarimagenes(ArchivoRequest archivo)
        {
            try
            {
                //       List<ArchivoRequest> archivoRequests = new List<ArchivoRequest>();  
                S3service s3 = new S3service();
                s3.obtenerObject(archivo.nombre);
                larchivo larchivo = new larchivo();
                archivo.imagensrc = larchivo.descargarArchivo(archivo.nombre);
                return archivo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Publicacion> filtros(Publicacion publicacion)
        {
            try
            {
                PublicacionDAO pubdao = new PublicacionDAO();
                List<Publicacion> pubS = pubdao.filtros(publicacion);

                foreach (Publicacion pub in pubS)
                {
                    List<ArchivoRequest> arch = pub.Imagenes;
                    pub.Imagenes[0].imagensrc = listarimagenes(arch[0]).imagensrc;
                }
                return pubS;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<MisPublis> selectById(int id)
        {
            try
            {
                PublicacionDAO pubdao = new PublicacionDAO();
                List<MisPublis> pubS = pubdao.publicacionListarById(id);
                foreach (MisPublis pub in pubS)
                {
                    List<ArchivoRequest> arch = pub.Imagenes;
                    pub.Imagenes[0].imagensrc = listarimagenes(arch[0]).imagensrc;
                }
                return pubS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MisPubliscompras> PublicacionComprasUsu(int id)
        {
            try
            {
                PublicacionDAO pubdao = new PublicacionDAO();
                List<MisPubliscompras> pubS = pubdao.publicacionComprasUsu(id);
                foreach (MisPubliscompras pub in pubS)
                {
                    List<ArchivoRequest> arch = pub.Imagenes;
                    pub.Imagenes[0].imagensrc = listarimagenes(arch[0]).imagensrc;
                }
                return pubS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public mispubliusu misusus(int id)
        {
            try
            {
                PublicacionDAO publicacionDAO = new PublicacionDAO();
                mispubliusu mispubliusu = new mispubliusu();
                List<MisPubliscompras> pubS = publicacionDAO.publicacionComprasUsu(id);
                foreach (MisPubliscompras pub in pubS)
                {
                    List<ArchivoRequest> arch = pub.Imagenes;
                    pub.Imagenes[0].imagensrc = listarimagenes(arch[0]).imagensrc;
                }
                mispubliusu.misPubliscompras = pubS;

            
                List<MisPubliscompras> pubculm = publicacionDAO.publicacionculminadoUsu(id);
                foreach (MisPubliscompras pub1 in pubculm)
                {
                    List<ArchivoRequest> arch1 = pub1.Imagenes;
                    pub1.Imagenes[0].imagensrc = listarimagenes(arch1[0]).imagensrc;
                }
                mispubliusu.misPublisculminadas = pubculm;


                List<MisPubliscompras> pubproc = publicacionDAO.publicacionenprocesosUsu(id);
                foreach (MisPubliscompras pub3 in pubproc)
                {
                    List<ArchivoRequest> arch3 = pub3.Imagenes;
                    pub3.Imagenes[0].imagensrc = listarimagenes(arch3[0]).imagensrc;
                }
                mispubliusu.misPublisenproceso = pubproc;

                List<MisPublis> pubmis = publicacionDAO.publicacionListarById(id);
                foreach(MisPublis pub2 in pubmis)
                {
                    List<ArchivoRequest> arch2 = pub2.Imagenes;
                    pub2.Imagenes[0].imagensrc = listarimagenes(arch2[0]).imagensrc;
                }
                
                mispubliusu.misPublis = pubmis;

                return mispubliusu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
   

        }

        public bool AgregarPublicacion(Publicacion publicacion)
        {
            try
            {
                PublicacionDAO pubdao = new PublicacionDAO();
                Detalles_viviendaDAO detdao = new Detalles_viviendaDAO();
                ImagenesDAO imgdao = new ImagenesDAO();
                int id = pubdao.AgregarPublicacion(publicacion);
                foreach (var p in publicacion.detallesCasa)
                {
                    detdao.publiAgregarDetallePubli(p, id);
                }
                S3service s3 = new S3service();

                foreach (var img in publicacion.Imagenes)
                {
                    larchivo a = new larchivo();
                    byte[] bytes = Convert.FromBase64String(img.imagensrc);
                    a.guardarArchivo(bytes, img.nombre + "." + img.extension);
                    _ = s3.UploadFileAsync(img.nombre + "." + img.extension).Result;
                    imgdao.publiAgregarimagenes(img.nombre + '.' + img.extension, id, 1);
                }

                //     foreach (var doc in publicacion.documentos)
                //  {
                //    imgdao.publiAgregarimagenes(doc, id, 0);
                //}

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

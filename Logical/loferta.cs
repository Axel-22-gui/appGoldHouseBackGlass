using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class loferta
    {
        public bool agregaroferta(Oferta of)
        {
            try
            {
                OfertDAO udao = new OfertDAO();
                return udao.AgregarOferta(of);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool aceptaroferta(int id)
        {
            try
            {
                OfertDAO udao = new OfertDAO();
                return udao.AceptarOferta(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool rechazaroferta(moferta m)
        {
            try
            {
                OfertDAO udao = new OfertDAO();
                return udao.RechazarOferta(m);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Oferta> ListarOfertaAceptadaporCliente(int id)
        {
            try
            {
                OfertDAO udao = new OfertDAO();
                return udao.ListarOfertaAceptadaporCliente(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<Oferta> ListarOfertaAceptadasPubli(int id)
        {
            try
            {
                OfertDAO udao = new OfertDAO();
                return udao.ListarOfertaAceptadasPubli(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Oferta> ListarOfertasPendientes(int idPubli)
        {
            try
            {
                OfertDAO udao = new OfertDAO();
                return udao.listarOfertasPendientes(idPubli);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Oferta> ListarOfertasenCurso(int idPubli)
        {
            try
            {
                OfertDAO udao = new OfertDAO();
                return udao.listarOfertasenCurso(idPubli);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Oferta> listarOfertasCulminidas(int idPubli)
        {
            try
            {
                OfertDAO udao = new OfertDAO();
                return udao.listarOfertasCulminidas(idPubli);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ofertatotal ListarOfertas(int idPubli)
        {
            try
            {
                OfertDAO udao = new OfertDAO();
                ofertatotal ofertatotal = new ofertatotal();
                ofertatotal.ofertasculminadas = udao.listarOfertasCulminidas(idPubli);
                ofertatotal.ofertapendiente = udao.listarOfertasPendientes(idPubli);
                ofertatotal.ofertaenproceso = udao.listarOfertasenCurso(idPubli);
          
                return ofertatotal;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }






    }
}

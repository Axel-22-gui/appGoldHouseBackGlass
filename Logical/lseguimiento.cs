using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class lseguimiento
    {

        public bool AgregarIncidencia(Seguimiento se)
        {
            try
            {
                SeguimientoDAO udao = new SeguimientoDAO();
                return udao.AgregarIncidencia(se);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AgregarRespuesta(Seguimiento se)
        {
            try
            {
                SeguimientoDAO udao = new SeguimientoDAO();
                return udao.AgregarRespuesta(se);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Seguimiento> SeguiListarComprador(int id)
        {
            try
            {
                SeguimientoDAO udao = new SeguimientoDAO();
                return udao.SeguiListarComprador(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Seguimiento> Listarseguimiento(int id)
        {
            try
            {
                SeguimientoDAO udao = new SeguimientoDAO();
                return udao.ListarSeguimientos(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Seguimiento> SeguiListarVendidos(int id)
        {
            try
            {
                SeguimientoDAO udao = new SeguimientoDAO();
                return udao.SeguiListarVendidos(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

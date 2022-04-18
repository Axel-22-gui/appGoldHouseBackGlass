using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class ltransaccion
    {
        public bool agregartransaccion(Transaccion of)
        {
            try
            {
                TransaccionDAO udao = new TransaccionDAO();
                UsuarioDao us = new UsuarioDao();
                us.upgradearUsuario(of.iduser);
                return udao.agregartransaccion(of);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class ltipodocumento
    {
        public List<Tipodocumento> listardocumento()
        {
            try
            {
                Tipo_documentoDAO udao = new Tipo_documentoDAO();
                return udao.listardocumento();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

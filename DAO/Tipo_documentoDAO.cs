using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class Tipo_documentoDAO
    {
        private SqlConnection connection;
        private readonly AD_Conector _datosConexionGuia;
        private readonly SqlCommand _command;
        public Tipo_documentoDAO()
        {
            _command = new SqlCommand();
            _datosConexionGuia = new AD_Conector();
            connection = new SqlConnection(_datosConexionGuia.CxSQLFacturacion());
        }

        public List<Tipodocumento> listardocumento()
        {
            List<Tipodocumento> ld = new List<Tipodocumento>();
            Tipodocumento tipodoc = new Tipodocumento();
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("SELECT idTipo, Descripcion FROM TipoDocumento", connection);
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        tipodoc = new Tipodocumento();
                        tipodoc.Tdocid = (int)Interaction.IIf(Information.IsDBNull(Rs["idTipo"]), 0, Rs["idTipo"]);
                        tipodoc.Tdocnombre = (string)Interaction.IIf(Information.IsDBNull(Rs["Descripcion"]), "", Rs["Descripcion"]);
                        ld.Add(tipodoc);                                  
                    } 
                }
                return ld;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                connection.Close();
            }
        }




    }
}

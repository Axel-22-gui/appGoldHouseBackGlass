using Entity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ImagenesDAO
    {

        private SqlConnection connection;
        private readonly AD_Conector _datosConexionGuia;
        private readonly SqlCommand _command;
        public ImagenesDAO()
        {
            _command = new SqlCommand();
            _datosConexionGuia = new AD_Conector();
            connection = new SqlConnection(_datosConexionGuia.CxSQLFacturacion());
        }

        public bool publiAgregarimagenes(string rutas , int id, int tipo)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("AgregarImagenes", connection);
                cmd.Parameters.AddWithValue("@RutasImagenes", rutas);
                cmd.Parameters.AddWithValue("@id_publi", id);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                return true;
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


        public List <ArchivoRequest> listarimagenes(int idpubli)
        {
            List<ArchivoRequest> ld = new List<ArchivoRequest>();
            ArchivoRequest tipodoc = new ArchivoRequest();
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("imgListaById", connection);
                cmd.Parameters.AddWithValue("@idPub", idpubli);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        tipodoc = new ArchivoRequest();
                        tipodoc.nombre = ((string)Interaction.IIf(Information.IsDBNull(Rs["RutasImagenes"]), "", Rs["RutasImagenes"])).Trim();      
                        Console.WriteLine(tipodoc.nombre);
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

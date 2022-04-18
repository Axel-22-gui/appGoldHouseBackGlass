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
    public class Detalles_viviendaDAO
    {
        private SqlConnection connection;
        private readonly AD_Conector _datosConexionGuia;
        private readonly SqlCommand _command;
        public Detalles_viviendaDAO()
        {
            _command = new SqlCommand();
            _datosConexionGuia = new AD_Conector();
            connection = new SqlConnection(_datosConexionGuia.CxSQLFacturacion());
        }


        public bool publiAgregarDetallePubli(Detallescasa Detalle, int id)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("publiAgregarDetallePubli", connection);
                cmd.Parameters.AddWithValue("@idPubli", id);
                cmd.Parameters.AddWithValue("@idDetalle", Detalle.iddetalle);
                cmd.Parameters.AddWithValue("@Cantidad", Detalle.Cantidad);
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


        public List<Detalle_Vivienda> detViviMostrar()
        {
            List<Detalle_Vivienda> lp = new List<Detalle_Vivienda>();
            Detalle_Vivienda Det_vivi = new Detalle_Vivienda();
            SqlCommand cmd;
            SqlDataReader rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("detViviMostrar", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                rs = cmd.ExecuteReader();

                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        Det_vivi = new Detalle_Vivienda();
                        Det_vivi.Detviid = (int)Interaction.IIf(Information.IsDBNull(rs["Id_detalle"]), 0, rs["Id_detalle"]);
                        Det_vivi.Detvidescripcion = (string)Interaction.IIf(Information.IsDBNull(rs["descripcion_detalles"]), "", rs["descripcion_detalles"]);
                        lp.Add(Det_vivi);
                    }
                }
                return lp;

            }catch (Exception ex)
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

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
    public class SeguimientoDAO
    {
        private SqlConnection connection;
        private readonly AD_Conector _datosConexionGuia;
        private readonly SqlCommand _command;
        public SeguimientoDAO()
        {
            _command = new SqlCommand();
            _datosConexionGuia = new AD_Conector();
            connection = new SqlConnection(_datosConexionGuia.CxSQLFacturacion());
        }

        public bool AgregarIncidencia(Seguimiento seguimiento)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("AgregarIncidencia", connection);
                cmd.Parameters.AddWithValue("@Mensaje", seguimiento.SeguiMensaje);
                cmd.Parameters.AddWithValue("@id_oferta", seguimiento.SeguiOfid);
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


        public bool AgregarRespuesta(Seguimiento seguimiento)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("AgregarRespuesta", connection);
                cmd.Parameters.AddWithValue("@Respuesta", seguimiento.SeguiRespuesta);
                cmd.Parameters.AddWithValue("@id_oferta", seguimiento.SeguiOfid);
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

        public List<Seguimiento> ListarSeguimientos(int id)
        {
            List<Seguimiento> Se = new List<Seguimiento>();
            Seguimiento seguimiento1 = new Seguimiento();
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("listarSeguimientos", connection);
                cmd.Parameters.AddWithValue("@idOferta", id);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        seguimiento1 = new Seguimiento();
                        seguimiento1.SeguiId = (int)Interaction.IIf(Information.IsDBNull(Rs["IdSeg"]), 0, Rs["IdSeg"]);
                        seguimiento1.SeguiOfid = (int)Interaction.IIf(Information.IsDBNull(Rs["idOf"]), 0, Rs["idOf"]);
                        seguimiento1.SeguiMensaje = (string)Interaction.IIf(Information.IsDBNull(Rs["Mensaje"]), "", Rs["Mensaje"]);
                        seguimiento1.SeguiFechainc = (DateTime)Interaction.IIf(Information.IsDBNull(Rs["Fecha"]), "", Rs["Fecha"]);
                        seguimiento1.Seguiestado = (string)Interaction.IIf(Information.IsDBNull(Rs["Estado"]), "", Rs["Estado"]);
                        Se.Add(seguimiento1);
                    }
                }
                return Se;

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

        public List<Seguimiento> SeguiListarComprador(int id)
        {
            List<Seguimiento> Se = new List<Seguimiento>();
            Seguimiento seguimiento1 = new Seguimiento();
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("SeguiListarComprador", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        seguimiento1 = new Seguimiento();
                        seguimiento1.SeguiMensaje = (string)Interaction.IIf(Information.IsDBNull(Rs["Men"]), "", Rs["Men"]);
                        seguimiento1.SeguiFechainc = (DateTime)Interaction.IIf(Information.IsDBNull(Rs["FechaInc"]), 0, Rs["FechaInc"]);
                        seguimiento1.SeguiRespuesta = (string)Interaction.IIf(Information.IsDBNull(Rs["Resp"]), 0, Rs["Resp"]);
                        seguimiento1.SeguiFecharespuesta = (DateTime)Interaction.IIf(Information.IsDBNull(Rs["FechaResp"]), 0, Rs["FechaResp"]);
                        seguimiento1.SeguiStatus = (Int16)Interaction.IIf(Information.IsDBNull(Rs["estado"]), 0, Rs["estado"]);
                        Se.Add(seguimiento1);
                    }
                }
                return Se;

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

        public List<Seguimiento> SeguiListarVendidos(int id)
        {
            List<Seguimiento> Se = new List<Seguimiento>();
            Seguimiento seguimiento1 = new Seguimiento();
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("SeguiListarVendidos", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        seguimiento1 = new Seguimiento();
                        seguimiento1.SeguiMensaje = (string)Interaction.IIf(Information.IsDBNull(Rs["Men"]), "", Rs["Men"]);
                        seguimiento1.SeguiFechainc = (DateTime)Interaction.IIf(Information.IsDBNull(Rs["FechaInc"]), 0, Rs["FechaInc"]);
                        seguimiento1.SeguiStatus = (Int16)Interaction.IIf(Information.IsDBNull(Rs["estado"]), 0, Rs["estado"]);
                        Se.Add(seguimiento1);
                    }
                }
                return Se;

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

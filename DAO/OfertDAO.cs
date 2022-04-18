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
    public class OfertDAO
    {
        private SqlConnection connection;
        private readonly AD_Conector _datosConexionGuia;
        private readonly SqlCommand _command;
        public OfertDAO()
        {
            _command = new SqlCommand();
            _datosConexionGuia = new AD_Conector();
            connection = new SqlConnection(_datosConexionGuia.CxSQLFacturacion());
        }
        public bool AgregarOferta(Oferta oferta)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("AgregarOferta", connection);
                cmd.Parameters.AddWithValue("@idpublicacion", oferta.Ofidpublicacion);
                cmd.Parameters.AddWithValue("@id_usuario", oferta.Ofidusuario);
                cmd.Parameters.AddWithValue("@monto", oferta.Ofmonto);
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

        public bool AceptarOferta(int id)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("AceptarOferta", connection);
                cmd.Parameters.AddWithValue("@id_oferta", id);
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

        public bool RechazarOferta(moferta moferta)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("RechazarOferta", connection);
                cmd.Parameters.AddWithValue("@idOferta", moferta.Mofertaid);
                cmd.Parameters.AddWithValue("@mensaje", moferta.Mofertasmensaje);
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


        public List<Oferta> ListarOfertaAceptadasPubli(int id)
        {
            List<Oferta> lo = new List<Oferta>();
            Oferta of = new Oferta();
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("ListarOfertaAceptadasPubli", connection);
                cmd.Parameters.AddWithValue("@Id_usu", id);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        of = new Oferta();
                        of.OfFecha = (DateTime)Interaction.IIf(Information.IsDBNull(Rs["fecha"]), "", Rs["fecha"]);
                        of.Ofidpublicacion = (int)Interaction.IIf(Information.IsDBNull(Rs["id_publi"]), 0, Rs["id_publi"]);
                        of.apellidos = (string)Interaction.IIf(Information.IsDBNull(Rs["apellido"]), "", Rs["apellido"]);
                        of.nombre = (string)Interaction.IIf(Information.IsDBNull(Rs["nombre"]), "", Rs["nombre"]);
                        of.Ofmonto = (decimal)Interaction.IIf(Information.IsDBNull(Rs["monto"]), 0, Rs["monto"]);

                        lo.Add(of);
                    }
                }
                return lo;

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

        public List<Oferta> ListarOfertaAceptadaporCliente(int id)
        {
            List<Oferta> lo = new List<Oferta>();
            Oferta of = new Oferta();
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("ListarOfertaAceptadaporCliente", connection);
                cmd.Parameters.AddWithValue("@Id_usu", id);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        of = new Oferta();
                        of.OfFecha = (DateTime)Interaction.IIf(Information.IsDBNull(Rs["fecha"]), "", Rs["fecha"]);
                        of.Ofidpublicacion = (int)Interaction.IIf(Information.IsDBNull(Rs["id_publi"]), 0, Rs["id_publi"]);
                        of.apellidos = (string)Interaction.IIf(Information.IsDBNull(Rs["apellido"]), "", Rs["apellido"]);
                        of.nombre = (string)Interaction.IIf(Information.IsDBNull(Rs["nombre"]), "", Rs["nombre"]);
                        of.Ofmonto = (decimal)Interaction.IIf(Information.IsDBNull(Rs["monto"]), 0, Rs["monto"]);

                        lo.Add(of);
                    }
                }
                return lo;

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

        public List<Oferta> listarOfertasPendientes(int idPubli)
        {
            List<Oferta> lo = new List<Oferta>();
            Oferta of = new Oferta();
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("listarOfertasPendientes", connection);
                cmd.Parameters.AddWithValue("@idPubli", idPubli);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        of = new Oferta();
                        of.OfIdoferta = (int)Interaction.IIf(Information.IsDBNull(Rs["id"]), 0, Rs["id"]); ;
                        of.OfFecha = (DateTime)Interaction.IIf(Information.IsDBNull(Rs["Fecha"]), "", Rs["Fecha"]);
                        of.nombre = (string)Interaction.IIf(Information.IsDBNull(Rs["Nombre"]), "", Rs["Nombre"]);
                        of.Ofmonto = (decimal)Interaction.IIf(Information.IsDBNull(Rs["monto"]), 0, Rs["monto"]);

                        lo.Add(of);
                    }
                }
                return lo;

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


        public List<Oferta> listarOfertasenCurso(int idPubli)
        {
            List<Oferta> lo = new List<Oferta>();
            Oferta of = new Oferta();
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("listarOfertasenCurso", connection);
                cmd.Parameters.AddWithValue("@idPubli", idPubli);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        of = new Oferta();
                        of.OfIdoferta = (int)Interaction.IIf(Information.IsDBNull(Rs["id"]), 0, Rs["id"]); ;
                        of.OfFecha = (DateTime)Interaction.IIf(Information.IsDBNull(Rs["Fecha"]), "", Rs["Fecha"]);
                        of.nombre = (string)Interaction.IIf(Information.IsDBNull(Rs["Nombre"]), "", Rs["Nombre"]);
                        of.Ofmonto = (decimal)Interaction.IIf(Information.IsDBNull(Rs["monto"]), 0, Rs["monto"]);

                        lo.Add(of);
                    }
                }
                return lo;

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

        public List<Oferta> listarOfertasCulminidas(int idPubli)
        {
            List<Oferta> lo = new List<Oferta>();
            Oferta of = new Oferta();
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("listarOfertasCulminidas", connection);
                cmd.Parameters.AddWithValue("@idPubli", idPubli);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        of = new Oferta();
                        of.OfIdoferta = (int)Interaction.IIf(Information.IsDBNull(Rs["id"]), 0, Rs["id"]); ;
                        of.OfFecha = (DateTime)Interaction.IIf(Information.IsDBNull(Rs["Fecha"]), "", Rs["Fecha"]);
                        of.nombre = (string)Interaction.IIf(Information.IsDBNull(Rs["Nombre"]), "", Rs["Nombre"]);
                        of.Ofmonto = (decimal)Interaction.IIf(Information.IsDBNull(Rs["monto"]), 0, Rs["monto"]);

                        lo.Add(of);
                    }
                }
                return lo;

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

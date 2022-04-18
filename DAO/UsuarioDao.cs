using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.VisualBasic;

namespace DAO
{
    public class UsuarioDao
    {
        //llamar procedimientos almacenados
        private SqlConnection connection;
        private readonly AD_Conector _datosConexionGuia;
        private readonly SqlCommand _command;
        public UsuarioDao()
        {
            _command = new SqlCommand();
            _datosConexionGuia = new AD_Conector();
            connection = new SqlConnection(_datosConexionGuia.CxSQLFacturacion());
        }

        public bool UserRegistro(Usuario reporte)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("UserRegistro", connection);
                cmd.Parameters.AddWithValue("@tipoDocumento", reporte.UserTdId);
                cmd.Parameters.AddWithValue("@numDoc", reporte.UserNumeroDoc);
                cmd.Parameters.AddWithValue("@nombre", reporte.UserNombre);
                cmd.Parameters.AddWithValue("@apellido", reporte.UserApellido);
                cmd.Parameters.AddWithValue("@telefono", reporte.UserTelefono);
                cmd.Parameters.AddWithValue("@correo", reporte.UserCorreo);
                cmd.Parameters.AddWithValue("@pass", reporte.UserPassword);
                cmd.Parameters.AddWithValue("@direccion", reporte.Userdireccion);
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

        public bool editarUsuario(Usuario usuario)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("editarUsuario", connection);
                cmd.Parameters.AddWithValue("@id", usuario.UserId);
                cmd.Parameters.AddWithValue("@nombre", usuario.UserNombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.UserApellido);
                cmd.Parameters.AddWithValue("@telefono", usuario.UserTelefono);
                cmd.Parameters.AddWithValue("@correo", usuario.UserCorreo);
                cmd.Parameters.AddWithValue("@cuenta", usuario.UserCuenta);
                cmd.Parameters.AddWithValue("@direccion", usuario.Userdireccion);
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

        public bool upgradearUsuario(int id)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("upgradearCuenta", connection);
                cmd.Parameters.AddWithValue("@id", id);
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

        public bool userForgotPass(Usuario usuario)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("userForgotPass", connection);
                cmd.Parameters.AddWithValue("@id", usuario.UserId);
                cmd.Parameters.AddWithValue("@passNew", usuario.UserPassword);
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


        public Usuario Userlogin(Usuario usuario)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            Usuario usuario1 = new Usuario();
            try
            {
                connection.Open();
                cmd = new SqlCommand("Userlogin", connection);
                cmd.Parameters.AddWithValue("@dni", usuario.UserNumeroDoc);
                cmd.Parameters.AddWithValue("@pass", usuario.UserPassword);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        usuario1.UserId = (int)Interaction.IIf(Information.IsDBNull(Rs["Id"]), 0, Rs["Id"]);
                        usuario1.UserNombre = (string)Interaction.IIf(Information.IsDBNull(Rs["Nombre"]), "", Rs["Nombre"]);
                        usuario1.UserApellido = (string)Interaction.IIf(Information.IsDBNull(Rs["Apellido"]), "", Rs["Apellido"]);
                        usuario1.UserNumeroDoc = (string)Interaction.IIf(Information.IsDBNull(Rs["DNI"]), "", Rs["DNI"]);
                        usuario1.UserCorreo = (string)Interaction.IIf(Information.IsDBNull(Rs["Correo"]), "", Rs["Correo"]);
                        usuario1.UserTelefono = (string)Interaction.IIf(Information.IsDBNull(Rs["Telefono"]), "", Rs["Telefono"]);
                        usuario1.Userdireccion = (string)Interaction.IIf(Information.IsDBNull(Rs["direccion"]), "", Rs["direccion"]);
                        usuario1.UserCuenta = (string)Interaction.IIf(Information.IsDBNull(Rs["Cuenta"]), "", Rs["Cuenta"]);
                    }

                }
                return usuario1;

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

        //public List<Usuario> mostrar()
        //{
        //    List <Usuario> lu = new List<Usuario>();
        //    Usuario usuario1 = new Usuario();
        //    SqlCommand cmd;
        //    SqlDataReader Rs;
        //    try
        //    {
        //        connection.Open();
        //        cmd = new SqlCommand("", connection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        Rs = _command.ExecuteReader();
        //        if (Rs.HasRows)
        //        {
        //            while (Rs.Read())
        //            {
        //                usuario1 = new Usuario();
        //                usuario1.User_id = (int)Interaction.IIf(Information.IsDBNull(Rs[""]), "", Rs[""]);
        //                usuario1.User_Nombre = (string)Interaction.IIf(Information.IsDBNull(Rs[""]), "", Rs[""]);
        //                usuario1.User_TD_id = (int)Interaction.IIf(Information.IsDBNull(Rs[""]), "", Rs[""]);
        //                usuario1.User_Numero_doc = (string)Interaction.IIf(Information.IsDBNull(Rs[""]), "", Rs[""]);

        //            }
        //            return null;
        //        }
        //        return null;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //    finally {
        //        connection.Close();
        //    }
        //}

    }

}

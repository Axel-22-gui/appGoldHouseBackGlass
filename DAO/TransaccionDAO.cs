using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TransaccionDAO
    {
        private SqlConnection connection;
        private readonly AD_Conector _datosConexionGuia;
        private readonly SqlCommand _command;
        public TransaccionDAO()
        {
            _command = new SqlCommand();
            _datosConexionGuia = new AD_Conector();
            connection = new SqlConnection(_datosConexionGuia.CxSQLFacturacion());
        }


        public bool agregartransaccion(Transaccion transaccion)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("AgregarTransaccion", connection);
                cmd.Parameters.AddWithValue("@monto", transaccion.Transamonto);
                cmd.Parameters.AddWithValue("@iduser", transaccion.iduser);
                cmd.Parameters.AddWithValue("@tarjeta", transaccion.tarjeta);
                cmd.Parameters.AddWithValue("@ccv", transaccion.ccv);
                cmd.Parameters.AddWithValue("@mes", transaccion.mes);
                cmd.Parameters.AddWithValue("@anio", transaccion.anio);
                cmd.Parameters.AddWithValue("@titular", transaccion.titular);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                return true;
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

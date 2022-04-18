using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class lusuario
    {
        public bool agregarUsuario(Usuario usuario)
        {
            try
            {
                UsuarioDao udao = new UsuarioDao();
                Console.WriteLine(usuario.UserPassword);
                Console.WriteLine(usuario.UserId);
                return udao.UserRegistro(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool editarusuario(Usuario usu)
        {
            try
            {
                UsuarioDao udao = new UsuarioDao();
                return udao.editarUsuario(usu);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public bool olvidarcontrasena(Usuario usu)
        {
            try
            {
                UsuarioDao udao = new UsuarioDao();
                Console.WriteLine(usu.UserId);
                return udao.userForgotPass(usu);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Usuario Userlogin(Usuario usu)
        {
            try
            {
                UsuarioDao udao = new UsuarioDao();
                return udao.Userlogin(usu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

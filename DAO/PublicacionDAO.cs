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
    public class PublicacionDAO
    {
        private SqlConnection connection;
        private readonly AD_Conector _datosConexionGuia;
        private readonly SqlCommand _command;
        public PublicacionDAO()
        {
            _command = new SqlCommand();
            _datosConexionGuia = new AD_Conector();
            connection = new SqlConnection(_datosConexionGuia.CxSQLFacturacion());
        }


        public int AgregarPublicacion(Publicacion publicacion)
        {
            SqlCommand cmd;
            SqlDataReader Rs;
            Publicacion publicacion1 = new Publicacion();
            try
            {
                connection.Open();
                cmd = new SqlCommand("publiAgregar", connection);
                cmd.Parameters.AddWithValue("@desc", publicacion.PubliDescripcion);
                cmd.Parameters.AddWithValue("@localizacion", publicacion.Publilocalizacion);
                cmd.Parameters.AddWithValue("@lat", publicacion.Publilatitud);
                cmd.Parameters.AddWithValue("@long", publicacion.Publilongitud);
                cmd.Parameters.AddWithValue("@precio", publicacion.Publiprecio);
                cmd.Parameters.AddWithValue("@tipo", publicacion.Publitipo);
                cmd.Parameters.AddWithValue("@area", publicacion.Publiarea);
                cmd.Parameters.AddWithValue("@titulo", publicacion.Publitituloanuncio);
                cmd.Parameters.AddWithValue("@favorito", publicacion.Publifavoritos);
                DateTime fechaactual = DateTime.Now;
                DateTime masmeses = fechaactual.AddMonths(publicacion.Publifechaentera);
                publicacion.fechapostventa = masmeses;
                cmd.Parameters.AddWithValue("@postVenta", publicacion.fechapostventa);
                cmd.Parameters.AddWithValue("@idUser", publicacion.PubliUsuid);
                cmd.Parameters.AddWithValue("@provincia", publicacion.Publiprovincia);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        publicacion1 = new Publicacion();
                        publicacion1.Publiid = (int)Interaction.IIf(Information.IsDBNull(Rs["Id_publicaciones"]), 0, Rs["Id_publicaciones"]);
                    }
                }
                return publicacion1.Publiid;

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

        public List<Publicacion> filtros(Publicacion publicacion)
        {
            List<Publicacion> lp = new List<Publicacion>();
            Publicacion publicacion1 = new Publicacion();
            SqlCommand cmd;
            SqlDataReader rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("publicacionFiltros1", connection);
                cmd.Parameters.AddWithValue("@descripcion", publicacion.PubliDescripcion);
                cmd.Parameters.AddWithValue("@localizacion", publicacion.PubliDescripcion);
                cmd.Parameters.AddWithValue("@titulo", publicacion.PubliDescripcion);
                cmd.Parameters.AddWithValue("@precioMin", publicacion.PubliMinimoPrecio);
                cmd.Parameters.AddWithValue("@precioMax", publicacion.PubliMaximoPrecio);
                cmd.Parameters.AddWithValue("@areaMin", publicacion.PubliMinimaArea);
                cmd.Parameters.AddWithValue("@areaMax", publicacion.PubliMaximaArea);
                //      cmd.Parameters.AddWithValue("@tipo", publicacion.Publitipo);
                cmd.Parameters.AddWithValue("@cantBanios", publicacion.PublicantBanios);
                cmd.Parameters.AddWithValue("@cantCuarto", publicacion.PublicantCuarto);
                //         cmd.Parameters.AddWithValue("@piscina", publicacion.Publipiscina);
                cmd.Parameters.AddWithValue("@pet", publicacion.Publipet);
                cmd.Parameters.AddWithValue("@cochera", publicacion.Publicochera);
                cmd.Parameters.AddWithValue("@provincia", publicacion.Publiprovincia);
                cmd.CommandType = CommandType.StoredProcedure;
                rs = cmd.ExecuteReader();
                ImagenesDAO imagenesDAO = new ImagenesDAO();
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        publicacion1 = new Publicacion();
                        publicacion1.Publiid = (int)Interaction.IIf(Information.IsDBNull(rs["Id"]), 0, rs["Id"]);
                        publicacion1.Publitituloanuncio = (string)Interaction.IIf(Information.IsDBNull(rs["Titulo"]), 0, rs["Titulo"]);
                        publicacion1.Publifavoritos = (bool)Interaction.IIf(Information.IsDBNull(rs["Favoritos"]), false, rs["Favoritos"]);
                        publicacion1.Publiprecio = (decimal)Interaction.IIf(Information.IsDBNull(rs["Precio"]), 0, rs["Precio"]);
                        publicacion1.Publiarea = (decimal)Interaction.IIf(Information.IsDBNull(rs["Area"]), 0, rs["Area"]);
                        publicacion1.PubliDescripcion = (string)Interaction.IIf(Information.IsDBNull(rs["Descripcion"]), "", rs["Descripcion"]);
                        publicacion1.Publitipo = (string)Interaction.IIf(Information.IsDBNull(rs["Tipo"]), "", rs["Tipo"]);
                        publicacion1.Publiprovincia = (string)Interaction.IIf(Information.IsDBNull(rs["provincia"]), "", rs["provincia"]);
                        publicacion1.Imagenes = imagenesDAO.listarimagenes(publicacion1.Publiid);
                        lp.Add(publicacion1);
                    }

                }

                return lp;
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

        public List<Publicacion> publicacionListar()
        {
            List<Publicacion> lu = new List<Publicacion>();
            Publicacion pub = new Publicacion();
            SqlCommand cmd;
            SqlDataReader Rs;
            try
            {
                connection.Open();
                cmd = new SqlCommand("publicacionListar", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                ImagenesDAO imagenesDAO = new ImagenesDAO();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        pub = new Publicacion();
                        pub.Publiid = (int)Interaction.IIf(Information.IsDBNull(Rs["Id"]), 0, Rs["Id"]);
                        pub.Publitituloanuncio = (string)Interaction.IIf(Information.IsDBNull(Rs["Titulo"]), "", Rs["Titulo"]);
                        pub.Publifavoritos = (bool)Interaction.IIf(Information.IsDBNull(Rs["Favoritos"]), false, Rs["Favoritos"]);
                        pub.Publiprecio = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Precio"]), 0, Rs["Precio"]);
                        pub.Publiarea = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Area"]), 0, Rs["Area"]);
                        pub.PubliDescripcion = (string)Interaction.IIf(Information.IsDBNull(Rs["Descripcion"]), "", Rs["Descripcion"]);
                        pub.Publitipo = (string)Interaction.IIf(Information.IsDBNull(Rs["Tipo"]), "", Rs["Tipo"]);
                        pub.Publiprovincia = (string)Interaction.IIf(Information.IsDBNull(Rs["provincia"]), "", Rs["provincia"]);
                        pub.Imagenes = imagenesDAO.listarimagenes(pub.Publiid);
                        lu.Add(pub);

                    }
                }
                return lu;

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

        public List<MisPublis> publicacionListarById(int id)
        {
            List<MisPublis> lu = new List<MisPublis>();
            MisPublis pub = new MisPublis();
            SqlCommand cmd;
            SqlDataReader Rs;
            int contador = 0;
            try
            {
                connection.Open();
                cmd = new SqlCommand("publicacionSeleccionarUsu", connection);
                cmd.Parameters.AddWithValue("@idUsu", id);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                ImagenesDAO imagenesDAO = new ImagenesDAO();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                            pub = new MisPublis();
                            pub.Publiid = (int)Interaction.IIf(Information.IsDBNull(Rs["Id"]), 0, Rs["Id"]);
                            pub.Publitituloanuncio = (string)Interaction.IIf(Information.IsDBNull(Rs["Titulo"]), "", Rs["Titulo"]);
                            pub.PubliDescripcion = (string)Interaction.IIf(Information.IsDBNull(Rs["Estado"]), "", Rs["Estado"]);
                            pub.Publilocalizacion = (string)Interaction.IIf(Information.IsDBNull(Rs["localizacion"]), "", Rs["localizacion"]);
                            pub.Publiprecio = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Precio"]), 0, Rs["Precio"]);
                            pub.Publiarea = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Area"]), 0, Rs["Area"]);
                            pub.Imagenes = new List<ArchivoRequest>();
                            pub.Imagenes.Add(new ArchivoRequest());
                            pub.Imagenes[0].nombre = (string)Interaction.IIf(Information.IsDBNull(Rs["Ruta"]), "", Rs["Ruta"]);
                        
                        lu.Add(pub);
                        contador++;
                    }

                }
                return lu;

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

        public List<MisPubliscompras> publicacionComprasUsu(int idusu)
        {
            List<MisPubliscompras> lu = new List<MisPubliscompras>();
            MisPubliscompras pub = new MisPubliscompras();
            SqlCommand cmd;
            SqlDataReader Rs;
            int contador = 0;
            try
            {
                connection.Open();
                cmd = new SqlCommand("publicacionComprasUsu", connection);
                cmd.Parameters.AddWithValue("@idUsu", idusu);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                ImagenesDAO imagenesDAO = new ImagenesDAO();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        pub = new MisPubliscompras();
                        pub.Publiid = (int)Interaction.IIf(Information.IsDBNull(Rs["Id"]), 0, Rs["Id"]);
                        pub.Publitituloanuncio = (string)Interaction.IIf(Information.IsDBNull(Rs["Titulo"]), "", Rs["Titulo"]);
                     //   pub.PubliDescripcion = (string)Interaction.IIf(Information.IsDBNull(Rs["Estado"]), "", Rs["Estado"]);
                        pub.Publilocalizacion = (string)Interaction.IIf(Information.IsDBNull(Rs["localizacion"]), "", Rs["localizacion"]);
                        pub.Publiprecio = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Precio"]), 0, Rs["Precio"]);
                        pub.Publiarea = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Area"]), 0, Rs["Area"]);
                        pub.Publiidusu = (int)Interaction.IIf(Information.IsDBNull(Rs["Vendedor"]), 0, Rs["Vendedor"]);
                        pub.Ofertasusu = (int)Interaction.IIf(Information.IsDBNull(Rs["IdOf"]), 0, Rs["IdOf"]);
                        pub.Imagenes = new List<ArchivoRequest>();
                        pub.Imagenes.Add(new ArchivoRequest());
                        pub.Imagenes[0].nombre = (string)Interaction.IIf(Information.IsDBNull(Rs["Ruta"]), "", Rs["Ruta"]);

                        lu.Add(pub);
                        contador++;
                    }

                }
                return lu;

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


        public List<MisPubliscompras> publicacionenprocesosUsu(int idusu)
        {
            List<MisPubliscompras> lu = new List<MisPubliscompras>();
            MisPubliscompras pub = new MisPubliscompras();
            SqlCommand cmd;
            SqlDataReader Rs;
            int contador = 0;
            try
            {
                connection.Open();
                cmd = new SqlCommand("publicacionenprocesoUsu", connection);
                cmd.Parameters.AddWithValue("@idUsu", idusu);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                ImagenesDAO imagenesDAO = new ImagenesDAO();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        pub = new MisPubliscompras();
                        pub.Publiid = (int)Interaction.IIf(Information.IsDBNull(Rs["Id"]), 0, Rs["Id"]);
                        pub.Publitituloanuncio = (string)Interaction.IIf(Information.IsDBNull(Rs["Titulo"]), "", Rs["Titulo"]);
                        //   pub.PubliDescripcion = (string)Interaction.IIf(Information.IsDBNull(Rs["Estado"]), "", Rs["Estado"]);
                        pub.Publilocalizacion = (string)Interaction.IIf(Information.IsDBNull(Rs["localizacion"]), "", Rs["localizacion"]);
                        pub.Publiprecio = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Precio"]), 0, Rs["Precio"]);
                        pub.Publimonto = (decimal)Interaction.IIf(Information.IsDBNull(Rs["monto"]), 0, Rs["monto"]);
                        pub.Publiarea = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Area"]), 0, Rs["Area"]);
                        pub.Ofertasusu = (int)Interaction.IIf(Information.IsDBNull(Rs["IdOf"]), 0, Rs["IdOf"]);
                        pub.Imagenes = new List<ArchivoRequest>();
                        pub.Imagenes.Add(new ArchivoRequest());
                        pub.Imagenes[0].nombre = (string)Interaction.IIf(Information.IsDBNull(Rs["Ruta"]), "", Rs["Ruta"]);

                        lu.Add(pub);
                        contador++;
                    }

                }
                return lu;

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

        public List<MisPubliscompras> publicacionculminadoUsu(int idusu)
        {
            List<MisPubliscompras> lu = new List<MisPubliscompras>();
            MisPubliscompras pub = new MisPubliscompras();
            SqlCommand cmd;
            SqlDataReader Rs;
            int contador = 0;
            try
            {
                connection.Open();
                cmd = new SqlCommand("publicacionCulminadoUsu", connection);
                cmd.Parameters.AddWithValue("@idUsu", idusu);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                ImagenesDAO imagenesDAO = new ImagenesDAO();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        pub = new MisPubliscompras();
                        pub.Publiid = (int)Interaction.IIf(Information.IsDBNull(Rs["Id"]), 0, Rs["Id"]);
                        pub.Publitituloanuncio = (string)Interaction.IIf(Information.IsDBNull(Rs["Titulo"]), "", Rs["Titulo"]);
                        //   pub.PubliDescripcion = (string)Interaction.IIf(Information.IsDBNull(Rs["Estado"]), "", Rs["Estado"]);
                        pub.Publilocalizacion = (string)Interaction.IIf(Information.IsDBNull(Rs["localizacion"]), "", Rs["localizacion"]);
                        pub.Publiprecio = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Precio"]), 0, Rs["Precio"]);
                        pub.Publimonto = (decimal)Interaction.IIf(Information.IsDBNull(Rs["monto"]), 0, Rs["monto"]);
                        pub.Publiarea = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Area"]), 0, Rs["Area"]);
                        pub.Ofertasusu = (int)Interaction.IIf(Information.IsDBNull(Rs["IdOf"]), 0, Rs["IdOf"]);
                        pub.Imagenes = new List<ArchivoRequest>();
                        pub.Imagenes.Add(new ArchivoRequest());
                        pub.Imagenes[0].nombre = (string)Interaction.IIf(Information.IsDBNull(Rs["Ruta"]), "", Rs["Ruta"]);

                        lu.Add(pub);
                        contador++;
                    }

                }
                return lu;

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

        public Publicacion publicacionSeleccionar(int id)
        {
            Publicacion pub = new Publicacion();
            Detallescasa detcas = new Detallescasa();
            SqlCommand cmd;
            SqlDataReader Rs;
            int contador = 0;
            try
            {
                connection.Open();
                cmd = new SqlCommand("publicacionSeleccionar", connection);
                cmd.Parameters.AddWithValue("@idPubli", id);
                cmd.CommandType = CommandType.StoredProcedure;
                Rs = cmd.ExecuteReader();
                ImagenesDAO imagenesDAO = new ImagenesDAO();
                if (Rs.HasRows)
                {
                    while (Rs.Read())
                    {
                        if (contador == 0)
                        {
                            pub = new Publicacion();
                            pub.detallesCasa = new List<Detallescasa>();

                            pub.Publitituloanuncio = (string)Interaction.IIf(Information.IsDBNull(Rs["Titulo"]), "", Rs["Titulo"]);
                            pub.PubliDescripcion = (string)Interaction.IIf(Information.IsDBNull(Rs["Descripcion"]), "", Rs["Descripcion"]);
                            pub.Publilocalizacion = (string)Interaction.IIf(Information.IsDBNull(Rs["localizacion"]), "", Rs["localizacion"]);
                            pub.Publilatitud = (decimal)Interaction.IIf(Information.IsDBNull(Rs["latitud"]), 0, Rs["latitud"]);
                            pub.Publilongitud = (decimal)Interaction.IIf(Information.IsDBNull(Rs["longitud"]), 0, Rs["longitud"]);
                            pub.Publiprecio = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Precio"]), 0, Rs["Precio"]);
                            pub.Publiarea = (decimal)Interaction.IIf(Information.IsDBNull(Rs["Area"]), 0, Rs["Area"]);
                            pub.PubliDescripcion = (string)Interaction.IIf(Information.IsDBNull(Rs["Descripcion"]), "", Rs["Descripcion"]);
                            pub.Publitipo = (string)Interaction.IIf(Information.IsDBNull(Rs["Tipo"]), "", Rs["Tipo"]);
                            pub.Publiprovincia = (string)Interaction.IIf(Information.IsDBNull(Rs["provincia"]), "", Rs["provincia"]);
                            pub.Imagenes = imagenesDAO.listarimagenes(id);

                        }
                        if (Rs["Detalle"] != null)
                        {
                            detcas = new Detallescasa();
                            detcas.iddetalle = (int)Interaction.IIf(Information.IsDBNull(Rs["IdDetalle"]), 0, Rs["IdDetalle"]);
                            detcas.descripcion = (string)Interaction.IIf(Information.IsDBNull(Rs["Detalle"]), "", Rs["Detalle"]);
                            detcas.Cantidad = (int)Interaction.IIf(Information.IsDBNull(Rs["Cantidad"]), 0, Rs["Cantidad"]);
                            pub.detallesCasa.Add(parseDetalles(detcas));
                        }

                        contador++;

                    }

                }
                return pub;

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
        private Detallescasa parseDetalles(Detallescasa detail)
        {
            Detallescasa detailParse = new Detallescasa();
            detailParse = detail;
            if (detail.iddetalle == 6 || detail.iddetalle == 7)
            {
                if (detail.Cantidad == 2)
                {
                    detailParse.Valor = "Sí";
                }
                else if (detail.Cantidad == 1)
                {
                    detailParse.Valor = "No";
                }
            }
            if (detail.iddetalle == 13)
            {
                if (detail.Cantidad == 0)
                {
                    detailParse.Valor = "Buen Estado";
                }
                else if (detail.Cantidad == 1)
                {
                    detailParse.Valor = "Regular";
                }
                else
                {
                    detailParse.Valor = "Mal Estado";
                }
            }
            return detailParse;
        }

    }
}

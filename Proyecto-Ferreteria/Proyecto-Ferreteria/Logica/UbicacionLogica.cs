using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Proyecto_Ferreteria.Models;

namespace Proyecto_Ferreteria.Logica
{
    public class UbicacionLogica
    {

        private static UbicacionLogica _instancia = null;

        public UbicacionLogica()
        {

        }

        public static UbicacionLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new UbicacionLogica();
                }
                return _instancia;
            }
        }



        public List<Provincia> ObtenerProvincia()
        {
            List<Provincia> lst = new List<Provincia>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from provincia", oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lst.Add(new Provincia()
                            {
                                IdProvincia = dr["IdProvincia"].ToString(),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lst = new List<Provincia>();
                }
            }
            return lst;
        }

        public List<Canton> ObtenerCanton(string _idcanton)
        {
            List<Canton> lst = new List<Canton>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from canton where IdProvincia = @idprovincia", oConexion);
                    cmd.Parameters.AddWithValue("@idprovincia", _idcanton);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lst.Add(new Canton()
                            {
                                IdCanton = dr["IdCanton"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                IdProvincia = dr["IdProvincia"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lst = new List<Canton>();
                }
            }
            return lst;
        }

        public List<Distrito> ObtenerDistrito(string _idcanton, string _idprovincia)
        {
            List<Distrito> lst = new List<Distrito>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from distrito where IdProvincia = @idprovincia and IdCanton = @idcanton", oConexion);
                    cmd.Parameters.AddWithValue("@idcanton", _idcanton);
                    cmd.Parameters.AddWithValue("@idprovincia", _idprovincia);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lst.Add(new Distrito()
                            {
                                IdDistrito = dr["IdDistrito"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                IdProvincia = dr["IdProvincia"].ToString(),
                                IdCanton = dr["IdCanton"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lst = new List<Distrito>();
                }
            }
            return lst;
        }

    }
}
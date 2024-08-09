using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using _04TiendaTarea.Config;

namespace _04TiendaTarea.Models
{
    internal class PaisesModel
    {
        public int IdPais { get; set; }
        public string Detalle { get; set; }

        private ConexionBDD conexionBDD = new ConexionBDD();

        SqlDataReader lector;
        List<PaisesModel> listaPaises = new List<PaisesModel>();
        SqlCommand cmd = new SqlCommand();

        public List<PaisesModel> Todos()
        {
            string cadena = "select * from paises";
            SqlDataAdapter adapter = new SqlDataAdapter(cadena, conexionBDD.AbrirConexion());
            DataTable data = new DataTable();
            adapter.Fill(data);

            foreach(DataRow fila in data.Rows)
            {
                PaisesModel pais = new PaisesModel
                {
                    IdPais = Convert.ToInt32(fila["IdPais"]),
                    Detalle = fila["Detalle"].ToString()

                };
                listaPaises.Add(pais);
            }


            conexionBDD.CerrarConexion();
            return listaPaises;
        }

        public string insertar(PaisesModel  pais)
        {
            try
            {
                cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "INSERT INTO Paises (Detalle) VALUES (@Detalle)";
                cmd.Parameters.AddWithValue("@Detalle", pais.Detalle);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                conexionBDD.CerrarConexion();
            }
        }

        public string editar(PaisesModel pais)
        {
            try
            {
                cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "UPDATE Paises SET Detalle = '" + pais.Detalle + "' WHERE IdPais = " + pais.IdPais;
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                conexionBDD.CerrarConexion();
            }
        }


        public string eliminar(PaisesModel pais)
        {
            try
            {
                cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "delete from paises where IdPais =" + pais.IdPais;
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception e)
            {

                return e.Message;
            }
            finally
            {
                conexionBDD.CerrarConexion();
            }
        }
    }
}

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
    }
}

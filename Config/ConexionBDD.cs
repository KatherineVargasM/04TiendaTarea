using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _04TiendaTarea.Config
{
    internal class ConexionBDD
    {
        //string cande = "Server=.;database=PaisCiudad;uid=sa;pwd=corpad17k";
        private SqlConnection con = new SqlConnection("Server=.;database=TareaBDD;uid=sa;pwd=corpad17k");

        public SqlConnection AbrirConexion ()
        {
            if(con.State == ConnectionState.Closed)
                con.Open();
                return con;
            
        }

        public SqlConnection CerrarConexion()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;

        }
    }
}

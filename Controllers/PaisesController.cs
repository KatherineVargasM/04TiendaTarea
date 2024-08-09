using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _04TiendaTarea.Models;

namespace _04TiendaTarea.Controllers
{
    internal class PaisesController
    {
        private PaisesModel paisesModel = new PaisesModel();
        public List<PaisesModel> todos()
        {
            List<PaisesModel> listaPaises = new List<PaisesModel>();
            listaPaises = paisesModel.Todos();
            return listaPaises;
        }
    }
}

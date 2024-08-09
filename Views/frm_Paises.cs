using _04TiendaTarea.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _04TiendaTarea.Models;

namespace _04TiendaTarea
{
    public partial class frm_Paises : Form
    {
        PaisesController paisesController = new PaisesController();
        public string IdPais = null;
        public frm_Paises()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frm_Paises_Load(object sender, EventArgs e)
        {
            cargaLista();
        }


        public void cargaLista()
        {
            lst_Paises.DataSource = paisesController.todos();
            lst_Paises.DisplayMember = "Detalle";
            lst_Paises.ValueMember = "IdPais";

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (lst_Paises.SelectedItem != null)
            {
                IdPais = lst_Paises.SelectedValue.ToString();
                txt_Detalle.Text = lst_Paises.GetItemText(lst_Paises.SelectedItem);
            }
            else
            {
                MessageBox.Show("Seleccione un pais de la lista.");
            }
        }

        private void lst_Paises_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lst_Paises_DoubleClick(object sender, EventArgs e)
        {
            IdPais = lst_Paises.SelectedValue.ToString();
            txt_Detalle.Text = lst_Paises.GetItemText(lst_Paises.SelectedItem);
        }

        private void btn_Grabar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            PaisesModel pais = new PaisesModel
            {
                IdPais = Convert.ToInt32(IdPais),
                Detalle = txt_Detalle.Text
            };

            if (Convert.ToInt32(IdPais) > 0)
            {
                //editar
                respuesta = paisesController.editar(pais);
            }
            else
            {
                respuesta = paisesController.insertar(pais);
            }
                if (respuesta == "ok")
                {
                    IdPais = null;
                    cargaLista();
                    MessageBox.Show("Se guardo con exito");
                }
                else
                {
                    IdPais = null;
                    MessageBox.Show("Error al guardar.");
                }
            

        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            PaisesModel pais = new PaisesModel
            {
                IdPais = Convert.ToInt32(lst_Paises.SelectedValue)
            };
            string respuesta = paisesController.eliminar(pais);

            if (respuesta == "ok")
            {
                cargaLista();
                MessageBox.Show("País eliminado con éxito.");
            }
            else
            {
                MessageBox.Show("Error al eliminar el país.");
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txt_Detalle.Text = string.Empty;
            IdPais = null;
            lst_Paises.ClearSelected();
        }
    }
}

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
    }
}

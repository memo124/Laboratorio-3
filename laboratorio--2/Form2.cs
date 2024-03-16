using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laboratorio__2
{
    public partial class Form2 : Form
    {
        public int? cod;
        public Form2(int? cod)
        {
            InitializeComponent();
            this.cod = cod.Value;
        }

        public  void cargarDatos() 
        {
            producto productos = new producto();
            productos = productos.ObtenerUsuario(this.cod);
            txtcodigo.Text = productos.codigoprod.ToString();
            txtprecio.Text = productos.preciounit.ToString();
            txtproducto.Text = productos.codigoprod.ToString();
            txtproveedor.Text = productos.nombreprov.ToString();
            txtunidad.Text = productos.unidades.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            producto daoUsuario = new producto();
            try
            {
                if (this.cod == 0)
                {

                    daoUsuario.Agregar(int.Parse(txtcodigo.Text), txtproducto.Text, txtproveedor.Text, double.Parse(txtprecio.Text), int.Parse(txtunidad.Text));
                }
                if (this.cod != 0)
                {
                    daoUsuario.Actualizar(int.Parse(txtcodigo.Text), txtproducto.Text, txtproveedor.Text, double.Parse(txtprecio.Text), int.Parse(txtunidad.Text), (int)this.cod);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);

            }
            limpiar();
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void limpiar()
        {
            txtcodigo.Text = string.Empty;
            txtprecio.Text = string.Empty;
            txtproducto.Text = string.Empty;
            txtproveedor.Text = string.Empty;
            txtunidad.Text = string.Empty;
        }
    }
}

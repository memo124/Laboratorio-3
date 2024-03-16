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
    public partial class Form3 : Form
    {
        private List<producto> Productos = new List<producto>();
        private producto producto = new producto();
        private int edit_indice = -1;
        private int cod = 0;

        public Form3()
        {
            InitializeComponent();
            
        }
        public void CargarDatos()
        {
            producto usuarioDto = new producto();
            Productos = usuarioDto.Obtener();
            dataGridView1.DataSource = Productos;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow selected = dataGridView1.SelectedRows[0];
            int posicion = dataGridView1.Rows.IndexOf(selected);
            DataGridViewRow row = dataGridView1.Rows[posicion];
            this.cod = Convert.ToInt32(row.Cells["codigoprod"].Value);

            producto.Eliminar(this.cod);
            CargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (producto.codigoprod != 0) return;
            DataGridViewRow selected = dataGridView1.SelectedRows[0];
            int posicion = dataGridView1.Rows.IndexOf(selected);
            DataGridViewRow row = dataGridView1.Rows[posicion];
            this.cod = Convert.ToInt32(row.Cells["codigoprod"].Value);

            edit_indice = posicion; //copio esa variable en índice editado
            producto = Productos[posicion];
            Form2 form2 = new Form2(this.cod);
            form2.cargarDatos();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
    }
}

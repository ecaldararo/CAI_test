using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Prueba
{
    public partial class Form1 : Form
    {
        private List<Persona> listaPersonas;
        private SucursalControlador suc1;
        public Form1()
        {
            InitializeComponent();

            suc1 = new SucursalControlador(1, "Pampa y la vía");

            suc1.AgregarPersonas(new Persona("Rosa", "Melena"));
            suc1.AgregarPersonas(new Persona("Cielo", "Díaz"));
            suc1.AgregarPersonas(new Persona("Rio", "Berlín"));

            listaPersonas = suc1.ListaPersonas();

            listBox1.DataSource = null;
            listBox1.DataSource = listaPersonas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = listaPersonas;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            // validar (try en click, catch messagebox)

            try
            {
                Validar();
                
                Persona p = new Persona(txtNombre.Text, txtApellido.Text);
                listaPersonas.Add(p);
                MessageBox.Show("Persona Agregada");
                Limpiar();
                Recargar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
            
        }
        private void Validar()
        {
            if (txtNombre.Text == string.Empty)
                throw new Exception("Nombre vacío");
        }

        private void Limpiar()
        {
            txtApellido.Text = String.Empty;
            txtNombre.Text = String.Empty;
        }

        private void Recargar()
        {
            listaPersonas = suc1.ListaPersonas();
            listBox1.DataSource = null;
            listBox1.DataSource = listaPersonas;
        }
    }

}

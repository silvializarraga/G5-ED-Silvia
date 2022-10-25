using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaEnlazada
{
    public partial class Form1 : Form
    {
        ListaEnlazada miLista = new ListaEnlazada(); //objeto de tipo listaEnlazada (se trabajará con el objeto)
        public Form1()
        {
            InitializeComponent();
        }

        void AgregarItem(Nodo unNodo) // procedimiento para agregar los nodos a la lista
        {
            if (unNodo != null)
            {
                lstNombres.Items.Add(unNodo.Nombre);
                AgregarItem(unNodo.Siguiente); //se repite hasta llegar al nodo con null
            }
        }

        public void Mostrar()
        {
            lstNombres.Items.Clear(); //se limpia la lista antes de hacer todo
            if (miLista.Inicio != null)
            {
                // Agregar el nombre al listbox
                AgregarItem(miLista.Inicio);
            }
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "") //si textbox es distinto a vacio 
            {
                Nodo unNuevoNodo = new Nodo(); // se crea un nuevo nodo de tipo Nodo
                unNuevoNodo.Nombre = txtNombre.Text; // se pasa lo que esta en el textbox al nodo
                miLista.AgregarInicio(unNuevoNodo); //aqui se manda a llamar para agregar el nodo al incio con el boton
                Mostrar();
                txtNombre.Text = ""; // se limpia el textbox para agregar mas
                txtNombre.Focus();
            }
        }

        private void btnAgregarFinal_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != "")
            {
                Nodo unNuevoNodo = new Nodo(); // se crea un nuevo nodo de tipo Nodo
                unNuevoNodo.Nombre = txtNombre.Text; // se pasa lo que esta en el textbox al nodo
                miLista.AgregarFinal(unNuevoNodo);
                Mostrar();
                txtNombre.Text = ""; 
                txtNombre.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEliminarInicio_Click(object sender, EventArgs e)
        {
            if (miLista.Inicio == null)
            {
                string text = "La lista está vacia, no puedes eliminar nada :( ";
                MessageBox.Show(text);
            }
            else
            {
                lstNombres.Items.RemoveAt(lstNombres.SelectedIndex);
                txtNombre.Text = "";
                txtNombre.Focus();
            }

        }

        private void btnVaciar_Click(object sender, EventArgs e)
        {
            if (miLista.Inicio == null)
            {
                string text = "La lista está vacia, no puedes vaciarla :( ";
                MessageBox.Show(text);
            }
            else
            {
                Nodo unNuevoNodo = new Nodo();
                while (this.miLista.Inicio != null)
                {
                    unNuevoNodo = miLista.Inicio;
                    miLista.Inicio = null;
                }

                lstNombres.Items.Clear();
                txtNombre.Text = "";
                txtNombre.Focus();

            }
         
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {
            // le di click por accidente jeje
        }
    }
    
}

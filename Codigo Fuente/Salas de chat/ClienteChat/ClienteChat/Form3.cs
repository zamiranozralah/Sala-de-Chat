using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace ClienteChat
{
    public partial class Form3 : Form
    {
        private cliente c;
        public Form3(String sala)
        {
            InitializeComponent();
            label1.Text = sala;
            c = new cliente("127.0.0.1", 1234, label2.Text, richTextBox1, obtenerNombreDeSala());
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void actualizarLabelUsername(string nuevoValor)
        {
            label2.Text = nuevoValor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = label2.Text+": "+textBox1.Text;
            c.EnviarMensaje(mensaje);
            textBox1.Text = "";
        }
        public string obtenerNombreDeSala()
        {
            return label1.Text;
        }
    }
}

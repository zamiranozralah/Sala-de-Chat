using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteChat
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3("juegos");
            form3.actualizarLabelUsername(label2.Text);
            form3.FormClosed += (s, args) => form3.Dispose();
            form3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3("tarea");
            form3.actualizarLabelUsername(label2.Text);
            form3.FormClosed += (s, args) => form3.Dispose();
            form3.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3("6to 3ra");
            form3.actualizarLabelUsername(label2.Text);
            form3.FormClosed += (s, args) => form3.Dispose();
            form3.Show();
            this.Hide();
        }
        public void actualizarUsername(string nuevoValor)
        {
            label2.Text = nuevoValor;
        }


    }
}

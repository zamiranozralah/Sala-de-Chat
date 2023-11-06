
namespace ClienteChat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ///boton de continuar
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Count() != 0)
            {
                Form2 form2 = new Form2();
                form2.actualizarUsername(textBox1.Text);
                form2.Show();
                this.Hide();
            }
            else {
                label3.Visible = true;
            }
        }
    }
}
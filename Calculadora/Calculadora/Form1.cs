namespace Calculadora
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }

        private void agregarNumero(string numero)
        {
            if (txtResultado.Text == "0")
                txtResultado.Text = "";

            txtResultado.Text += numero;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void Calculadora_Load(object sender, EventArgs e)
        {
            private void agregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "";

                textResultado.Text += boton.Text;
            }
            else
            {
                textBox1.Text += numero;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            
            agregarNumero(boton.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            agregarNumero(boton.Text);
        }

    }
}

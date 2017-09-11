using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades_Calculadora;

namespace FrmCalculadora
{
    public partial class Form1 : Form
    {
        Numero numero1;
        Numero numero2;

        public Form1()
        {
            InitializeComponent();
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double numeroAConvertir = 0;
            String operador = cmbOperacion.Text;
            numero1 = new Numero(txtNumero1.Text);
            numero2 = new Numero(txtNumero2.Text);

            numeroAConvertir = Calculadora.Operar(numero1, numero2, operador);

            lblResultado.Text = numeroAConvertir.ToString();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = "Resultado";
        }
    }
}

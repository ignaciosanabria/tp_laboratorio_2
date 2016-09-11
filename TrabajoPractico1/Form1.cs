using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPractico1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add(new Item("+"));
            comboBox1.Items.Add(new Item("-"));
            comboBox1.Items.Add(new Item("*"));
            comboBox1.Items.Add(new Item("/"));
        }

        /// <summary>
        /// CLASE PUBLICA DE ITEMS QUE SE VAN A VISUALIZAR EN EL COMBO BOX.
        /// </summary>
        public class Item {
            string item;
            public Item(string item)
            {
                this.item = Calculadora.validarOperador(item);
            }
            /// <summary>
            /// RETURNA LOS ITEMS QUE SE VAN A VISUALIZAR EN EL COMBO BOX
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return this.item;
            }
        }

        /// <summary>
        /// METODO QUE REALIZA LA OPERACION ARITMETICA SELECCIONADA A TRAVES DEL ITEM DEL COMBO BOX SELECCIONADO. ATENCION SI NO SELECCIONA NINGUN ITEM, SE SUMARAN AMBOS NUMEROS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(this.textBox2.Text);
            Numero numero2 = new Numero(this.textBox1.Text);

            this.label1.Text = Calculadora.operar(numero1, numero2, comboBox1.Text).ToString();
 
        }

        /// <summary>
        /// METODO QUE LIMPIA LOS ELEMENTOS DE LA CALCULADORA.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.label1.Text = "";
            this.comboBox1.Text = "";
        }
    }
}

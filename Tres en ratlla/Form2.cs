using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tres_en_ratlla
{
    public partial class Form2 : Form
    {
        public String jug1, jug2;
        public Form2()
        {
            InitializeComponent();
            jug1 = "";
            jug2 = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            jug1 = textBox1.Text;
            jug2 = textBox2.Text;
            Close();
        }
    }
}

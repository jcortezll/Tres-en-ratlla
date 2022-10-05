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
    public partial class Form1 : Form
    {
        int turno, X, O;
        int[,] panel = new int[3,3];
        String jugador1, jugador2, txtJg1, txtJg2;
        public Form1()
        {
            InitializeComponent();
            Iniciar();
        }
        private void Iniciar()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    panel[i,j] = 0;
                }
            }
            Form2 demanarNoms = new Form2();
            demanarNoms.ShowDialog();
            jugador1 = demanarNoms.jug1;
            jugador2 = demanarNoms.jug2;

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Control etiqueta = control as Label;
                etiqueta.Text = "";
            }
            if(jugador1 != "")
            {
                txtJg1 = "Turn de " + jugador1;
            }
            else
            {
                txtJg1 = "Turn del jugador 1";
                jugador1 = "jugador 1";
            }
            if(jugador2 != "")
            {
                txtJg2 = "Turn de " + jugador2;
            }
            else
            {
                txtJg2 = "Turn del jugador 2";
                jugador2 = "jugador 2";
            }
            turnLbl.Text = txtJg1;
            turno = 0;
            X = 0;
            O = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label etiqueta = sender as Label;
            int i = (int)char.GetNumericValue(etiqueta.Name[5]);
            int j = (int)char.GetNumericValue(etiqueta.Name[6]);
            //Si no hay ficha en esa posición y el jg1 o el jg2 no ha tirado todas sus fichas
            if (panel[i, j] == 0 && X != 3 || O!=3)
            {
                if (turno % 2 == 0)
                {
                    etiqueta.Text = "X";
                    turnLbl.Text = txtJg2;
                    panel[i, j] = 1;
                    X++;
                }
                else
                {
                    etiqueta.Text = "O";
                    turnLbl.Text = txtJg1;
                    panel[i, j] = 2;
                    O++;
                }
                turno++;
                CompruebaGanador();
            }
            //Si hay ficha en esa posición y el jg1 o el jg2 han tirado todas las fichas
            else 
            {
                if (turno % 2 == 0 && etiqueta.Text == "X")
                {
                    etiqueta.Text = "";
                    panel[i, j] = 0;
                    X--;
                }
                else if (turno % 2 == 1 && etiqueta.Text == "O")
                {
                    etiqueta.Text = "";
                    panel[i, j] = 0;
                    O--;
                }
            }
        }

        private void CompruebaGanador()
        {
            bool ganaAlguien = false;
            if (panel[0,0] == panel[0,1] && panel[0,1] == panel[0,2] && panel[0,0] != 0)
            {
                ganaAlguien = true;
            }
            else if (panel[1,0] == panel[1,1] && panel[1,1] == panel[1,2] && panel[1,0] != 0)
            {
                ganaAlguien = true;
            }
            else if (panel[2,0] == panel[2,1] && panel[2,1] == panel[2,2] && panel[2,0] != 0)
            {
                ganaAlguien = true;
            }
            else if (panel[0,0] == panel[1,0] && panel[1,0] == panel[2,0] && panel[0,0] != 0)
            {
                ganaAlguien = true;
            }
            else if (panel[0,1] == panel[1,1] && panel[1,1] == panel[2,1] && panel[0,1] != 0)
            {
                ganaAlguien = true;
            }
            else if (panel[0,2] == panel[1,2] && panel[1,2] == panel[2,2] && panel[0,2] != 0)
            {
                ganaAlguien = true;
            }
            else if (panel[0,0] == panel[1,1] && panel[1,1] == panel[2,2] && panel[0,0] != 0)
            {
                ganaAlguien = true;
            }
            else if (panel[0,2] == panel[1,1] && panel[1,1] == panel[2,0] && panel[0,2] != 0)
            {
                ganaAlguien = true;
            }
            if (ganaAlguien == true)
            {
                turnLbl.Text = "S'acabat!";
                if (turno % 2 == 0)
                {   
                    MessageBox.Show("Gana " + jugador2, "Fin");
                }
                else
                {
                    MessageBox.Show( "Gana " + jugador1, "Fin");
                }
                Iniciar();
            }
        }
    }
}

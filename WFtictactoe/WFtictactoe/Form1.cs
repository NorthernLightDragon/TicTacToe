using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFtictactoe
{
    public partial class Form1 : Form
    {

        bool turn = true;  //true = X turn; false = Y turn
        int turn_count = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By IN","Tic Tac Toe About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button bu = (Button)sender;
            if (turn)
                bu.Text = "X";
            else
                bu.Text = "O";

            turn = !turn;
            bu.Enabled = false;
            turn_count++;

            checkForWinner();
        }

        private void checkForWinner()   
        {
            bool got_winner = false;

            //horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                got_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                got_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                got_winner = true;

            //vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                got_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                got_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                got_winner = true;

            //diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                got_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                got_winner = true;
            


            if (got_winner)
            {
                disableButtons();

                String winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + "wins!");
            }//end got_winner

            else
            {
                if(turn_count == 9)
                    MessageBox.Show("Draw!");
            }
        }

            private void disableButtons()
            {
                try
                {
                    foreach (Control c in Controls)
                    {
                        Button bu = (Button)c;
                        bu.Enabled = false;
                    }//end foreach
                }//end try
                catch { }
            }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button bu = (Button)c;
                    bu.Enabled = true;
                    bu.Text = "";
                }//end foreach
            }//end try
            catch { }
        }
    }
}


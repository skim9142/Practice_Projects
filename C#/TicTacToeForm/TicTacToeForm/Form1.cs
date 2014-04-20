using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeForm
{
    public partial class Form1 : Form
    {

        bool turn = true;       // True = X; false = O
        int turn_count = 0;     // Counts number of turns
        DialogResult dR;

        public Form1()
        {
            InitializeComponent();
        }

        // Displays a message box for the "About" button
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simple Tic Tac Toe Game. Created by Sean Kim.");
        }

        // Exits program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Event for whenver buttons are clicked
        private void button_click(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;  // Create button object

            if (turn)                   // Goes to the alternation process
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            turn = !turn;               // Alternates turns (X & O) for every click
            b.Enabled = false;          // Turns off the button after it is clicked

            turn_count++;               // Counts the number of turns for the purpose of a draw at the end

            winChecker();               // Constantly checks if there is a winner

        }

        // Checks if there is a winner
        private void winChecker()
        {

            bool winner = false;

            // Horizontal checking
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
            {
                winner = true;
            }
            if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled))
            {
                winner = true;
            }
            if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled))
            {
                winner = true;
            }
            // Vertical checking
            if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled))
            {
                winner = true;
            }
            if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
            {
                winner = true;
            }
            if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled))
            {
                winner = true;
            }
            // Diagonal checking
            if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled))
            {
                winner = true;
            }
            if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button3.Enabled))
            {
                winner = true;
            }

            // Displays winner
            if (winner)
            {

                disableButtons();

                String winnerName = "";
                if (turn)
                {
                    winnerName = "O";
                }
                else
                {
                    winnerName = "X";
                }
                dR = MessageBox.Show(winnerName + " wins!" + Environment.NewLine + "New game?", "Winner!", MessageBoxButtons.YesNo);
                if (dR == DialogResult.Yes)
                {
                    turn = true;
                    turn_count = 0;

                    try
                    {
                        foreach (Control c in Controls)
                        {
                            Button b = (Button)c;
                            b.Enabled = true;
                            b.Text = "";
                        }
                    }
                    catch
                    {
                        // Don't need to catch anything
                    }
                }
                else if (dR == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            // Displays draw
            else
            {
                if (turn_count == 9)
                {
                    dR = MessageBox.Show("No winner." + Environment.NewLine + "New game?", "Draw", MessageBoxButtons.YesNo);
                    if (dR == DialogResult.Yes)
                    {
                        turn = true;
                        turn_count = 0;

                        try
                        {
                            foreach (Control c in Controls)
                            {
                                Button b = (Button)c;
                                b.Enabled = true;
                                b.Text = "";
                            }
                        }
                        catch
                        {
                            // Don't need to catch anything
                        }
                    }
                    else if (dR == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }
            }

        }

        // Disables buttons after it is clicked
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch 
            { 
                // Don't need to catch anything
            }
        }

        // Gives options to player(s) to restart game
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch
            {
                // Don't need to catch anything
            }
        }
    }
}

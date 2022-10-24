using System.ComponentModel;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        bool activePlayer = true; //true is X, false is O
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Brody", "About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (activePlayer)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            activePlayer = !activePlayer;

            b.Enabled = false;

            turnCount++;

            checkForWinner();
        }

        private void checkForWinner()
        {
            bool thereIsAWinner = false;

            if      ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)) thereIsAWinner = true; //horizontal conditions
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)) thereIsAWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled)) thereIsAWinner = true;

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled)) thereIsAWinner = true; //vertical conditions
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled)) thereIsAWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled)) thereIsAWinner = true;

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled)) thereIsAWinner = true; //diagonal conditions
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled)) thereIsAWinner = true;

            if (thereIsAWinner)
            {
                disableButtons();

                String winner = "";
                if (activePlayer)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }

                MessageBox.Show($"{winner} is the winner.", "Result");
            }//endif
            else
            {
                if (turnCount == 9) MessageBox.Show("Draw", "Result");
            }

        }//end checkForWinner

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//end foreach
            }//end try
            catch { }

        }//end disableButtons

        private void newGameButton_Click(object sender, EventArgs e)
        {
            activePlayer = true;
            turnCount = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }//end foreach
            }//end try
            catch { }
        }

    }//end Form1
}//end TicTacToe
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSimulation
{
    public partial class ATMSimulator : Form
    {
        public ATMSimulator()
        {
            InitializeComponent();

            //button initialisation
            buttonDataRaceSuccess.MouseEnter += OnMouseEnterButtonDataRaceSuccess;
            buttonDataRaceSuccess.MouseLeave += OnMouseLeaveButtonDataRaceSuccess;
        }

        private void OnMouseEnterButtonDataRaceSuccess(object sender, EventArgs e)
        {
            buttonDataRaceSuccess.BackColor = SystemColors.ControlDark;
        }

        private void OnMouseLeaveButtonDataRaceSuccess(object sender, EventArgs e)
        {
            buttonDataRaceSuccess.BackColor = Color.Transparent;
        }

        private void exitProgram_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {

        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {

        }

        private void buttonThree_Click(object sender, EventArgs e)
        {

        }

        private void buttonSix_Click(object sender, EventArgs e)
        {

        }

        private void buttonFive_Click(object sender, EventArgs e)
        {

        }

        private void buttonFour_Click(object sender, EventArgs e)
        {

        }

        private void buttonOne_Click(object sender, EventArgs e)
        {

        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {

        }

        private void buttonEight_Click(object sender, EventArgs e)
        {

        }

        //change the log text
        /*
            //Text box concatinate new log
            //possible string implementation ToString()
            textBoxLogInfo.Text += "String" + Environment.NewLine;
            textBoxLogInfo.SelectionStart = textBoxLogInfo.TextLength;
            textBoxLogInfo.ScrollToCaret();
            */
    }
}

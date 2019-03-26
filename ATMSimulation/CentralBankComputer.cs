using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSimulation
{
    /// <summary>
    /// Class representing the central bank computer.
    /// </summary>
    public partial class CentralBankComputer : Form
    {
        //Fields
        private Account[] ac = new Account[3];
        private Thread ATM1;
        private Thread ATM2;

        /// <summary>
        /// Constructor method for the CentralBankComputer form.
        /// </summary>
        public CentralBankComputer()
        {
            InitializeComponent();
            buttonDataRaceSuccess.MouseEnter += OnMouseEnterButtonDataRaceSuccess;
            buttonDataRaceSuccess.MouseLeave += OnMouseLeaveButtonDataRaceSuccess;
            //account initialisation
            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);

            dataRace = true;
        }

        private void OnMouseEnterButtonDataRaceSuccess(object sender, EventArgs e)
        {
            buttonDataRaceSuccess.BackColor = SystemColors.ControlDark;
        }

        private void OnMouseLeaveButtonDataRaceSuccess(object sender, EventArgs e)
        {
            buttonDataRaceSuccess.BackColor = Color.Transparent;
        }

        private void buttonDataRaceFail_Click(object sender, EventArgs e)
        {
            ATM1 = new Thread(new ThreadStart(atmThread));
            ATM2 = new Thread(new ThreadStart(atmThread));
            ATM1.Start();
            ATM2.Start();
        }

        private void buttonDataRaceSuccess_Click(object sender, EventArgs e)
        {
            ATM1 = new Thread(new ThreadStart(atmThread));
            ATM2 = new Thread(new ThreadStart(atmThread));
            ATM1.Start();
            ATM2.Start();
        }

        private void atmThread()
        {
            ATMSimulator form = new ATMSimulator(ac);
            form.ShowDialog();
        }
    }
}

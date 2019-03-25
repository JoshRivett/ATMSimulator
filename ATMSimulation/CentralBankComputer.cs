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
    public partial class CentralBankComputer : Form
    {

        private Account[] ac = new Account[3];
        private ATM atm;

        public CentralBankComputer()
        {
            InitializeComponent();
            buttonDataRaceSuccess.MouseEnter += OnMouseEnterButtonDataRaceSuccess;
            buttonDataRaceSuccess.MouseLeave += OnMouseLeaveButtonDataRaceSuccess;
            //account initialisation
            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);

            atm = new ATM(ac);
        }

        private void OnMouseEnterButtonDataRaceSuccess(object sender, EventArgs e)
        {
            buttonDataRaceSuccess.BackColor = SystemColors.ControlDark;
        }

        private void OnMouseLeaveButtonDataRaceSuccess(object sender, EventArgs e)
        {
            buttonDataRaceSuccess.BackColor = Color.Transparent;
        }
    }
}

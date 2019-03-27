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
        private bool dataRace;
        private const int ATMNUM_1 = 1;
        private const int ATMNUM_2 = 2;
        public static Barrier barrier = new Barrier(participantCount: 2);
        public static bool barrierEnabled = true;
        public static Semaphore semaphore = new Semaphore(1, 1);

        /// <summary>
        /// Constructor method for the CentralBankComputer form.
        /// </summary>
        public CentralBankComputer()
        {
            InitializeComponent();
            buttonDataRaceSuccess.MouseEnter += OnMouseEnterButtonDataRaceSuccess;
            buttonDataRaceSuccess.MouseLeave += OnMouseLeaveButtonDataRaceSuccess;
            //account initialisation
            initialiseAccounts();
            dataRace = true;
        }

        /// <summary>
        /// Initialises the accounts to their default values.
        /// </summary>
        public void initialiseAccounts()
        {
            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);
        }

        /// <summary>
        /// Event handler for moving the mouse on to the data race success button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseEnterButtonDataRaceSuccess(object sender, EventArgs e)
        {
            buttonDataRaceSuccess.BackColor = SystemColors.ControlDark;
        }

        /// <summary>
        /// Event handler for moving the mouse off of the data race success button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseLeaveButtonDataRaceSuccess(object sender, EventArgs e)
        {
            buttonDataRaceSuccess.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Event handler for the data race fail button.
        /// Runs the program with the intention of causing the race condition.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDataRaceFail_Click(object sender, EventArgs e)
        {
            //Makes sure either form/thread has not already been started.
            if (ATM1 == null && ATM2 == null)
            {
                dataRace = true;

                ATM1 = new Thread(new ThreadStart(atmThread1));
                ATM2 = new Thread(new ThreadStart(atmThread2));
                ATM1.Start();
                ATM2.Start();
            }
        }

        /// <summary>
        /// Event handler for the data race success button.
        /// Runs the program with the intention of preventing the race condition.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDataRaceSuccess_Click(object sender, EventArgs e)
        {
            //Makes sure either form/thread has not already been started.
            if (ATM1 == null && ATM2 == null)
            {
                dataRace = false;

                ATM1 = new Thread(new ThreadStart(atmThread1));
                ATM2 = new Thread(new ThreadStart(atmThread2));
                ATM1.Start();
                ATM2.Start();
            }
        }

        /// <summary>
        /// Method which creates the first ATM form to be run in a thread of its own.
        /// </summary>
        private void atmThread1()
        {
            ATMSimulator form = new ATMSimulator(ac, ATMNUM_1, dataRace);
            form.ShowDialog();
        }

        /// <summary>
        /// Method which creates the second ATM form to be run in a thread of its own.
        /// </summary>
        private void atmThread2()
        {
            ATMSimulator form = new ATMSimulator(ac, ATMNUM_2, dataRace);
            form.ShowDialog();
        }

        /// <summary>
        /// Event handler for the reset simulation button.
        /// Resets the accounts back to their default values and closes the ATM forms.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResetSimulation_Click(object sender, EventArgs e)
        {
            initialiseAccounts();

            //Makes sure the forms/threads have already been started.
            if (ATM1 != null && ATM2 != null)
            {
                ATM1.Abort();
                ATM2.Abort();
            }
        }

        /// <summary>
        /// Event handler for the barrier checkbox.
        /// Toggles whether or not the barrier is enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxBarrier_CheckedChanged(object sender, EventArgs e)
        {
            barrierEnabled = checkBoxBarrier.Checked;

            //If the barrier is enabled, bring the participant count back up to 2
            if (barrierEnabled)
            {
                barrier.AddParticipant();
            }
            //Otherwise, bring the participant count down to 1
            else
            {
                barrier.RemoveParticipant();
            }
        }
    }
}

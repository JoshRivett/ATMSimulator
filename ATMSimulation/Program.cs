using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CentralBankComputer mainComputer = new CentralBankComputer();
            //ATMSimulator ATM1 = new ATMSimulator();
            //ATMSimulator ATM2 = new ATMSimulator();
            
            Application.Run(mainComputer);
            //Application.Run(ATM1);
            //Application.Run(ATM2);
        }
    }
}

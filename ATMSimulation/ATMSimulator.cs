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
            CentralBankComputer bank = new CentralBankComputer();
            //button initialisation
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

    /// <summary>
    /// Class representing a bank account.
    /// </summary>
    class Account
    {
        //the attributes for the account
        private int balance;
        private int pin;
        private int accountNum;

        // a constructor that takes initial values for each of the attributes (balance, pin, accountNumber)
        public Account(int balance, int pin, int accountNum)
        {
            this.balance = balance;
            this.pin = pin;
            this.accountNum = accountNum;
        }

        //getter and setter functions for balance
        public int getBalance()
        {
            return balance;
        }
        public void setBalance(int newBalance)
        {
            this.balance = newBalance;
        }

        /// <summary>
        /// Withdraws an amount of money specified by parameter.
        /// </summary>
        /// <param name="amount">The amount of money to be withdrawn</param>
        /// <returns>Returns true if successful, false if not</returns>
        public Boolean decrementBalance(int amount)
        {
            if (this.balance > amount)
            {
                //Semaphore here?
                balance -= amount;
                //Release semaphore here.
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This function checks the account pin against the argument passed to it.
        /// </summary>
        /// <param name="pinEntered"></param>
        /// <returns>True if they match, false if they do not</returns>
        public Boolean checkPin(int pinEntered)
        {
            if (pinEntered == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Getter method for the account number.
        /// </summary>
        /// <returns>The account number</returns>
        public int getAccountNum()
        {
            return accountNum;
        }

    }

    /// <summary>
    /// Class representing an ATM.
    /// </summary>
    class ATM
    {
        //local referance to the array of accounts
        private Account[] ac;

        //this is a referance to the account that is being used
        private Account activeAccount = null;

        /// <summary>
        /// The atm constructor takes an array of account objects as a reference.
        /// </summary>
        /// <param name="ac">The reference to an array of account objects</param>
        public ATM(Account[] ac)
        {
            this.ac = ac;
            Console.WriteLine("hello from ATM");

            /*
            // an infanite loop to keep the flow of controll going on and on 
            while (true)
            {

                //ask for account number and store result in acctiveAccount (null if no match found)
                activeAccount = this.findAccount();

                if (activeAccount != null)
                {

                    //if the account is found check the pin 
                    if (activeAccount.checkPin(this.promptForPin()))
                    {
                        //if the pin is a match give the options to do stuff to the account (take money out, view balance, exit)
                        dispOptions();
                    }

                }
                else
                {   //if the account number entered is not found let the user know!
                    //Console.WriteLine("no matching account found.");
                }

                //wipes all text from the console
                //Console.Clear();
            }
            */

        }

        /// <summary>
        /// Prompts the user for an account number and then searches for it.
        /// </summary>
        /// <returns>Returns the corresponding account if it exists, otherwise returns null</returns>
        private Account findAccount()
        {
            Console.WriteLine("enter your account number..");
            
            int input = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < this.ac.Length; i++)
            {
                if (ac[i].getAccountNum() == input)
                {
                    return ac[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Prompts the user for a pin and converts it to an integer.
        /// </summary>
        /// <returns>The parsed integer</returns>
        private int promptForPin()
        {
            Console.WriteLine("enter pin:");
            String str = Console.ReadLine();
            int pinNumEntered = Convert.ToInt32(str);
            return pinNumEntered;
        }

        /*
         * 
         *  give the use the options to do with the accoutn
         *  
         *  promt for input
         *  and defer to appropriate method based on input
         *  
         */
        /// <summary>
        /// Displays menu options, prompts the user for an option, and executes the 
        /// corresponding method.
        /// </summary>
        private void dispOptions()
        {
            Console.WriteLine("1> take out cash");
            Console.WriteLine("2> balance");
            Console.WriteLine("3> exsit");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                dispWithdraw();
            }
            else if (input == 2)
            {
                dispBalance();
            }
            else if (input == 3)
            {


            }
            else
            {

            }

        }


        /*
         * 
         * offer withdrawable amounts
         * 
         * based on input attempt to withraw the corosponding amount of money
         * 
         * */
        public void dispWithdraw()
        {
            Console.WriteLine("1> 10");
            Console.WriteLine("2> 50");
            Console.WriteLine("3> 500");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input > 0 && input < 4)
            {

                //opiton one is entered by the user
                if (input == 1)
                {

                    //attempt to decrement account by 10 punds
                    if (activeAccount.decrementBalance(10))
                    {
                        //if this is possible display new balance and await key press
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        //if this is not possible inform user and await key press
                        Console.WriteLine("insufficent funds");
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
                else if (input == 2)
                {
                    if (activeAccount.decrementBalance(50))
                    {
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("insufficent funds");
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
                else if (input == 3)
                {
                    if (activeAccount.decrementBalance(500))
                    {
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("insufficent funds");
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
            }
        }


        /*
         *  display balance of activeAccount and await keypress
         *  
         */
        private void dispBalance()
        {
            if (this.activeAccount != null)
            {
                Console.WriteLine(" your current balance is : " + activeAccount.getBalance());
                Console.WriteLine(" (prese enter to continue)");
                Console.ReadLine();
            }
        }
    }
}

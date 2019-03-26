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
    /// <summary>
    /// Class representing an ATM form.
    /// </summary>
    public partial class ATMSimulator : Form
    {
        //Fields
        private ATM atm;
        private Button[] keyPad = new Button[10];
        private Account[] ac;
        private string state = "";

        /// <summary>
        /// Constructor method for the ATMSimulator form.
        /// </summary>
        public ATMSimulator(Account[] ac)
        {
            InitializeComponent();
            this.ac = ac;
            atm = new ATM(ac);

            state = "account select";

            //CentralBankComputer bank = new CentralBankComputer();
            //button initialisation

            /*
            for (int i = 0; i < 10; i++)
            {
                keyPad[i] = new Button();
                keyPad[i].Size = new Size(46, 41);
                keyPad[i].Text = i.ToString();

                if (i == 0)
                {
                    keyPad[i].Location = new Point(196, 411);
                    Controls.Add(keyPad[i]);
                }
                
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++) {
                        keyPad[i].Location = new Point(248 - 52*k, 366 - 45*j);
                        Controls.Add(keyPad[i]);
                        keyPad[i].BringToFront();
                    }
                }
            }
            */

        }

        private void exitProgram_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonZero.Text;
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonNine.Text;
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonTwo.Text;
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonThree.Text;
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonSix.Text;
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonFive.Text;
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonFour.Text;
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonOne.Text;
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonSeven.Text;
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonEight.Text;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxUserInput.Text.Length > 0)
            {
                textBoxUserInput.Text = textBoxUserInput.Text.Remove(textBoxUserInput.Text.Length - 1);
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (textBoxUserInput.Text != "")
            {
                if (state == "account select")
                {
                    atm.setActiveAccount(atm.findAccount(textBoxUserInput.Text));

                    if (atm.getActiveAccount() != null)
                    {
                        textBoxUserPrompt.Text = "Login to " + atm.getActiveAccount().getAccountNum().ToString();
                        state = "pin entry";
                    }

                }
                else if (state == "pin entry")
                {
                    if (atm.getActiveAccount().checkPin(Convert.ToInt32(textBoxUserInput.Text)) == true)
                    {
                        state = "main menu";
                        dispOptions();
                    }
                    else
                    {
                        textBoxUserPrompt.Text = "Incorrect pin code";
                    }
                }
                else if (state == "main menu")
                {
                    switch (Convert.ToInt32(textBoxUserInput.Text))
                    {
                        case 1:
                            withdrawCash();
                            break;
                        case 2:
                            displayBalance();
                            break;
                        case 3:
                            logOut();
                            break;
                    }
                }
            }
            textBoxUserInput.Text = "";
        }

        /// <summary>
        /// Displays menu options, prompts the user for an option, and executes the 
        /// corresponding method.
        /// </summary>
        public void dispOptions()
        {
            textBoxUserPrompt.Text = "1> take out cash" + Environment.NewLine + "2> balance" + Environment.NewLine + "3> exit";

            /*
            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                atm.dispWithdraw();
            }
            else if (input == 2)
            {
                atm.dispBalance();
            }
            else if (input == 3)
            {


            }
            else
            {

            }
            */
        }

        public void withdrawCash()
        {

        }

        public void displayBalance()
        {

        }

        public void logOut()
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
    public class Account
    {
        //the attributes for the account
        private int balance;
        private int pin;
        private int accountNum;

        /// <summary>
        /// Constructor method for accounts.
        /// </summary>
        /// <param name="balance">The initial balance of the account</param>
        /// <param name="pin">The pin code for the account</param>
        /// <param name="accountNum">The account's ID number</param>
        public Account(int balance, int pin, int accountNum)
        {
            this.balance = balance;
            this.pin = pin;
            this.accountNum = accountNum;
        }

        /// <summary>
        /// Getter method for the account's balance.
        /// </summary>
        /// <returns>The amount of money in the bank account's balance</returns>
        public int getBalance()
        {
            return balance;
        }

        /// <summary>
        /// Setter method for the account's balance.
        /// </summary>
        /// <param name="newBalance">The new amount of money to set the balance to</param>
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
        /// The ATM constructor takes an array of account objects as a reference.
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
        /// Setter method for setting the active account.
        /// </summary>
        /// <param name="ac">The account to be set as active</param>
        public void setActiveAccount(Account ac)
        {
            activeAccount = ac;
        }

        public Account getActiveAccount()
        {
            return activeAccount;
        }

        /// <summary>
        /// Prompts the user for an account number and then searches for it.
        /// </summary>
        /// <returns>Returns the corresponding account if it exists, otherwise returns null</returns>
        public Account findAccount(string input)
        {
            Console.WriteLine("enter your account number..");
            
            int accountNum = Convert.ToInt32(input);

            for (int i = 0; i < this.ac.Length; i++)
            {
                if (ac[i].getAccountNum() == accountNum)
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
        public int promptForPin()
        {
            //textBoxUserPrompt.Text = "Enter Pin:";
            String str = Console.ReadLine();
            int pinNumEntered = Convert.ToInt32(str);
            return pinNumEntered;
        }

        /// <summary>
        /// Displays options for withdrawing money, receives input from the user,
        /// then executes the appropriate method if the account has enough money.
        /// </summary>
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

        /// <summary>
        /// Displays the balance of the current account.
        /// </summary>
        public void dispBalance()
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

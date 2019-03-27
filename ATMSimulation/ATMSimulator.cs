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
    /// Class representing an ATM form.
    /// </summary>
    public partial class ATMSimulator : Form
    {
        //Fields
        private ATM atm;
        private Account[] ac;
        private string state = "";
        private bool dataRace;
        //private Button[] keyPad = new Button[10];

        /// <summary>
        /// Constructor method for the ATMSimulator form.
        /// </summary>
        public ATMSimulator(Account[] ac, int ATMNum, Boolean dataRace)
        {
            InitializeComponent();

            //Initialises fields
            this.ac = ac;
            atm = new ATM(ac);
            state = "account select";
            this.dataRace = dataRace;

            //Initialises form elements
            textBoxPageTitle.Text = "ATM";
            textBoxUserPromptLeft.Text = "Enter account number:";
            richTextBox3.Text = "ATM Simulator " + ATMNum;
            richTextBox6.Text = "ATM " + ATMNum + " Activity Log:";

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

        /// <summary>
        /// Event handler for the exit program button.
        /// Ends the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitProgram_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// Event handler for button zero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonZero_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonZero.Text;
        }

        /// <summary>
        /// Event handler for button one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOne_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonOne.Text;
        }

        /// <summary>
        /// Event handler for button two.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTwo_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonTwo.Text;
        }

        /// <summary>
        /// Event handler for button three.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonThree_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonThree.Text;
        }

        /// <summary>
        /// Event handler for button four.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFour_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonFour.Text;
        }

        /// <summary>
        /// Event handler for button five.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFive_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonFive.Text;
        }

        /// <summary>
        /// Event handler for button six.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSix_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonSix.Text;
        }

        /// <summary>
        /// Event handler for button seven.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSeven_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonSeven.Text;
        }

        /// <summary>
        /// Event handler for button eight.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEight_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonEight.Text;
        }

        /// <summary>
        /// Event handler for button nine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNine_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text += buttonNine.Text;
        }

        /// <summary>
        /// Event handler for the clear button.
        /// Clears the user input box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxUserInput.Text = "";
        }

        /// <summary>
        /// Event handler for the delete button.
        /// Deletes the last character from the user input box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //Makes sure the text box isn't empty
            if (textBoxUserInput.Text.Length > 0)
            {
                textBoxUserInput.Text = textBoxUserInput.Text.Remove(textBoxUserInput.Text.Length - 1);
            }
        }

        /// <summary>
        /// Event handler for the enter button.
        /// Reacts differently depending on the state of the program, creating the main control flow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            //Makes sure that a value has been entered (or the program is expecting enter to be pressed)
            if (textBoxUserInput.Text != "" || state == "other")
            {
                //Checks if the program is on the account selection screen
                if (state == "account select")
                {
                    //Attempts to find the entered account number
                    atm.setActiveAccount(atm.findAccount(textBoxUserInput.Text));

                    //If account was found, the program moves on to pin entry
                    if (atm.getActiveAccount() != null)
                    {
                        textBoxUserPromptLeft.Clear();
                        textBoxUserPromptRight.Clear();

                        textBoxPageTitle.Clear();
                        textBoxPageTitle.Text = "ATM";

                        textBoxUserPromptLeft.Text = "Login to " + atm.getActiveAccount().getAccountNum().ToString();
                        state = "pin entry";
                    }

                }
                //Checks if the program is on the pin entry screen
                else if (state == "pin entry")
                {
                    //If the correct pin was entered, the program switches to the main menu
                    if (atm.getActiveAccount().checkPin(Convert.ToInt32(textBoxUserInput.Text)) == true)
                    {
                        dispOptions();
                    }
                    //Otherwise, the user is prompted to try again
                    else
                    {
                        textBoxUserPromptLeft.Text = "Incorrect pin code";
                    }
                }
                //Checks if the program is on the main menu screen
                else if (state == "main menu")
                {
                    //Executes the method corresponding to the user's input
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
                //Checks if the program is on the withdraw menu
                else if (state == "withdraw menu")
                {
                    //Attempts to withdraw cash based on the user's input
                    int amount = 0;
                    switch (Convert.ToInt32(textBoxUserInput.Text))
                    {
                        case 1:
                            amount = 10;
                            break;
                        case 2:
                            amount = 50;
                            break;
                        case 3:
                            amount = 500;
                            break;
                    }

                    //If the withdrawal was successful, the amount taken out is printed to the screen
                    if (atm.getActiveAccount().decrementBalance(amount, dataRace) == true)
                    {
                        textBoxUserPromptLeft.Clear();
                        textBoxUserPromptRight.Clear();

                        textBoxPageTitle.Clear();
                        textBoxPageTitle.Text = "ATM";

                        textBoxUserPromptLeft.Text = "£" + amount.ToString() + " successfully withdrawn." + Environment.NewLine;
                        textBoxUserPromptRight.Text = "Press enter to continue...";
                    }
                    //Otherwise, and error message is displayed
                    else
                    {
                        textBoxPageTitle.Clear();
                        textBoxPageTitle.Text = "ATM";

                        textBoxUserPromptLeft.Text = "Insufficient funds." + Environment.NewLine;
                        textBoxUserPromptRight.Text = "Press enter to continue...";
                    }
                    state = "other";
                }
                //Checks if the program is waiting for the user to press enter
                else if (state == "other")
                {
                    //Returns to the main menu
                    dispOptions();
                }
                //Otherwise, a state has not been accounted for and a debug message is displayed
                else
                {

                    textBoxUserPromptLeft.Clear();
                    textBoxUserPromptRight.Clear();

                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptRight.Text = "Missing state: " + state;
                }
            }
            //Clears the input box
            textBoxUserInput.Text = "";
        }

        /// <summary>
        /// Displays the main menu options.
        /// </summary>
        public void dispOptions()
        {
            textBoxPageTitle.Clear();
            textBoxPageTitle.Text = "ATM";

            textBoxUserPromptLeft.Clear();
            textBoxUserPromptRight.Clear();
            textBoxUserPromptLeft.Text += "< Withdraw" + Environment.NewLine;
            textBoxUserPromptLeft.Text += " " + Environment.NewLine;
            textBoxUserPromptLeft.Text += "< Deposit" + Environment.NewLine;

            textBoxUserPromptRight.Text += "< View Balance" + Environment.NewLine;
            textBoxUserPromptRight.Text += " " + Environment.NewLine;
            textBoxUserPromptRight.Text += "< Transfer Money" + Environment.NewLine;
            textBoxUserPromptRight.Text += " " + Environment.NewLine;
            textBoxUserPromptRight.Text += "< Switch Account" + Environment.NewLine;

            state = "main menu";
        }

        /// <summary>
        /// Prompts the user to select an amount of cash to withdraw, then presents menu options.
        /// </summary>
        public void withdrawCash()
        {
            textBoxPageTitle.Clear();
            textBoxPageTitle.Text = "Select Amount:";

            textBoxUserPromptLeft.Clear();
            textBoxUserPromptRight.Clear();
            textBoxUserPromptLeft.Text += "< £10" + Environment.NewLine; //wihtdraw button
            textBoxUserPromptLeft.Text += " " + Environment.NewLine;
            textBoxUserPromptLeft.Text += "< £30" + Environment.NewLine; //deposit button

            textBoxUserPromptRight.Text += "< £20" + Environment.NewLine; //view balance button
            textBoxUserPromptRight.Text += " " + Environment.NewLine;
            textBoxUserPromptRight.Text += "< £40" + Environment.NewLine; //transfer button
            textBoxUserPromptRight.Text += " " + Environment.NewLine;
            textBoxUserPromptRight.Text += "< £50" + Environment.NewLine; //switch account button

            this.state = "withdraw menu";

            /*
            textBoxUserPromptRight.Text =    "1> 10" + Environment.NewLine +
                                        "2> 50" + Environment.NewLine +
                                        "3> 500" + Environment.NewLine;

            */
        }

        public void depositCash()
        {

            textBoxPageTitle.Clear();
            textBoxPageTitle.Text = "Select Amount:";

            textBoxUserPromptLeft.Clear();
            textBoxUserPromptRight.Clear();
            textBoxUserPromptLeft.Text += "< £10" + Environment.NewLine; //wihtdraw button
            textBoxUserPromptLeft.Text += " " + Environment.NewLine;
            textBoxUserPromptLeft.Text += "< £30" + Environment.NewLine; //deposit button

            textBoxUserPromptRight.Text += "< £20" + Environment.NewLine; //view balance button
            textBoxUserPromptRight.Text += " " + Environment.NewLine;
            textBoxUserPromptRight.Text += "< £40" + Environment.NewLine; //transfer button
            textBoxUserPromptRight.Text += " " + Environment.NewLine;
            textBoxUserPromptRight.Text += "< £50" + Environment.NewLine; //switch account button

            this.state = "deposit menu";

            /*
            textBoxUserPromptRight.Text =    "1> 10" + Environment.NewLine +
                                        "2> 50" + Environment.NewLine +
                                        "3> 500" + Environment.NewLine;

            */
        }

        /// <summary>
        /// Displays the current balance of the active account and then waits for the user to press enter.
        /// </summary>
        public void displayBalance()
        {
            textBoxPageTitle.Clear();
            textBoxPageTitle.Text = "ATM";

            textBoxUserPromptLeft.Clear();
            textBoxUserPromptRight.Clear();
            textBoxUserPromptLeft.Text += "Current balance: " + atm.getActiveAccount().getBalance().ToString() + Environment.NewLine;
            textBoxUserPromptLeft.Text += " " + Environment.NewLine;
            textBoxUserPromptRight.Text += "Press enter to continue..." + Environment.NewLine;

            state = "other";

            /*
            textBoxUserPromptRight.Text =    "Current balance: " + atm.getActiveAccount().getBalance().ToString() + Environment.NewLine +
                                        "Press enter to continue...";
            */
        }

        /// <summary>
        /// Returns to the initial login screen.
        /// </summary>
        public void logOut()
        {
            state = "account select";

            textBoxPageTitle.Clear();
            textBoxPageTitle.Text = "ATM";

            textBoxUserPromptLeft.Clear();
            textBoxUserPromptRight.Clear();
            textBoxUserPromptRight.Text = "Enter account number:";
        }

        /// <summary>
        /// Displays options for transferring cash to another account.
        /// </summary>
        public void transferMoney()
        {
            state = "transfer money";

            textBoxPageTitle.Clear();
            textBoxPageTitle.Text = "Select Amount:";

            textBoxUserPromptLeft.Clear();
            textBoxUserPromptRight.Clear();
            textBoxUserPromptLeft.Text += "< £10" + Environment.NewLine; //wihtdraw button
            textBoxUserPromptLeft.Text += " " + Environment.NewLine;
            textBoxUserPromptLeft.Text += "< £30" + Environment.NewLine; //deposit button

            textBoxUserPromptRight.Text += "< £20" + Environment.NewLine; //withdraw button
            textBoxUserPromptRight.Text += " " + Environment.NewLine;
            textBoxUserPromptRight.Text += "< £40" + Environment.NewLine; //transfer button
            textBoxUserPromptRight.Text += " " + Environment.NewLine;
            textBoxUserPromptRight.Text += "< £50" + Environment.NewLine; //switch account button
        }

        /// <summary>
        /// Adds information to the log based on the parameter given.
        /// </summary>
        /// <param name="updateInfo">Information to be added to the log.</param>
        public void updateLog(string updateInfo)
        {
            //Text box concatenate new log
            textBoxLogInfo.Text += updateInfo + Environment.NewLine;
            textBoxLogInfo.SelectionStart = textBoxLogInfo.TextLength;
            textBoxLogInfo.ScrollToCaret();
        }

        //takes string, replaces existing string with new string
        public void updateTextBoxUserPromptLeft(string newText)
        {
            textBoxUserPromptLeft.Text = newText;

        }

        //takes string, replaces existing string with new string
        public void updateTextBoxUserPromptRight(string newText)
        {
            textBoxUserPromptRight.Text = newText;

        }

        //takes string, replaces existing string with new string
        public void updateTextBoxPageTitle(string newText)
        {
            textBoxPageTitle.Text = newText;

        }


        private void textBoxUserPromptLeft_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonWithdrawCash_Click(object sender, EventArgs e)
        {
            //updates log
            textBoxLogInfo.Text += this.Name.ToString() + "Account holder chose Withdraw Option" + Environment.NewLine;

            if (this.state == "deposit menu")
            {
                if (atm.getActiveAccount().decrementBalance(-10, dataRace) == true)
                {
                    textBoxUserPromptLeft.Clear();
                    textBoxUserPromptRight.Clear();

                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "£10" + " successfully deposited." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
                else
                {
                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "Insufficient funds." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
            }
            else if (this.state == "withdraw menu")
            {
                if (atm.getActiveAccount().decrementBalance(10, dataRace) == true)
                {
                    textBoxUserPromptLeft.Clear();
                    textBoxUserPromptRight.Clear();

                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "£10" + " successfully withdrawn." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
                else
                {
                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "Insufficient funds." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
            }
            else if (state == "main menu")
            {
                withdrawCash();
            }
            else if (state == "other")
            {
                state = "main menu";
                dispOptions();
            }

        }

        private void buttonViewBalance_Click(object sender, EventArgs e)
        {
            //updates log
            textBoxLogInfo.Text += this.Name.ToString() + "Account holder viewed balance" + Environment.NewLine;

            if (state == "deposit menu")
            {
                if (atm.getActiveAccount().decrementBalance(-20, dataRace) == true)
                {
                    textBoxUserPromptLeft.Clear();
                    textBoxUserPromptRight.Clear();

                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "£20" + " successfully deposited." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
                else
                {
                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "Insufficient funds." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
            }
            else if (state == "withdraw menu")
            {
                if (atm.getActiveAccount().decrementBalance(20, dataRace) == true)
                {
                    textBoxUserPromptLeft.Clear();
                    textBoxUserPromptRight.Clear();

                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "£20" + " successfully withdrawn." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
                else
                {
                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "Insufficient funds." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
            }
            else if (state == "main menu")
            {
                displayBalance();
                state = "other";
            }else if (state == "other")
            {
                state = "main menu";
                dispOptions();
            }
        }

        private void buttonDepositMoney_Click(object sender, EventArgs e)
        {
            //updates log
            textBoxLogInfo.Text += this.Name.ToString() + "Account Holder has chosen to deposit Money." + Environment.NewLine;
            if (this.state == "deposit menu")
            {
                if (atm.getActiveAccount().decrementBalance(-30, dataRace) == true)
                {
                    textBoxUserPromptLeft.Clear();
                    textBoxUserPromptRight.Clear();

                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "£30" + " successfully deposited." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
                else
                {
                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "Insufficient funds." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
            }else if (this.state == "withdraw menu")
            {
                if (atm.getActiveAccount().decrementBalance(30, dataRace) == true)
                {
                    textBoxUserPromptLeft.Clear();
                    textBoxUserPromptRight.Clear();

                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "£30" + " successfully withdrawn." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
                else
                {
                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "Insufficient funds." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
            }
            else if (state == "main menu")
            {
                depositCash();
            }

            if (state == "other")
            {
                state = "main menu";
                dispOptions();
            }
        }

        private void buttonTransferMoney_Click(object sender, EventArgs e)
        {
            //updates log
            textBoxLogInfo.Text += this.Name.ToString() + "Account holder has chosen the transfer money option." + Environment.NewLine;

            if (this.state == "deposit menu")
            {
                if (atm.getActiveAccount().decrementBalance(-40, dataRace) == true)
                {
                    textBoxUserPromptLeft.Clear();
                    textBoxUserPromptRight.Clear();

                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "£40" + " successfully deposited." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
                else
                {
                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "Insufficient funds." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
            }
            else if (this.state == "withdraw menu")
            {
                if (atm.getActiveAccount().decrementBalance(40, dataRace) == true)
                {
                    textBoxUserPromptLeft.Clear();
                    textBoxUserPromptRight.Clear();

                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "£40" + " successfully withdrawn." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
                else
                {
                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "Insufficient funds." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
            }
            else if (state == "main menu")
            {
                transferMoney();
            }else if (state == "other")
            {
                state = "main menu";
                dispOptions();
            }
        }

        private void buttonSwitchAccount_Click(object sender, EventArgs e)
        {
            //updates log
            textBoxLogInfo.Text += this.Name.ToString() + "Account Holder has chosen to switch accounts." + Environment.NewLine;

            if (this.state == "deposit menu")
            {
                if (atm.getActiveAccount().decrementBalance(-50, dataRace) == true)
                {
                    textBoxUserPromptLeft.Clear();
                    textBoxUserPromptRight.Clear();

                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "£50" + " successfully deposited." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
                else
                {
                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "Insufficient funds." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
            }
            else if (this.state == "withdraw menu")
            {
                if (atm.getActiveAccount().decrementBalance(50, dataRace) == true)
                {
                    textBoxUserPromptLeft.Clear();
                    textBoxUserPromptRight.Clear();

                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "£50" + " successfully withdrawn." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
                else
                {
                    textBoxPageTitle.Clear();
                    textBoxPageTitle.Text = "ATM";

                    textBoxUserPromptLeft.Text = "Insufficient funds." + Environment.NewLine;
                    textBoxUserPromptRight.Text = "Press enter to continue...";
                    state = "other";
                }
            }
            else if (state == "main menu")
            {
                logOut();
                state = "other";
            }
            else if (state == "other")
            {
                state = "main menu";
                dispOptions();
            }
        }
    }

    /// <summary>
    /// Class representing a bank account.
    /// </summary>
    public class Account
    {
        //Fields
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
        public Boolean decrementBalance(int amount, bool dataRace)
        {
            //Checks if the data race is to be solved
            if (dataRace == false)
            {
                if (this.balance > amount)
                {
                    int temp;

                    CentralBankComputer.barrier.SignalAndWait();

                    CentralBankComputer.semaphore.WaitOne();
                    temp = balance;
                    temp -= amount;
                    balance = temp;
                    CentralBankComputer.semaphore.Release();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //Otherwise, cause the data race to occur
            else
            {
                if (this.balance > amount)
                {
                    int temp;
                    temp = balance;
                    temp -= amount;
                    CentralBankComputer.barrier.SignalAndWait();
                    balance = temp;
                    return true;
                }
                else
                {
                    return false;
                }
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
        //Local reference to the array of accounts
        private Account[] ac;

        //This is a referance to the account that is being used
        private Account activeAccount = null;

        /// <summary>
        /// The ATM constructor takes an array of account objects as a reference.
        /// </summary>
        /// <param name="ac">The reference to an array of account objects</param>
        public ATM(Account[] ac)
        {
            this.ac = ac;
        }

        /// <summary>
        /// Setter method for setting the active account.
        /// </summary>
        /// <param name="ac">The account to be set as active</param>
        public void setActiveAccount(Account ac)
        {
            activeAccount = ac;
        }

        /// <summary>
        /// Getter method for getting the current active account.
        /// </summary>
        /// <returns>The current active account</returns>
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
            int accountNum = Convert.ToInt32(input);

            //Loops through each account and checks if its account number matches the one entered by the user
            for (int i = 0; i < this.ac.Length; i++)
            {
                if (ac[i].getAccountNum() == accountNum)
                {
                    return ac[i];
                }
            }
            
            //Otherwise, the account doesn't exist and null is returned
            return null;
        }
    }
}

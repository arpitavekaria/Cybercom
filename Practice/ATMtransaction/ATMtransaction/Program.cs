using System;

namespace ATMtransaction
{
    class Program
    {
        public static void Main(string[] args) 
        {
            try
            {
                int totalamount, withdrawlimit, deposit, withdraw;
                int definepin = 1234, pin, newpin, choice;
                double mobileno;
                string name;

                #region user

                //user's information
                Console.WriteLine("Enter Your Name:");
                name = Console.ReadLine();

                Console.WriteLine("Enter Your MobileNo:");
                mobileno = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter Your Pin Number:");
                pin = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Your Total Balance:");
                totalamount = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Your withdraw-limit:");
                withdrawlimit = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("welcome {0}!!!", name);
                #endregion user

                //checking user entered pin with predefine pin
                if (pin == definepin)
                {
                    #region transaction
                    while (true)
                    {
                        Console.WriteLine("----------------Welcome to ATM Service---------------");
                        Console.WriteLine("1. Check Balance");
                        Console.WriteLine("2. Cash withdrawal");
                        Console.WriteLine("3. Cash deposition");
                        Console.WriteLine("4. Want To change the pin");
                        Console.WriteLine("5. Quit");

                        Console.WriteLine("*-----------------------------------------\n\n");

                        Console.WriteLine("Enter your choice: ");
                        choice = Convert.ToInt32(Console.ReadLine());

                        //choice for any operation
                        switch (choice)
                        {
                            #region cases
                            //---------------------------Check Balance------------------------
                            case 1:
                                Console.WriteLine(" Your Balance is Rs : {0} :", totalamount);
                                break;

                            //-------------------------- Cash withdrawal-----------------------
                            case 2:
                                Console.WriteLine(" Enter The Amount To Withdraw: ");
                                withdraw = Convert.ToInt32(Console.ReadLine());
                                if (withdraw >= withdrawlimit)
                                {
                                    if (withdraw % 100 != 0)
                                    {
                                        Console.WriteLine("Please Enter The Amount In Multiple Of 100");
                                    }
                                    else if (withdraw > totalamount)
                                    {
                                        Console.WriteLine(" Insufficent Balance");
                                    }
                                    else
                                    {
                                        totalamount = totalamount - withdraw;
                                        Console.WriteLine(" Please Collect Cash {0}:", withdraw);
                                        Console.WriteLine(" Your Current balance is {0}:", totalamount);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("withdraw-limit is not satisfied");
                                }
                                break;

                            //------------------------------- Cash deposition--------------------------
                            case 3:
                                Console.WriteLine("Enter the Amount to Deposite:");
                                deposit = Convert.ToInt32(Console.ReadLine());
                                totalamount = totalamount + deposit;
                                Console.WriteLine("Your Balance is Rs {0}", totalamount);
                                break;

                            //---------------------------Want To change the pin----------------------------
                            case 4:
                                Console.WriteLine("Want to change your pin");
                                Console.WriteLine("Enter your previous pin:");
                                int prepin = Convert.ToInt32(Console.ReadLine());

                                if (prepin == definepin)
                                {
                                    Console.WriteLine("Enter your new pin:");
                                    newpin = Convert.ToInt32(Console.ReadLine());
                                    pin = newpin;
                                    Console.WriteLine("Your pin is changed");
                                }
                                else
                                { 
                                    Console.WriteLine("Enter correct pin");
                                }
                                break;

                            //--------------------------------Quit-------------------------------------------
                            case 5:
                                Console.WriteLine("Thank You For using ATM");
                                break;
                                #endregion cases
                        }
                    }
                    #endregion transaction
                }
                else
                {
                    Console.WriteLine("Invalid Pin Number");
                }
                Console.WriteLine("Thank You For using ATM");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

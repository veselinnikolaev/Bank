using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        public static void Main(string[] args)
        {
            Bank bank = new Bank();
            try
            {

                Console.WriteLine("Welcome to inWest Bank!");
                Console.WriteLine("====================================================================================================");
                Console.WriteLine("Enter client's name, egn, adress and phone number.");
                string input = Console.ReadLine();
                while (!input.ToLower().Equals("next"))
                {
                    string[] clientData = input.Split(", ");
                    if (clientData.Length == 4)
                    {
                        Client client = new Client(clientData[0], clientData[1], clientData[2], clientData[3]);
                        bool isExisting = false;
                        foreach (Client clientent in bank.GetClients())
                        {
                            if (client.Egn.Equals(clientent.Egn) && client.PhoneNumber.Equals(clientent.PhoneNumber))
                            {
                                isExisting = true;
                                break;
                            }
                        }
                        if (isExisting)
                        {
                            Console.WriteLine("Client already exists!");
                        }
                        else
                        {
                            bank.AddClient(client);
                            Console.WriteLine("Client added successfully!");
                        }

                    }
                    else
                    {
                        Client client = new Client();
                    }
                    input = Console.ReadLine();
                }

                Console.WriteLine("====================================================================================================");
                Console.WriteLine("Enter employee's name, position and phone number.");
                input = Console.ReadLine();
                while (!input.ToLower().Equals("next"))
                {
                    string[] employeeData = input.Split(", ");
                    if (employeeData.Length == 3)
                    {
                        Employee employee = new Employee(employeeData[0], employeeData[1], employeeData[2]);
                        bool isExisting = false;
                        foreach (Employee employeetent in bank.GetEmployees())
                        {
                            if (employee.PhoneNumber.Equals(employeetent.PhoneNumber))
                            {
                                isExisting = true;
                                break;
                            }
                        }
                        if (isExisting)
                        {
                            Console.WriteLine("Employee already exists!");
                        }
                        else
                        {
                            bank.AddEmployee(employee);
                            Console.WriteLine("Employee added successfully!");
                        }

                    }
                    else
                    {
                        Employee employee = new Employee();
                    }
                    input = Console.ReadLine();
                }

                Console.WriteLine("====================================================================================================");
                Console.WriteLine("Enter bank account number, client's name and type currency.");
                input = Console.ReadLine();
                while (!input.ToLower().Equals("next"))
                {
                    bool isBankAccountNumberInvalid = false;
                    bool isClientValid = false;
                    string[] bankAccountData = input.Split(", ");
                    if (bankAccountData.Length == 3)
                    {
                        BankAccount bankAccount = new BankAccount(bankAccountData[0], bankAccountData[1], bankAccountData[2]);

                        foreach (Client client in bank.GetClients())
                        {
                            foreach (BankAccount clientAccount in client.GetBankAccounts())
                            {
                                if (bankAccount.Number.Equals(clientAccount.Number))
                                {
                                    isBankAccountNumberInvalid = true;
                                    break;
                                }
                            }

                            if (isBankAccountNumberInvalid)
                            {
                                Console.WriteLine("Invalid account number!");
                                break;
                            }

                            if (client.Name.ToLower().Equals(bankAccount.Client.ToLower()))
                            {
                                client.AddBankAccount(bankAccount);
                                Console.WriteLine("Bank account added successfully!");
                                isClientValid = true;
                                break;
                            }
                        }

                        if (!isClientValid)
                        {
                            Console.WriteLine("Invalid client!");
                        }

                    }
                    else
                    {
                        BankAccount bankAccount = new BankAccount();
                    }


                    input = Console.ReadLine();
                }

                Console.WriteLine("====================================================================================================");
                Console.WriteLine("Enter transaction type (Deposit or Withdraw), client's name, employee's name, bank account number and money to transact.");
                input = Console.ReadLine();
                while (!input.ToLower().Equals("next"))
                {
                    string[] transactionData = input.Split(", ");
                    bool isValidBankNumber = false;
                    if (transactionData.Length == 5)
                    {
                        Transaction transaction = new Transaction(transactionData[0], transactionData[1], transactionData[2], transactionData[3], double.Parse(transactionData[4]));
                        bank.AddSuccessfulTransaction(transaction);
                        if (transaction.Type.ToLower().Equals("deposit"))
                        {
                            foreach (Client client in bank.GetClients())
                            {
                                if (client.Name.ToLower().Equals(transaction.Client.ToLower()))
                                {
                                    client.AddTransaction(transaction);
                                    foreach (BankAccount bankAccount in client.GetBankAccounts())
                                    {
                                        if (bankAccount.Number.Equals(transaction.BankAccount))
                                        {
                                            bankAccount.CalculateMoneyWithInterest(transaction.Money);
                                            Console.WriteLine("Successful deposit!");
                                            isValidBankNumber = true;

                                        }
                                    }
                                }
                            }
                            if (!isValidBankNumber)
                            {
                                throw new ArgumentException("Unsuccessful deposit! Invalid data!");
                            }
                        }
                        else if (transaction.Type.ToLower().Equals("withdraw"))
                        {
                            foreach (Client client in bank.GetClients())
                            {
                                if (client.Name.ToLower().Equals(transaction.Client.ToLower()))
                                {
                                    client.AddTransaction(transaction);
                                    foreach (BankAccount bankAccount in client.GetBankAccounts())
                                    {
                                        if (bankAccount.Number.Equals(transaction.BankAccount))
                                        {
                                            if (bankAccount.MoneyInBankAccount >= transaction.Money)
                                            {
                                                bankAccount.Withdraw(transaction.Money);
                                                Console.WriteLine("Successful withdraw!");
                                            }
                                            else
                                            {
                                                client.RemoveTransaction(transaction);
                                                bank.RemoveTransaction(transaction);
                                                bank.AddUnsuccessfulTransaction(transaction);
                                                Console.WriteLine("Unsuccessful withdraw! Not enough money in the bank account!");
                                            }
                                            isValidBankNumber = true;
                                        }
                                    }
                                }
                            }
                            if (!isValidBankNumber)
                            {
                                throw new ArgumentException("Unsuccessful withdraw! Invalid data!");
                            }

                        }
                        foreach (Employee employee in bank.GetEmployees())
                        {
                            if (employee.Name.ToLower().Equals(transaction.Employee.ToLower()))
                            {
                                employee.AddTransaction(transaction);
                            }
                        }
                    }
                    else
                    {
                        Transaction transaction = new Transaction();
                    }


                    input = Console.ReadLine();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("====================================================================================================");
                Console.WriteLine("Client -> Bank Accounts and Transactions: ");

                if (bank.GetClients().Count > 0)
                {
                    foreach (Client client in bank.GetClients())
                    {
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                        Console.WriteLine(client);
                        if (client.GetBankAccounts().Count > 0)
                        {
                            foreach (BankAccount bankAccount in client.GetBankAccounts())
                            {
                                Console.WriteLine(bankAccount);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No created Bank Accounts for this Client");
                        }
                        if (client.GetTransactions().Count > 0)
                        {
                            foreach (Transaction transaction in client.GetTransactions())
                            {
                                Console.WriteLine(transaction);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No succssful Transactions for this Client");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No entered Clients => No created Bank Accounts and No succssful Transactions for Clients");
                }

                Console.WriteLine("====================================================================================================");
                Console.WriteLine("Employee -> Transactions");

                if (bank.GetEmployees().Count > 0)
                {
                    foreach (Employee employee in bank.GetEmployees())
                    {
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                        Console.WriteLine(employee);
                        if (employee.GetTransactions().Count > 0)
                        {
                            foreach (Transaction transaction in employee.GetTransactions())
                            {
                                Console.WriteLine(transaction);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No successful Transactions for this Employee");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No entered Employees => No succssful Transactions for Employees");
                }

                Console.WriteLine("====================================================================================================");
                Console.WriteLine("Successful transactions: ");
                if (bank.GetSuccessfulTransactions().Count > 0)
                {
                    foreach (Transaction transaction in bank.GetSuccessfulTransactions())
                    {
                        Console.WriteLine(transaction);
                    }
                }
                else
                {
                    Console.WriteLine("No successful Transactions for this Bank");
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.WriteLine("Unsuccessful transactions: ");
                if (bank.GetUnsuccessfulTransactions().Count > 0)
                {
                    foreach (Transaction transaction in bank.GetUnsuccessfulTransactions())
                    {

                        Console.WriteLine(transaction);
                    }
                }
                else
                {
                    Console.WriteLine("No unsuccessful Transactions for this Bank");
                }

                Console.WriteLine("====================================================================================================");
                Console.WriteLine("Thanks for visiting inWest Bank!");
            }

        }
    }
}
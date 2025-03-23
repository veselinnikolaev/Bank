using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Transaction
    {
        private string type;
        private string client;
        private string employee;
        private string bankAccount;
        private double money;

        public Transaction()
        {
            throw new ArgumentException("Invalid transaction information!");
        }

        public Transaction(string type, string client, string employee, string bankAccount, double money)
        {
            Type = type;
            Client = client;
            Employee = employee;
            BankAccount = bankAccount;
            Money = money;
        }

        public string Type
        {
            set { if (String.IsNullOrEmpty(value) && ((!value.ToLower().Equals("deposit")) || (!value.ToLower().Equals("withdraw")))) { throw new ArgumentException("Valid type of transcation needed!"); } type = value; }
            get { return type; }
        }
        public string Client
        {
            set { if (String.IsNullOrEmpty(value)) { throw new ArgumentException("Invalid client!"); } client = value; }
            get { return client; }
        }
        public string Employee
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid employee!");
                }
                employee = value;
            }
            get { return employee; }
        }
        public string BankAccount
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid bank accout!");
                }
                bankAccount = value;
            }
            get { return bankAccount; }
        }
        public double Money
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Money cannot be negative or zero!");
                }
                money = value;
            }
            get { return money; }
        }
        public override string ToString()
        {
            return $"Transaction type: {Type}, Bank account number: {BankAccount}, transferred: {Money}";
        }
    }
}
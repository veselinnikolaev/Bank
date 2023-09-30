﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Bank
{
    class Client
    {
        private string name;
        private string egn;
        private string address;
        private string phoneNumber;
        private List<Transaction> clientTransactions;
        private List<BankAccount> clientBankAccounts;

        public Client()
        {
            throw new ArgumentException("Invalid client data!");
        }
        public Client(string name, string egn, string address, string phoneNumber)
        {
            Name = name;
            Egn = egn;
            Address = address;
            PhoneNumber = phoneNumber;
            clientTransactions = new List<Transaction>();
            clientBankAccounts = new List<BankAccount>();
        }

        public string Name
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot empty!");

                }

                else if (value.Any(Char.IsNumber))
                {
                    throw new ArgumentException("Name does NOT contain numbers!");
                }

                else
                {
                    name = value;
                }
            }
            get { return name; }

        }

        public string PhoneNumber
        {
            set
            {
                if (value.Length < 10)
                {
                    throw new ArgumentException("Invalid phone number!");
                }
                else if (value[0] != '0' && value[1] != '8')
                {
                    throw new ArgumentException("Invalid phone number!");
                }
                else if (!value.All(Char.IsDigit))
                {
                    throw new ArgumentException("Phone number does not contain letters/symbols!");
                }
                    phoneNumber = value;

            }
            get { return phoneNumber; }

        }

        public string Egn
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Egn cannot be empty!");
                }

                else if (value.Length != 10)
                {
                    throw new ArgumentException("Invalid egn!");
                }

                else if (!value.All(Char.IsDigit))
                {
                    throw new ArgumentException("Egn needs to include only numbers!");
                }
                else
                {
                    egn = value;
                }
            }
            get { return egn; }
        }
        public string Address
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Ivalid adress!");
                }
                address = value;
            }
            get { return address; }
        }
        public void AddTransaction(Transaction transaction)
        {
            clientTransactions.Add(transaction);
        }
        public void AddBankAccount(BankAccount bankAccount)
        {
            clientBankAccounts.Add(bankAccount);
        }
        public void RemoveTransaction(Transaction transaction)
        {
            clientTransactions.Remove(transaction);
        }
        public List<BankAccount> GetBankAccounts()
        {
            return clientBankAccounts;
        }
        public List<Transaction> GetTransactions()
        {
            return clientTransactions;
        }
        public override string ToString()
        {
            return $"Client {Name}, EGN: {Egn}, Address: {Address}, Phone number: {PhoneNumber}: ";
        }

    }
}
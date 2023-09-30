﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    class Employee
    {
        private string name;
        private string position;
        private string phoneNumber;
        private List<Transaction> employeeTransactions;

        public Employee()
        {
            throw new ArgumentException("Invalid employee data!");
        }
        public Employee(string name, string position, string phoneNumber)
        {
            Name = name;
            Position = position;
            PhoneNumber = phoneNumber;
            employeeTransactions = new List<Transaction>();
        }



        public string Name
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cant be empty!");
                }
                else if (value.Any(Char.IsNumber))
                {
                    throw new ArgumentException("Name does not contain numbers!");
                }
                name = value;
            }
            get { return name; }
        }

        public string Position
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                if (!value.ToLower().Equals("bank teller") && !value.ToLower().Equals("clerker") && !value.ToLower().Equals("financial analyst") && !value.ToLower().Equals("auditor") && !value.ToLower().Equals("accountant") && !value.ToLower().Equals("investment banker") && !value.ToLower().Equals("bank manager") && !value.ToLower().Equals("loan officer") && !value.ToLower().Equals("banker"))
                {
                    throw new ArgumentException("Invalid position!");
                }
                position = value;
            }
            get { return position; }
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

        public void AddTransaction(Transaction transaction)
        {
            employeeTransactions.Add(transaction);
        }
        public List<Transaction> GetTransactions()
        {
            return employeeTransactions;
        }
        public override string ToString()
        {
            return $"Employee {Name}, Position: {Position}, Phone number: {PhoneNumber}: ";
        }
    }
}
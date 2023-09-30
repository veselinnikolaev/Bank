﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    class BankAccount
    {
        private string number;
        private string client;
        private string currency;
        private static double interest;
        private double moneyInBankAccount;

        public BankAccount()
        {
            throw new ArgumentException("Invalid bank account data!");
        }
        public BankAccount(string number, string client, string currency)
        {
            Number = number;
            Client = client;
            Currency = currency;
            Interest = 0.1;
            MoneyInBankAccount = 0;
        }
        public string Number
        {
            set
            {
                if (String.IsNullOrEmpty(value) && !value.All(char.IsDigit))
                    if (String.IsNullOrEmpty(value) && !value.All(char.IsDigit))
                    {
                        throw new ArgumentException("Ivalid number!");
                    }
                number = value;
            }
            get { return number; }
        }
        public string Client
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Ivalid client!");
                }
                client = value;
            }
            get { return client; }
        }
        public string Currency
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid currency!");
                }
                currency = value;
            }
            get { return currency; }
        }
        public double Interest
        {
            set
            {
                interest = value;
            }
            get { return interest; }
        }
        public double MoneyInBankAccount
        {
            set { if(moneyInBankAccount < 0){ throw new ArgumentException("Negativ money in bank!");} moneyInBankAccount = value;  }
            get { return moneyInBankAccount; }
        }
        public void CalculateMoneyWithInterest(double money)
        {
            MoneyInBankAccount = money + money * Interest;
        }
        public void Withdraw(double money)
        {
            MoneyInBankAccount -= money;
        }
        public override string ToString()
        {
            return $"Bank account number: {Number}, Interest: 10%, Money: {MoneyInBankAccount}{Currency}";
        }
    }
}
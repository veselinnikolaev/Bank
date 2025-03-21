﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Bank
    {
        private List<Client> clients;
        private List<Employee> employees;
        private List<Transaction> successfulTransactions;
        private List<Transaction> unsuccessfulTransactions;

        public Bank()
        {
            clients = new List<Client>();
            employees = new List<Employee>();
            successfulTransactions = new List<Transaction>();
            unsuccessfulTransactions = new List<Transaction>();
        }

        public void AddClient(Client client)
        {
            clients.Add(client);
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void AddSuccessfulTransaction(Transaction transaction)
        {
            successfulTransactions.Add(transaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            successfulTransactions.Remove(transaction);
        }

        public void AddUnsuccessfulTransaction(Transaction transaction)
        {
            unsuccessfulTransactions.Add(transaction);
        }

        public List<Client> GetClients()
        {
            return clients;
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public List<Transaction> GetSuccessfulTransactions()
        {
            return successfulTransactions;
        }

        public List<Transaction> GetUnsuccessfulTransactions()
        {
            return unsuccessfulTransactions;
        }
    }
}
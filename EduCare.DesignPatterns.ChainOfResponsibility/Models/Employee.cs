﻿using EduCare.DesignPatterns.ChainOfResponsibility.Models.Base;
using System.Collections.Generic;

namespace EduCare.DesignPatterns.ChainOfResponsibility.Models
{
    public class Employee : BindableBase
    {
        public Employee()
        {
            SubEmployees = new List<Employee>();
            ExpenseList = new List<Expense>();
        }
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private Employee _manager;
        public Employee Manager
        {
            get { return _manager; }
            set
            {
                SetProperty(ref _manager, value);
                if (_manager != null)
                    _manager.SubEmployees.Add(this);
            }
        }

        private List<Employee> _subEmployees;
        public List<Employee> SubEmployees
        {
            get { return _subEmployees; }
            set { SetProperty(ref _subEmployees, value); }
        }

        private int _approveLimit;
        public int ApproveLimit
        {
            get { return _approveLimit; }
            set { _approveLimit = value; }
        }


        private double _approvalExpenseLimit;
        public double ApprovalExpenseLimit
        {
            get { return _approvalExpenseLimit; }
            set { SetProperty(ref _approvalExpenseLimit, value); }
        }

        private List<Expense> _expenseList;
        public List<Expense> ExpenseList
        {
            get { return _expenseList; }
            set { _expenseList = value; }
        }

    }
}

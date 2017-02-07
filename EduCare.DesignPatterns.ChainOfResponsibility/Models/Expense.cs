using EduCare.DesignPatterns.ChainOfResponsibility.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.ChainOfResponsibility.Models
{
    public class Expense : BindableBase
    {
        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }

        private DateTime _requestDate;
        public DateTime RequestDate
        {
            get { return _requestDate; }
            set { SetProperty(ref _requestDate, value); }
        }

    }
}

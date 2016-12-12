using EduCare.DesignPatterns.Factory.Base;
using EduCare.DesignPatterns.Factory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduCare.DesignPatterns.Factory
{
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            cmbType.DataSource = Enum.GetValues(typeof(PaymentType));
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            PaymentType type;
            Enum.TryParse(cmbType.SelectedItem.ToString(), out type);
            #region Bad Way
            //var status = false;
            //switch (type)
            //{
            //    case PaymentType.CreditCard:
            //        var cc = new CreditCard();
            //        status = cc.UseCreditForPayment(nudAmount.Value);
            //        break;
            //    case PaymentType.Cash:
            //        var cash = new Cash();
            //        status = cash.PayMoney(nudAmount.Value);
            //        break;
            //    case PaymentType.BankTransfer:
            //        var bt = new BankTransfer();
            //        status = bt.SendMoneyViaBankAccount(nudAmount.Value);
            //        break;
            //    case PaymentType.Paypal:
            //        var pp = new PayPal();
            //        status = pp.SendMoney(nudAmount.Value);
            //        break;
            //    default:
            //        MessageBox.Show("option not defined");
            //        break;
            //} 
            #endregion

            var pf = new PaymentFactory();
            IPayment p = pf.GetPayment(type);
            p.Pay(nudAmount.Value);
        }
    }
}

using System;
using System.Windows.Forms;

namespace EduCare.DesignPatterns.Factory
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPayment());
        }
    }
}

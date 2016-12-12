using EduCare.DesignPatterns.Strategy.Concrete;
using EduCare.DesignPatterns.Strategy.Enums;
using EduCare.DesignPatterns.Strategy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduCare.DesignPatterns.Strategy
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public LogType SelectedType { get; set; }
        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbType.DataSource = Enum.GetValues(typeof(LogType));
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogType type;
            Enum.TryParse(cmbType.SelectedValue.ToString(), out type);
            SelectedType = type;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (SelectedType)
            {
                case LogType.LocalDisk:
                    SaveToDisk();
                    break;
                case LogType.Ftp:
                    SaveToFtpServer();
                    break;
                case LogType.Database:
                    SaveToSql();
                    break;
            }
        }

        private void SaveToFtpServer()
        {
            var logger = new FtpLogger();
            var log = new ActionLog(rtbLog.Text);
            log.Id = Guid.NewGuid();
            log.Created = DateTime.Now;
            logger.UploadToServer(log);
        }

        private void SaveToSql()
        {
            var logger = new SqlLogger();
            var log = new ActionLog(rtbLog.Text);
            log.Id = Guid.NewGuid();
            log.Created = DateTime.Now;
            logger.SaveLog(log);
        }

        private void SaveToDisk()
        {
            var logger = new FileLogger();
            var log = new ActionLog(rtbLog.Text);
            log.Id = Guid.NewGuid();
            log.Created = DateTime.Now;
            logger.LogToFile(log);
        }
    }
}

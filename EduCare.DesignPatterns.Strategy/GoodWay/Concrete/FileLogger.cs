using EduCare.DesignPatterns.Strategy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace EduCare.DesignPatterns.Strategy.GoodWay.Concrete
{
    public class FileLogger : ILogger
    {
        private readonly string _logPath;
        private string _path;
        public FileLogger()
        {
            _logPath = ConfigurationManager.AppSettings["LogPath"];
            SetupEnvironment();
        }

        public void Save(string logText)
        {
            var content = File.ReadAllText(_path);
            var writtenLogs = JsonConvert.DeserializeObject<List<ActionLog>>(content);
            if (writtenLogs == null)
                writtenLogs = new List<ActionLog>();
            var log = new ActionLog(logText);
            log.Id = Guid.NewGuid();
            log.Created = DateTime.Now;
            writtenLogs.Add(log);
            var logText2 = JsonConvert.SerializeObject(writtenLogs);
            File.WriteAllText(_path, logText2);
        }

        private void SetupEnvironment()
        {
            var yearPath = $@"{_logPath}\{DateTime.Now.Year}";
            var monthPath = $@"{yearPath}\{DateTime.Now.Month}";
            var dayPath = $@"{monthPath}\{DateTime.Now.Day}";
            _path = $@"{dayPath}\dailylog.log";
            if (!Directory.Exists(yearPath))
                Directory.CreateDirectory(yearPath);
            if (!Directory.Exists(monthPath))
                Directory.CreateDirectory(monthPath);
            if (!Directory.Exists(dayPath))
                Directory.CreateDirectory(dayPath);
            if (!File.Exists(_path))
            {
                var f = File.Create(_path);
                f.Close();
            }
        }
    }
}

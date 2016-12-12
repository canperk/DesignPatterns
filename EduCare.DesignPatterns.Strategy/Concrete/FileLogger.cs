using EduCare.DesignPatterns.Strategy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace EduCare.DesignPatterns.Strategy.Concrete
{
    public class FileLogger
    {
        private readonly string _logPath;
        private string _path;
        public FileLogger()
        {
            _logPath = ConfigurationManager.AppSettings["LogPath"];
            SetupEnvironment();
        }

        public void LogToFile(ActionLog log)
        {
            var content = File.ReadAllText(_path);
            var writtenLogs = JsonConvert.DeserializeObject<List<ActionLog>>(content);
            if (writtenLogs == null)
                writtenLogs = new List<ActionLog>();
            writtenLogs.Add(log);
            var logText = JsonConvert.SerializeObject(writtenLogs);
            File.WriteAllText(_path, logText);
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

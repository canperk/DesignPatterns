using EduCare.DesignPatterns.Strategy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace EduCare.DesignPatterns.Strategy.GoodWay.Concrete
{
    public class FtpLogger : ILogger
    {
        private readonly string _ftpAddress;
        private string _path;
        public FtpLogger()
        {
            _ftpAddress = ConfigurationManager.AppSettings["FtpAddress"];
            SetEnvironment();
        }

        private void SetEnvironment()
        {
            var yearPath = $"{_ftpAddress}/{DateTime.Now.Year}";
            var monthPath = $"{yearPath}/{DateTime.Now.Month}";
            _path = $"{monthPath}/{DateTime.Now.Day}_dailyLog.log";
            if (!DirectoryExist(yearPath))
            {
                var request = (FtpWebRequest)WebRequest.Create(yearPath);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.GetResponse();
                request = null;
            }

            if (!DirectoryExist(monthPath))
            {
                var request = (FtpWebRequest)WebRequest.Create(monthPath);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.GetResponse();
                request = null;
            }
            if (!FileExist(_path))
            {
                var buffer = Encoding.UTF8.GetBytes("[]");
                WebRequest request = WebRequest.Create(_path);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                using (var str = request.GetRequestStream())
                {
                    str.Write(buffer, 0, buffer.Length);
                }
                request.GetResponse();
                request = null;
            }
        }

        public bool DirectoryExist(string directory)
        {
            var ftpRequest = (FtpWebRequest)WebRequest.Create(directory);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            try
            {
                using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                ftpRequest = null;
            }
        }

        public bool FileExist(string file)
        {
            var ftpRequest = (FtpWebRequest)WebRequest.Create(file);
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            try
            {
                using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                ftpRequest = null;
            }
        }

        public void Save(string logText)
        {
            var list = new List<ActionLog>();
            var request = WebRequest.Create(_path);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            using (WebResponse tmpRes = request.GetResponse())
            {
                using (Stream tmpStream = tmpRes.GetResponseStream())
                {
                    using (TextReader tmpReader = new StreamReader(tmpStream))
                    {
                        var log = new ActionLog(logText);
                        log.Created = DateTime.Now;
                        log.Id = Guid.NewGuid();
                        string fileContents = tmpReader.ReadToEnd();
                        list = JsonConvert.DeserializeObject<List<ActionLog>>(fileContents);
                        list.Add(log);
                    }
                }
            }
            request = WebRequest.Create(_path);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            var buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(list));
            using (var str = request.GetRequestStream())
            {
                str.Write(buffer, 0, buffer.Length);
            }
            request.GetResponse();
            request = null;
        }
    }
}

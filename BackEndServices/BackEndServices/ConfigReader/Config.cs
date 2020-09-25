using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BackEndServices.ConfigReader
{
    public class Config
    {
        public static Dictionary<string, string> ReadConfig(string filePath)
        {
            Dictionary<string, string> config = new Dictionary<string, string>();
            using (StreamReader str = new StreamReader(filePath))
            {
                string configFile = str.ReadToEnd();
                string[] tmp = configFile.Split(Environment.NewLine);
                for (int i = 0; i < tmp.Length; i++)
                {
                    string[] values = tmp[i].Split("=");
                    config.Add(values[0], values[1]);
                }
            }
            return config;
        }
    }
}

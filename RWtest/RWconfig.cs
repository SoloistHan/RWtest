using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;


namespace RWtest
{

    class RWconfig
    {
        public static string configPath = @"D:\TEST\Config.txt";
        static Dictionary<string, string> dic_writeTest = new Dictionary<string, string>();
        public static void ReadConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string SSS = config.AppSettings.Settings["key01"].Value;
            //if (config.AppSettings.Settings["key01"] == null)
            //    return "";
            //else
            //    return config.AppSettings.Settings["key01"].Value;

        }

       

        public static void WriteConfig()
        {
            //增加的內容寫在appSettings段下 <add key="RegCode" value="0"/>  
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["key01"] == null)
            {
                config.AppSettings.Settings.Add("key01", "010101");
            }
            else
            {
                config.AppSettings.Settings["key01"].Value = "222";
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//重新載入新的配置檔案  



            //ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            //file.ExeConfigFilename = @"D:\TEST\test.config";
            //Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            //ConfigSectionData data = new ConfigSectionData();
            //data.Id = 1000;
            //data.Time = DateTime.Now;

            //config.SectionGroups.Add("group1", new ConfigurationSectionGroup());
            //config.SectionGroups["group1"].Sections.Add("add", data);

            //config.Save(ConfigurationSaveMode.Minimal);


            //dic_writeTest.Add("First", "One_" + DateTime.Now.ToString("G"));
            //dic_writeTest.Add("Second", "Two_" + DateTime.Now.ToString("F"));
            //dic_writeTest.Add("Third", "Three_" + DateTime.Now.ToString("T"));
            //string str_GetJson = JsonConvert.SerializeObject(dic_writeTest).Replace(",", "\r");

            //using (StreamWriter sw = new StreamWriter(configPath))
            //{
            //    sw.Write(str_GetJson);
            //    sw.Dispose();
            //}
            //for(int item = 0; item < dic_writeTest.Count; item++ )
            //{         
            //}

        }

        class ConfigSectionData : ConfigurationSection
        {
            [ConfigurationProperty("id")]
            public int Id
            {
                get { return (int)this["id"]; }
                set { this["id"] = value; }
            }

            [ConfigurationProperty("time")]
            public DateTime Time
            {
                get { return (DateTime)this["time"]; }
                set { this["time"] = value; }
            }
        }
    }
}

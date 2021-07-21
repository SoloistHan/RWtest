using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace RWtest
{
    class ConfigRW
    {
        public string key01 { get; set; }
        public string key02 { get; set; }
        public string key03 { get; set; }
        public string key04 { get; set; }
        public string key05 { get; set; }
    }

    class RWconfig
    {
        public static string configPath = @"D:\TEST\Config.txt";
        static Dictionary<string, string> dic_WriteTest = new Dictionary<string, string>();
        static Dictionary<string, string> dic_ReadTest = new Dictionary<string, string>();
        static  ConfigRW Crw = new ConfigRW();
        public static void reload()
        {
            dic_WriteTest.Add("key01", "123");
            dic_WriteTest.Add("key02", "456");
            dic_WriteTest.Add("key03", "789");
            dic_WriteTest.Add("key04", "000");
            dic_WriteTest.Add("key05", "ABCDEFGHIJK");            
            
            Crw.key01 = "ABC";
            Crw.key02 = "DDD";
            Crw.key03 = "EFG";
            Crw.key04 = "HHH";
            Crw.key05 = "12345678";
        }
        public static void ReadConfig()
        {
            r_XmlWay();
            //r_ConfigWay();
        }    
        public static void WriteConfig()
        {
            reload();
            w_XmlWay();
            //w_ConfigWay();
        }

        //--------------------------------------------------This it --------------------------------------------------
        private static void r_XmlWay()
        {
            XElement rootElement = XElement.Load(configPath);
            foreach (var el in rootElement.Elements())
            {
                dic_ReadTest.Add(el.Name.LocalName, el.Value);
            }
        }
        private static void w_XmlWay()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XElement xET_Write = new XElement("root",   dic_WriteTest.Select(kv => new XElement(kv.Key, kv.Value)));
            xET_Write.Save(configPath, SaveOptions.None);
        }
        //-------------------------------------------------------------------------------------------------------


        private static void r_ConfigWay()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string SSS = config.AppSettings.Settings["key01"].Value;        
        }
        private static void w_ConfigWay()
        {
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
        }



    }
}

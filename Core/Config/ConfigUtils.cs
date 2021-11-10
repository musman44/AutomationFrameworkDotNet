using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace AutomationFrameworkDotNet.Core.Config
{
    class ConfigUtils
    {
        /*
         * Description:
            |  1. This class contains methods related to fetching data from config file
            |  2. This class also contains methods to fetch base URLs and service descriptions
         */

        String projectPath;

        public ConfigUtils()
        {
            // This will get the current PROJECT directory upto \bin\Debug 
            var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            //the project directory is the grand-father of the current directory
            projectPath = currentDirectory.Parent.Parent.FullName;
        }

        public Dictionary<String, String> GetValueFromJsonKeyPath(String jsonFilePath, String keyPath)
        {
            /*
             * Description:
                |   This method fetches value of a key from a json file
            
                :return: List

                Examples:
                    |  An example of keyPath is root/level1/level2/key
             */

            try
            {
                // read file from Path and parse it into JSON object
                JObject jsonSDFileData = JObject.Parse(File.ReadAllText(jsonFilePath));
                // get JSON keyPath objects and convert into a dictionary
                Dictionary<String, String> serviceParams = jsonSDFileData[keyPath].ToObject<Dictionary<string, string>>();

                return serviceParams;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in GetValueFromJsonKeyPath method -->" + e.Message);
                throw;
            }

        }

        public String FetchServiceDescriptionPath()
        {
            /*
             * Description:
                |   This method fetches path of the {project}/Services/ServiceDescription directory
             */

            try
            {
                String serviceDescPath = Path.Combine(projectPath, "Services", "ServiceDescription");
                return serviceDescPath;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in FetchServiceDescriptionPath method-->" + e.Message);
                throw;
            }

        }

        public String FetchServicePayloadPath()
        {
            /*
             * Description:
                |   This method fetches path of the {project}/Services/Payloads directory
             */

            try
            {
                String servicePayloadsPath = Path.Combine(projectPath, "Services", "Payloads");
                return servicePayloadsPath;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in FetchServicePayloadPath method-->" + e.Message);
                throw;
            }

        }

        public Dictionary<String, String> GetServiceDescription(string serviceDescRelFilePath, string keyPath)
        {
            /*
             * Description:
                |  This method fetches entire service description params of a particular from the service description json file.
                |  The service description json file contains below keys
                |  method:
                |  targetURL:
                |  endpoint:
                |  queryparams:
                |  headers:
                |  authType:
                |  username:
                |  password:
                |  payload:                

                :param serviceDescRelFilePath: Relative path of the service description file      
                :param keyPath:

                :return: Dictionary
             */

            try
            {
                Dictionary<String, String> dictServiceDesc = new Dictionary<String, String>();
                String serviceDescPath = Path.Combine(FetchServiceDescriptionPath(), serviceDescRelFilePath);
                Dictionary<String, String> dictServiceDescription = GetValueFromJsonKeyPath(serviceDescPath, keyPath);

                dictServiceDesc["method"] = dictServiceDescription["method"];
                dictServiceDesc["targetURL"] = dictServiceDescription["targetURL"];
                dictServiceDesc["endpoint"] = dictServiceDescription["endpoint"];

                if (dictServiceDescription["queryparams"] == "None")
                    dictServiceDesc["queryparams"] = "";
                else
                    dictServiceDesc["queryparams"] = dictServiceDescription["queryparams"];

                if (dictServiceDescription["headers"] == "None")
                    dictServiceDesc["headers"] = "{ }";
                else
                    dictServiceDesc["headers"] = dictServiceDescription["headers"];

                dictServiceDesc["authType"] = dictServiceDescription["authType"];
                dictServiceDesc["username"] = dictServiceDescription["username"];
                dictServiceDesc["password"] = dictServiceDescription["password"];

                if (dictServiceDescription["payload"] == "None")
                    dictServiceDesc["payload"] = "";
                else
                {
                    String payloadPath = Path.Combine(FetchServicePayloadPath(), dictServiceDescription["payload"]);
                    String jsonPayload = File.ReadAllText(payloadPath);
                    dictServiceDesc["payload"] = jsonPayload;
                }

                return dictServiceDesc;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error in GetServiceDescription method -->" + e.Message);
                throw;
            }

        }
    }
}

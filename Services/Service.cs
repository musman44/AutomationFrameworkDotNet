﻿using System;
using System.Collections.Generic;
using AutomationFrameworkDotNet.Core.API;
using AutomationFrameworkDotNet.Core.Config;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace AutomationFrameworkDotNet.Services
{
    class Service
    {
        /*
         * Description:
            |  This class contains the methods for building Service request, verifying status code and content from response
         */

        BusinessUtilsAPI businessUtilsApi;
        ConfigUtils configUtils;
        public IRestResponse response;

        public Service()
        {
            businessUtilsApi = new BusinessUtilsAPI();
            configUtils = new ConfigUtils();
        }

        public void CreateAndCallServiceRequest(string serviceName)
        {
            // This method is used to extract all values of a service from ServiceDescription.json, and pass those parameters to BusinessUtilsAPI > CallRequest method
            // which will actually execute the API request and return the response

            try
            {
                Dictionary<String, String> dictServiceDesc = configUtils.GetServiceDescription("ServiceDescription.json", serviceName);
                string method = dictServiceDesc["method"];
                string url = dictServiceDesc["targetURL"] + dictServiceDesc["endpoint"] + dictServiceDesc["queryparams"];
                string headers = dictServiceDesc["headers"];
                string payload = dictServiceDesc["payload"];

                string authType = dictServiceDesc["authType"];
                string authUsername = dictServiceDesc["username"];
                string authPassword = dictServiceDesc["password"];


                response = businessUtilsApi.CallRequest(method, url, headers, payload, null, null, null, authType, authUsername, authPassword, 40000);
                Assert.IsTrue(response != null);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in CreateServiceRequest method -->" + e.Message);
                throw;
            }

        }

        public void VerifyStatusCode(int statusCode)
        {
            // This method is used to verify if the API response status code is same as expected or not, using common BusinessUtilsAPI > VerifyOkResponse method

            try
            {
                Assert.IsTrue(businessUtilsApi.VerifyOkResponse(response, statusCode));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in VerifyStatusCode method -->" + e.Message);
                throw;
            }

        }

        public void VerifyResponseContent(string name)
        {
            // This method is used to verify if the API response contains the required content or not

            try
            {
                var jsonResponse = JObject.Parse(response.Content);

                string expectedName = name;
                string actualName;

                if (name == "Islamabad")
                    actualName = (string)jsonResponse["location"]["region"];
                else
                    actualName = (string)jsonResponse["0"]["username"];

                Assert.IsTrue(actualName == expectedName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in VerifyResponseContent method -->" + e.Message);
                throw;
            }

        }
    }
}

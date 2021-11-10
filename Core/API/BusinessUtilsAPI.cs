using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace AutomationFrameworkDotNet.Core.API
{
    class BusinessUtilsAPI
    {
        /*
         * Description:
            |  This class contains the common methods or utilities for API Automation
         */

        public IRestResponse response;
        RestClient client;
        RestRequest request;

        public BusinessUtilsAPI()
        {
            request = new RestRequest();
        }

        public IRestResponse CallRequest(String method, String url, String headers, Object payload,
                                    Dictionary<String, String> formParams, Dictionary<String, FileParameter> fileParams,
                                    Dictionary<String, String> pathParams, String authType = null,
                                    String authUsername = null, String authPassword = null, int timeout = 30000)
        {
            /*
             * Description:
                |   This method allows user to call a Get/Post/Put/Post/Patch/Delete request

                :param method: Type of request.Get or Post etc..                
                :param url: Request URL
                :param headers: Headers to call a request (dictionary)
                :param payload: payload object
                :param formParams: formParams dictionary
                :param fileParams: fileParams dictionary
                :param pathParams: pathParams dictionary
                :param authType:
                :param authUsername:
                :param authPassword:
                :param timeout: (optional) How long to wait for the server to send
                
                :return: response - response object generated on calling a request

                Example Method Calls:

                    call_request("Get","https://www.samplesite.com/param1/param2",{"Accept":"application/json"},null,null,null,null,"Basic","test","Test",100)
                    call_request("Post","https://www.samplesite.com/param1/param2",{"Accept":"application/json"},'{"KOU":"123456"}', null,null,null,"Basic","test","Test",100)

                .. note::
                    |  method (String) :
                    |  Accepts: Get, Post, Put, Patch or Delete
                    |
                    |  authType(String) :
                    |  Accepts: basic, ntlm, digest, proxy                                                           
             */

            try
            {
                if (url == "")
                    Console.WriteLine("URL can not be null");

                client = new RestClient(url);

                if (authType != null)
                {
                    if (authType.ToLower() == "basic")
                    {
                        client.Authenticator = new HttpBasicAuthenticator(authUsername, authPassword);
                    }

                }

                // add header parameters, if any
                if (headers != null)
                {
                    //JObject headersData = (JObject.Parse(headers)).ToObject<Dictionary<string, string>>();
                    Dictionary<String, String> dictionary = JObject.Parse(headers).ToObject<Dictionary<string, string>>();

                    foreach (var param in dictionary)
                        request.AddHeader(param.Key, param.Value);
                }

                // add payload (HTTP body (POST request)), if any
                if (payload != null)
                {
                    request.AddParameter("application/json", payload, ParameterType.RequestBody);
                    //request.AddJsonBody(payload);                    
                }

                // add form parameters, if any
                if (formParams != null)
                {
                    foreach (var param in formParams)
                        request.AddParameter(param.Key, param.Value);
                }

                // add file parameters, if any
                if (fileParams != null)
                {
                    foreach (var param in fileParams)
                    {
                        //request.AddFile(param.Value.Name, param.Value.Writer, param.Value.FileName, param.Value.ContentType);
                    }
                }

                // add path parameters, if any
                if (pathParams != null)
                {
                    foreach (var param in pathParams)
                        request.AddParameter(param.Key, param.Value, ParameterType.UrlSegment);
                }

                //request.Timeout = timeout;
                //client.Timeout = timeout;
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                if (method.ToUpper() == "GET")
                {
                    request.Method = Method.GET;
                    response = client.Get(request);
                }

                else if (method.ToUpper() == "POST")
                {
                    request.Method = Method.POST;
                    if (payload != null)
                        response = client.Post(request);
                    //response = client.Execute(request);
                    else
                        Console.WriteLine("Error-->Payload is missing");
                }

                else if (method.ToUpper() == "PUT")
                {
                    request.Method = Method.PUT;
                    if (payload != null)
                        response = client.Put(request);
                    else
                        Console.WriteLine("Error-->Payload is missing");
                }

                else if (method.ToUpper() == "PATCH")
                {
                    request.Method = Method.PATCH;
                    if (payload != null)
                        response = client.Patch(request);
                    else
                        Console.WriteLine("Error-->Payload is missing");
                }

                else if (method.ToUpper() == "DELETE")
                {
                    request.Method = Method.DELETE;
                    response = client.Delete(request);
                }

                else
                    Console.WriteLine("Method can be any one among Get/Post/Put/Patch/Delete but the value is " + method);

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in CallRequest method -->" + e.Message);
                throw;
            }

        }

        public Boolean VerifyOkResponse(IRestResponse response, int statusCode)
        {
            /*
             * Description:
            	|  This method is used to validate if the expected status code is same as returned by the provided API response.
  
                :param response: response of type IRestResponse
                :param statusCode: statusCode of type int
  
                :return: boolean
                Examples:
                |  VerifyOkResponse(response, 200)
                                                          
             */

            try
            {
                int expectedStatusCode = statusCode;
                int actualStatusCode = (int)response.StatusCode;

                bool result = (actualStatusCode == expectedStatusCode);

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error in VerifyOkResponse method -->" + e.Message);
                throw;
            }

        }
    }
}

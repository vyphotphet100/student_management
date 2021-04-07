using StudentManagement.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Utils
{
    public class HttpUtils
    {
        public static JObject GetRequest(string url, String token, Dictionary<String, Object> data)
        {
            String paramStr = "";
            if (data != null)
            {
                paramStr += "?";
                for (int i = 0; i < data.Count; i++)
                {
                    if (i != data.Count - 1)
                        paramStr += data.ElementAt(i).Key + "=" + data.ElementAt(i).Value + "&";
                    else
                        paramStr += data.ElementAt(i).Key + "=" + data.ElementAt(i).Value;
                }
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + paramStr);
            HttpWebResponse response;
            request.Headers["Authorization"] = "Token " + token;
            try { 
                response = (HttpWebResponse)request.GetResponse(); }
            catch (WebException ex) {
                response = (HttpWebResponse)ex.Response;
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            return JObject.Parse(reader.ReadToEnd());

        }

        public static JObject PostRequest(string url, String token, Dictionary<String, Object> data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Token " + token);
            HttpResponseMessage result = client.PostAsync(url, content).Result;
            string returnValue = result.Content.ReadAsStringAsync().Result;
            if (returnValue != null && returnValue != "")
                return JObject.Parse(returnValue);
            return new JObject();
        }

        public static JObject DeleteRequest(string url, String token, Dictionary<String, Object> data)
        {
            //var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Token " + token);
            var response = client.DeleteAsync(url).Result;
            string returnValue = response.Content.ReadAsStringAsync().Result;
            if (returnValue != null && returnValue != "")
                return JObject.Parse(returnValue);
            return new JObject();
        }

        public static JObject PutRequest(string url, String token, Dictionary<String, Object> data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Token " + token);
            HttpResponseMessage result = client.PutAsync(url, content).Result;
            string returnValue = result.Content.ReadAsStringAsync().Result;
            if (returnValue != null && returnValue != "")
                return JObject.Parse(returnValue);
            return new JObject();
        }
    }
}

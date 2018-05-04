using System;
using System.IO;
using System.Net;
using System.Text;

namespace MsSale.Services
{
    public class Services
    {
        private static string linkAuthentication = "http://localhost:5000/api/authenticate";
        private static string linkGetClient = "http://localhost:9000/getCustomerCpf/";
        private static string linkUpdateStock = "http://localhost:8080/venda";
        private static string linkGetProducts = "http://localhost:8080/getProducts";

        private static string CallServiceViaGet(string link)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(link);

            webRequest.AllowAutoRedirect = false;

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            if (!((int)response.StatusCode >= 200 && (int)response.StatusCode <= 299))
            {
                throw new ServiceException();
            }

            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(response.ToString(), Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    sb.Append(reader);
                }
            }

            return sb.ToString();
        }

        private static string CallServiceViaPost(string link, string urlParameters)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(urlParameters);

            Uri targetUrl = new Uri(link);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetUrl);
            Stream requestStream = null;

            try
            {
                request.Method = "POST";
                request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                request.Headers.Add("Content-Length", bytes.Length.ToString());
                request.Headers.Add("Accept", "application/json");

                requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);

                requestStream.Flush();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (!((int)response.StatusCode >= 200 && (int)response.StatusCode <= 299))
                {
                    throw new ServiceException();
                }

                StringBuilder strResponse = new StringBuilder();
                using (StreamReader reader = new StreamReader(response.ToString(), Encoding.UTF8))
                {
                    while (reader.Peek() >= 0)
                    {
                        strResponse.Append(reader);
                    }
                }

                return strResponse.ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return ex.Message;
            }

            finally
            {
                if (null != requestStream)
                    requestStream.Close();
            }

        }

        public static bool ServiceAuthentication(string user, string password)
        {
            string parameters = "username=" + user + "&password=" + password;
            string result = CallServiceViaPost(linkAuthentication, parameters);
            return result.Equals("true", StringComparison.InvariantCultureIgnoreCase);
        }

        public static string ServiceGetClient(string cpf)
        {
            if (cpf != null || cpf != "")
            {
                string clientJson = CallServiceViaGet(Services.linkGetClient + cpf);
                if (clientJson == "" || clientJson == null)
                {
                    return null;
                }
                else
                {
                    return clientJson;
                }
            }
            else
            {
                return null;
            }
        }

        public static bool ServiceUpdateStock(string[] ids, string[] qtds)
        {
            StringBuilder urlParameters = new StringBuilder("");
            urlParameters.Append("id=").Append(ids[0]);
            for (int i = 1; i < ids.Length; i++)
            {
                urlParameters.Append("&id=").Append(ids[i]);
            }
            for (int i = 0; i < qtds.Length; i++)
            {
                urlParameters.Append("&qt=").Append(qtds[i]);
            }
            string result = Services.CallServiceViaPost(linkUpdateStock, urlParameters.ToString());
            return result.Equals("sucess", StringComparison.InvariantCultureIgnoreCase);
        }

        public static string ServiceGetProducts()
        {
            return CallServiceViaGet(Services.linkGetProducts);
        }
    }
}

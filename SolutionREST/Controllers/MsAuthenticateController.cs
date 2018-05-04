﻿using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SolutionREST.Controllers
{
    public class MsAuthenticateController : Controller
    {
        public async Task<IActionResult> MsAuthenticate()
        {
            using (var client = new HttpClient())
            {
                var requestParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username", "Elena"),
                    new KeyValuePair<string, string>("password", "mest")
                };

                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                var tokenServiceResponse = await client.PostAsync("http://localhost:1479/api/Authenticate", requestParamsFormUrlEncoded);
                string responseString = await tokenServiceResponse.Content.ReadAsStringAsync();

                var responseCode = tokenServiceResponse.StatusCode;
                var responseMsg = new HttpResponseMessage(responseCode)
                {
                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                };

                return View();
            }
        }
    }
}
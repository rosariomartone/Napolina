using RestSharp;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Napolina.Controllers
{
    public class AlexaHomeController : Controller
    {
        [Route(Name = "Index")]
        public ContentResult Index()
        {
            ViewBag.Title = "Alexa Home Page";

            return new ContentResult
            {
                ContentType = "text/html",
                Content = GetTokenFromToAlexa()
            };
        }

        private string GetTokenFromToAlexa()
        {
            var client = new RestClient("https://www.amazon.com/ap/oa");

            var request = new RestRequest(Method.POST);
            request.AddParameter("client_id", ConfigurationManager.AppSettings["alex_client_id"]);
            request.AddParameter("scope", "alexa:all");
            request.AddParameter("productID", ConfigurationManager.AppSettings["alex_productID"]);
            request.AddParameter("deviceSerialNumber", ConfigurationManager.AppSettings["alex_deviceSerialNumber"]);
            request.AddParameter("response_type", "token");
            request.AddParameter("redirect_uri", ConfigurationManager.AppSettings["alex_redirect_uri"]); 

            IRestResponse response = client.Execute(request);

            string content = string.Empty;

            if (response.StatusCode==System.Net.HttpStatusCode.OK)
                content = response.Content;

            return content;
        }
    }
}
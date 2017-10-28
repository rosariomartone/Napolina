﻿using RestSharp;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Napolina.Controllers
{
    public class AlexaHomeController : Controller
    {
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
            request.AddParameter("client_id", "amzn1.application-oa2-client.e6bc904be18e4a50930bf88fa678e5b0");
            request.AddParameter("scope", "alexa:all");
            request.AddParameter("productID", "BlueAlexa");
            request.AddParameter("deviceSerialNumber", "ROS-MOBILE");
            request.AddParameter("response_type", "token");
            request.AddParameter("redirect_uri", "https://www.rosariomartone.co.uk/AlexaHome"); 

            IRestResponse response = client.Execute(request);

            string content = string.Empty;

            if (response.StatusCode==System.Net.HttpStatusCode.OK)
                content = response.Content;

            return content;
        }
    }
}
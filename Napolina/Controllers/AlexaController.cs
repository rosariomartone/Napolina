﻿using Napolina.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Napolina.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("api/alexa/napolina")]
        public dynamic Napolina (AlexaRequest alexaRequest)
        {
            AlexaResponse response = null;

            Request request = new Data.Request();
            request.MemberId = (alexaRequest.Session.Attributes == null) ? 0 : alexaRequest.Session.Attributes.MemberId;
            request.Timestamp = alexaRequest.Request.Timestamp;
            request.Intent = (alexaRequest.Request.Intent == null) ? "" : alexaRequest.Request.Intent.Name;
            request.AppId = alexaRequest.Session.Application.ApplicationId;
            request.RequestId = alexaRequest.Request.RequestId;
            request.SessionId = alexaRequest.Session.SessionId;
            request.UserId = alexaRequest.Session.User.UserId;
            request.IsNew = alexaRequest.Session.New;
            request.Version = alexaRequest.Version;
            request.Type = alexaRequest.Request.Type;
            request.Reason = alexaRequest.Request.Reason;
            //request.SlotsList = alexaRequest.Request.Intent.GetSlots();
            request.DateCreated = DateTime.UtcNow;

            switch (request.Type)
            {
                case "LaunchRequest":
                    response = LaunchRequestHandler(request);
                    break;
                case "IntentRequest":
                    response = IntentRequestHandler(request);
                    break;
                case "SessionEndedRequest":
                    response = SessionEndedRequestHandler(request);
                    break;
            }

            return response;
        }

        private AlexaResponse LaunchRequestHandler(Request request)
        {
            var response = new AlexaResponse("Welcome to Napolina. What would you like to do, add a new Word, search for a word or cancel a word?");
            response.Session.MemberId = request.MemberId;
            response.Response.Card.Title = "Napolina";
            response.Response.Card.Content = "Hello\nNapolina!";
            response.Response.Reprompt.OutputSpeech.Text = "Please pick one, Add, Search or Delete Word?";
            response.Response.ShouldEndSession = false;

            return response;
        }

        private AlexaResponse IntentRequestHandler(Request request)
        {
            AlexaResponse response = null;

            switch (request.Intent)
            {
                case "NewWordIntent":
                    response = NewWordIntentHandler(request);
                    break;
                case "SearchWordIntent":
                    response = SearchWordIntentHandler(request);

                    break;
                case "AMAZON.CancelIntent":
                case "AMAZON.StopIntent":
                    response = CancelOrStopIntentHandler(request);
                    break;
                case "AMAZON.HelpIntent":
                    response = HelpIntent(request);
                    break;
            }

            return response;
        }

        private AlexaResponse NewWordIntentHandler(Request request)
        {
            var output = new StringBuilder("OK, which english word would you like to add?");

            return new AlexaResponse(output.ToString(), false);
        }

        private AlexaResponse SearchWordIntentHandler(Request request)
        {
            var output = new StringBuilder("Ok, which english word you would like to search?");

            return new AlexaResponse(output.ToString(), false);
        }

        private AlexaResponse HelpIntent(Request request)
        {
            var response = new AlexaResponse("To use the Napolina skill, you can say, Alexa, ask Napolina for search, add or cancel words. You can also say, Alexa, stop or Alexa, cancel, at any time to exit the Napolina skill. For now, do you want to add, search or cancel a word?", false);
            response.Response.Reprompt.OutputSpeech.Text = "Please pick one, Add, New or Cancel?";
            return response;
        }

        private AlexaResponse CancelOrStopIntentHandler(Request request)
        {
            return new AlexaResponse("Thanks for listening, let's talk again soon.", true);
        }

        private AlexaResponse SessionEndedRequestHandler(Request request)
        {
            return null;
        }
    }
}
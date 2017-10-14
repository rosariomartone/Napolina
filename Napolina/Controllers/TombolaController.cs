using Napolina.Data;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Web.Http;

namespace Napolina.Controllers
{
    public class TombolaController : ApiController
    {
        [HttpPost, Route("api/alexa/tombolina")]
        public dynamic Tombolina(AlexaRequest alexaRequest)
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
            request.SlotsList = alexaRequest.Request.Intent.GetSlots();
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

        private Hashtable getTombola()
        {
            Hashtable tombola = new Hashtable();
            tombola.Add(1, "Italy");
            tombola.Add(2, "A criatura");
            tombola.Add(3, "A jatta");
            tombola.Add(4, "O puork");
            tombola.Add(5, "A mano");
            tombola.Add(6, "Chella che guarda nterra");
            tombola.Add(7, "A scuppetta");
            tombola.Add(8, "A maronna");
            tombola.Add(9, "A figliata");
            tombola.Add(10, "E fasule");
            tombola.Add(11, "E surice");
            tombola.Add(12, "E surdate");
            tombola.Add(13, "Sant'Antonio");
            tombola.Add(14, "O mbriaco");
            tombola.Add(15, "O guaglione");
            tombola.Add(16, "O culo");
            tombola.Add(17, "A disgrazia");
            tombola.Add(18, "O sanghe");
            tombola.Add(19, "A risa");
            tombola.Add(20, "A festa");
            tombola.Add(21, "A femmena annura");
            tombola.Add(22, "O pazze");
            tombola.Add(23, "O scem");
            tombola.Add(24, "E guardie");
            tombola.Add(25, "Natale");
            tombola.Add(26, "Nanninella");
            tombola.Add(27, "O cantero");
            tombola.Add(28, "E zizze");
            tombola.Add(29, "O patre re criature");
            tombola.Add(30, "E palle ro tenente");
            tombola.Add(31, "O patrone e cas");
            tombola.Add(32, "O capitone");
            tombola.Add(33, "L'anne e Criste");
            tombola.Add(34, "A capa");
            tombola.Add(35, "L'uccellino cippi cippi");
            tombola.Add(36, "E castagnelle");
            tombola.Add(37, "Italy");
            tombola.Add(38, "Italy");
            tombola.Add(39, "Italy");
            tombola.Add(40, "Italy");
            tombola.Add(41, "Italy");
            tombola.Add(42, "Italy");
            tombola.Add(43, "Italy");
            tombola.Add(44, "Italy");
            tombola.Add(45, "Italy");
            tombola.Add(46, "Italy");
            tombola.Add(47, "Italy");
            tombola.Add(48, "Italy");
            tombola.Add(49, "Italy");
            tombola.Add(50, "Italy");
            tombola.Add(51, "Italy");
            tombola.Add(52, "Italy");
            tombola.Add(53, "Italy");
            tombola.Add(54, "Italy");
            tombola.Add(55, "Italy");
            tombola.Add(56, "Italy");
            tombola.Add(57, "Italy");
            tombola.Add(58, "Italy");
            tombola.Add(59, "Italy");
            tombola.Add(60, "Italy");
            tombola.Add(61, "Italy");
            tombola.Add(62, "Italy");
            tombola.Add(63, "Italy");
            tombola.Add(64, "Italy");
            tombola.Add(65, "Italy");
            tombola.Add(66, "Italy");
            tombola.Add(67, "Italy");
            tombola.Add(68, "Italy");
            tombola.Add(69, "Italy");
            tombola.Add(70, "Italy");
            tombola.Add(71, "Italy");
            tombola.Add(72, "Italy");
            tombola.Add(73, "Italy");
            tombola.Add(74, "Italy");
            tombola.Add(75, "Italy");
            tombola.Add(76, "Italy");
            tombola.Add(77, "Italy");
            tombola.Add(78, "Italy");
            tombola.Add(79, "Italy");
            tombola.Add(80, "Italy");
            tombola.Add(81, "Italy");
            tombola.Add(82, "Italy");
            tombola.Add(83, "Italy");
            tombola.Add(84, "Italy");
            tombola.Add(85, "Italy");
            tombola.Add(86, "Italy");
            tombola.Add(87, "Italy");
            tombola.Add(88, "Italy");
            tombola.Add(89, "Italy");
            tombola.Add(90, "Italy");

            return tombola;
        }

        private AlexaResponse LaunchRequestHandler(Request request)
        {
           var response = new AlexaResponse("Welcome to Tombola. Give me a number and I will translate it in napoletan classic Tombola");
            response.Session.MemberId = request.MemberId;
            response.Response.Card.Title = "Tombolina";
            response.Response.Card.Content = "Hello\nTombolina!";
            response.Response.Reprompt.OutputSpeech.Text = "Jamme, catch stu number!";
            response.Response.ShouldEndSession = false;

            return response;
        }

        private AlexaResponse IntentRequestHandler(Request request)
        {
            AlexaResponse response = null;

            switch (request.Intent)
            {
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

        private AlexaResponse SearchWordIntentHandler(Request request)
        {
            String slot = string.Empty;
            int number = 0;

            if (request.Slots != null)
                slot = request.Slots.Split(',')[0].Split('|')[1].ToString();

            if (!slot.Equals(string.Empty))
            {
                try
                {
                    number = int.Parse(slot);
                }
                catch(Exception ex)
                {
                    number = 0;
                }
            }

            Hashtable tombola = getTombola();

            AlexaResponse response = new AlexaResponse();

            if (number > 0 && number < 91)
                response = new AlexaResponse(tombola[number].ToString(), false);
            else
                response = new AlexaResponse("Uffff, o nummer adda esser tra un e nuant!", false);

            response.Response.Reprompt.OutputSpeech.Text = "Jamme, catch stu number!";

            return response;
        }

        private AlexaResponse HelpIntent(Request request)
        {
            var response = new AlexaResponse("To use the Tombolina skill, you can say, Alexa, ask Tombolina for play. You can also say, Alexa, stop or Alexa, cancel, at any time to exit the Tombolina skill. For now, which number did you extract?", false);
            response.Response.Reprompt.OutputSpeech.Text = "Jamme, catch stu number!";
            return response;
        }

        private AlexaResponse CancelOrStopIntentHandler(Request request)
        {
            return new AlexaResponse("Thanks for listening, let's talk again soon.", true);
        }

        private AlexaResponse SessionEndedRequestHandler(Request request)
        {
            return new AlexaResponse("Session ending, bye!", true);
        }
    }
}

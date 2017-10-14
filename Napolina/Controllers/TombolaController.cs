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
            tombola.Add(37, "O monaco");
            tombola.Add(38, "E mazzate");
            tombola.Add(39, "A funa nganna");
            tombola.Add(40, "A paposcia");
            tombola.Add(41, "O curtiello");
            tombola.Add(42, "O cafe");
            tombola.Add(43, "A femmen ngopp o balcon");
            tombola.Add(44, "E ccancelle");
            tombola.Add(45, "O vino");
            tombola.Add(46, "E denare");
            tombola.Add(47, "O muorto");
            tombola.Add(48, "O muorto che parla");
            tombola.Add(49, "O piezze e carne");
            tombola.Add(50, "O pane");
            tombola.Add(51, "O ciardino");
            tombola.Add(52, "A mamma");
            tombola.Add(53, "O viecchio");
            tombola.Add(54, "O cappiello");
            tombola.Add(55, "A museca");
            tombola.Add(56, "A caruta");
            tombola.Add(57, "O scartellato");
            tombola.Add(58, "O paccotto");
            tombola.Add(59, "E pile");
            tombola.Add(60, "E s lamenta");
            tombola.Add(61, "O cacciatore");
            tombola.Add(62, "O muorte accise");
            tombola.Add(63, "A sposa");
            tombola.Add(64, "A sciammeria");
            tombola.Add(65, "O chianto");
            tombola.Add(66, "E doje zitelle");
            tombola.Add(67, "O totano int a chitarra");
            tombola.Add(68, "A zuppa cotta");
            tombola.Add(69, "Sotte e ngoppe");
            tombola.Add(70, "O palazzo");
            tombola.Add(71, "L'omme e merda");
            tombola.Add(72, "A meraviglia");
            tombola.Add(73, "O spitale");
            tombola.Add(74, "A rotta");
            tombola.Add(75, "Pullecenella");
            tombola.Add(76, "A funtana");
            tombola.Add(77, "E diavule");
            tombola.Add(78, "A bella figliola");
            tombola.Add(79, "O mariouolo");
            tombola.Add(80, "A vocca");
            tombola.Add(81, "E ciure");
            tombola.Add(82, "A tavula mbandita");
            tombola.Add(83, "O maletiempo");
            tombola.Add(84, "A chiesa");
            tombola.Add(85, "L'anema ro priatorie");
            tombola.Add(86, "A puteca");
            tombola.Add(87, "E perucchie");
            tombola.Add(88, "E casecavalle");
            tombola.Add(89, "A vecchia");
            tombola.Add(90, "A paura");

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
                response = new AlexaResponse("Stupid, o nummer deve sta tra uno e nuvant!", false);

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

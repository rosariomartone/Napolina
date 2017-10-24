using Napolina.Data;
using System;
using System.Collections;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace Napolina.Controllers
{
    public class TombolaController : ApiController
    {
        [HttpPost, Route("api/alexa/tombolina")]
        public dynamic Tombolina(AlexaRequest alexaRequest)
        {
            AlexaResponse response = null;

            var speechlet = new SessionSpeechLet();
            HttpResponseMessage check = null;

            try
            {
                check = speechlet.GetResponse(Request);
            }
            catch (Exception ex)
            {
                check = new HttpResponseMessage(HttpStatusCode.Conflict);
            }

            if (check.StatusCode.Equals(HttpStatusCode.OK))
            {
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
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        private Hashtable getTombola()
        {
            Hashtable tombola = new Hashtable();
            tombola.Add(1, "Italia. Italy.");
            tombola.Add(2, "A criatura. The child.");
            tombola.Add(3, "A jatta. The cat.");
            tombola.Add(4, "O puork. The pig.");
            tombola.Add(5, "A mano. The hand.");
            tombola.Add(6, "Chella che guarda nterra. The cunt.");
            tombola.Add(7, "O vasetto. The pot.");
            tombola.Add(8, "A maronna. Our lady.");
            tombola.Add(9, "A figliata. The farrow.");
            tombola.Add(10, "E fasule. Beans.");
            tombola.Add(11, "E surice. Rats.");
            tombola.Add(12, "E surdate. Soldiers.");
            tombola.Add(13, "Sant'Antonio. Saint Antony.");
            tombola.Add(14, "O mbriaco. The drunk.");
            tombola.Add(15, "O guaglione. The little boy.");
            tombola.Add(16, "O culo. The bottom.");
            tombola.Add(17, "A disgrazia. The bad luck.");
            tombola.Add(18, "O sanghe. The blood.");
            tombola.Add(19, "A risa. The laughter.");
            tombola.Add(20, "A festa. The party.");
            tombola.Add(21, "A femmena annura. The naked woman.");
            tombola.Add(22, "O puz. The mad man.");
            tombola.Add(23, "O shem. The stupid man.");
            tombola.Add(24, "E guardie. The guards.");
            tombola.Add(25, "Natale. Christmas");
            tombola.Add(26, "Nanninella. Little Annie.");
            tombola.Add(27, "O cantero. Jerry.");
            tombola.Add(28, "E zizze. Tits.");
            tombola.Add(29, "O patre re criature. Cock.");
            tombola.Add(30, "E palle ro tenente. The lieautenat's testicols.");
            tombola.Add(31, "O patrone e cas. The landlord.");
            tombola.Add(32, "O capitone. The big headed.");
            tombola.Add(33, "L'anne e Criste. Christ's age.");
            tombola.Add(34, "A capa. The head.");
            tombola.Add(35, "L'uccellino cippi cippi. The bird.");
            tombola.Add(36, "E castagnelle. Chestnuts.");
            tombola.Add(37, "O monaco. The monk.");
            tombola.Add(38, "E mazzate. The blows.");
            tombola.Add(39, "A funa nganna. At gun point.");
            tombola.Add(40, "A paposcia. The scrotum.");
            tombola.Add(41, "O curtiello. The knife.");
            tombola.Add(42, "O cafe. Coffee.");
            tombola.Add(43, "Onna pereta ngopp o balcon. Onna pereta on her balcony.");
            tombola.Add(44, "E ccancelle. The gates.");
            tombola.Add(45, "O vino. Wine.");
            tombola.Add(46, "E denare. Money.");
            tombola.Add(47, "O muorto. The dead man.");
            tombola.Add(48, "O muorto che parla. The talking dad man.");
            tombola.Add(49, "O piezze e carne. The meat piece.");
            tombola.Add(50, "O pane. Bread.");
            tombola.Add(51, "O ciardino. The garden.");
            tombola.Add(52, "A mamma. The mum.");
            tombola.Add(53, "O viecchio. The old man.");
            tombola.Add(54, "O cappiello. The hat.");
            tombola.Add(55, "A museca. Music.");
            tombola.Add(56, "A caruta. The fall.");
            tombola.Add(57, "O scartellato. The hump man.");
            tombola.Add(58, "O paccotto. Bundle.");
            tombola.Add(59, "E pile. The hair.");
            tombola.Add(60, "E s lamenta. The complain.");
            tombola.Add(61, "O cacciatore. The huntman.");
            tombola.Add(62, "O muorte accise. The murdered man.");
            tombola.Add(63, "A sposa. The bride.");
            tombola.Add(64, "A sciammeria. The gentleman.");
            tombola.Add(65, "O chianto. The cry.");
            tombola.Add(66, "E doje zitelle. Two unmarried ladies.");
            tombola.Add(67, "O totano int a chitarra. The totes in the guitar.");
            tombola.Add(68, "A zuppa cotta. The soup.");
            tombola.Add(69, "Sotte e ngoppe. Upside down.");
            tombola.Add(70, "O palazzo. The building.");
            tombola.Add(71, "L'omme e merda. The shit man.");
            tombola.Add(72, "A meraviglia. Astonishment.");
            tombola.Add(73, "O spitale. The hospital.");
            tombola.Add(74, "A rotta. The cave.");
            tombola.Add(75, "Pullecenella");
            tombola.Add(76, "A funtana. The fountain.");
            tombola.Add(77, "E diavule. Devils.");
            tombola.Add(78, "A bella figliola. The bitch.");
            tombola.Add(79, "O mariouolo. The thief.");
            tombola.Add(80, "A vocca. The mouth.");
            tombola.Add(81, "E ciure. Flowers.");
            tombola.Add(82, "A tavula mbandita. The upholstered table.");
            tombola.Add(83, "O maletiempo. Bad weather.");
            tombola.Add(84, "A chiesa. The church.");
            tombola.Add(85, "L'anema ro priatorie. The soul in purgatory.");
            tombola.Add(86, "A puteca. Delicatessen.");
            tombola.Add(87, "E perucchie. Lice.");
            tombola.Add(88, "E casecavalle. The chese.");
            tombola.Add(89, "A vecchia. The old lady.");
            tombola.Add(90, "A paura. Fear.");

            return tombola;
        }

        private AlexaResponse LaunchRequestHandler(Request request)
        {
           var response = new AlexaResponse("Welcome to Tombola Naples. Give me a number and I will translate it in napoletan classic Tombola");
            response.Session.MemberId = request.MemberId;
            response.Response.Card.Title = "Tombola Naples";
            response.Response.Card.Content = "Hello\nTombola Nales!";
            response.Response.Reprompt.OutputSpeech.Text = "Come on, give me a number!";
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
                response = new AlexaResponse(tombola[number].ToString() + ". Give me another number please", false);
            else
                response = new AlexaResponse("Hey, number must be between 1 and 90!", false);

            response.Response.Reprompt.OutputSpeech.Text = "Come on, give me a number!";

            return response;
        }

        private AlexaResponse HelpIntent(Request request)
        {
            var response = new AlexaResponse("To use the Tombola Naples skill, you just need to say a " +
                "number between 1 and 90. You can also say, Alexa, stop or Alexa, cancel, at any " +
                "time to exit the Tombola Naples skill. For now, which number did you extract?", false);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using marketplace_microservice_backend.BussinessLayer;
using marketplace_microservice_backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Json.Net;
using ProfloPortalBackend.Model;

namespace marketplace_microservice_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
       
        private readonly IIssueservice service;
        private string strModified;

        public IssueController(IIssueservice issueService)
        {
            service = issueService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAllIssues()
        {
            try
            {
                return Ok(service.GetAllIssues());
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            try
            {

                return Ok(service.GetIssuesById(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                string Username = user.UName;
                string Token = user.UToken;
                string Repositatory = user.Urepository;
                string TeamId = user.TeamId;

                byte[] byt = System.Text.Encoding.UTF8.GetBytes(Token);

                // convert the byte array to a Base64 string

                strModified = Convert.ToBase64String(byt);

                var client = new RestClient("https://api.github.com/repos");
                var request = new RestRequest($"/{Username}/{Repositatory}/issues", Method.GET);

                // Add HTTP headers
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("authorization", "Basic " + strModified);

                //var contributors = client.Execute<List<MyGitHub>>(request);

                IRestResponse response = client.Execute(request);
                //Console.WriteLine(response.Content);
                //var result= service.GetAllIssues(response.Content);
                var boardCreator = new Board()
                {
                    TeamId = user.TeamId,
                    BoardName = user.Urepository
                };
                service.CreateBoard(boardCreator);

                object list = JsonConvert.DeserializeObject(response.Content);
                dynamic _d = JsonConvert.DeserializeObject(response.Content);
                Console.WriteLine(_d.Count);
                List<Issues> issuesList = new List<Issues>();
                foreach (var _dItem in _d)
                {
                    Issues _issue = new Issues();
                    _issue.body = _dItem.body;
                    _issue.title = _dItem.title;
                    string[] _issueLabels = new string[_dItem.labels.Count];
                    for (int i = 0; i < _issueLabels.Length; i++)
                    {
                        _issueLabels[i] = _dItem.labels[i].name;

                        //list creation
                        //var listCreator = new List()
                        //{
                        //    ListTitle = _issueLabels[i]


                        //};
                        //service.CreateList(listCreator);

                        ////card creation
                        //var cardCreator = new Card()
                        //{
                        //    CardTitle = _issue.title,
                        //    description = _issue.body
                        //};
                        //service.CreateCard(cardCreator);




                    }
                    _issue.labelNames = _issueLabels;
                    issuesList.Add(_issue);
                    service.AddIssuesToDb(_issue);

                    
                }



                Console.WriteLine(issuesList.Count);
                return Ok(issuesList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return NotFound("error in converting to json");
            }

        }

        // POST api/profloslack
        //[HttpGet("issues")]
        //public async Task<IActionResult> PostCard([FromRoute]Issues issues)
        //{
        //    // Console.WriteLine(card.CardTitle);
        //    var cardCreation = new Card()
        //    {
        //        CardTitle = issues.title,
        //        description = issues.body
        //    };
        //    await service.CreateCard(cardCreation);
        //    return Ok("Created Card");
        //}
        #region Excess
        //public IRestResponse<List<User>>  AuthenticateUser(User user)
        //{
        //    var Token = user.UToken;
        //    var client = new RestClient("https://api.github.com");
        //    var request = new RestRequest("pushpendrakushwaha/MySecanarios", Method.GET);

        //    // Add HTTP headers
        //    request.AddHeader("User-Agent", "Nothing");
        //    //request.AddHeader("postman-token", "d096c034-4b88-bc0d-af5a-17a2ab474188");

        //    //request.AddHeader("cache-control", "no-cache");
        //    //request.AddHeader("authorization", "Basic " + Token);


        //    var contributors = client.Execute<List<User>>(request);
        //    return contributors;
        //}

        //internal class Contributor
        //{
        //    public string Login { get; set; }
        //    public short Contributions { get; set; }

        //    public override string ToString()
        //    {
        //        return $"{Login,20}: {Contributions} contributions";
        //    }
        //}

        //internal class Program
        //{
        //    private static void Main()
        //    {
        //        var client = new RestClient("https://api.github.com");

        //        var request = new RestRequest("repos/twilio/twilio-csharp/contributors", Method.GET);
        //        // Add HTTP headers
        //        request.AddHeader("User-Agent", "Nothing");

        //        // Execute the request and automatically deserialize the result.
        //        var contributors = client.Execute<List<Contributor>>(request);
        //        contributors.Data.ForEach(Console.WriteLine);

        //        Console.ReadLine();
        //    }
        //}
        #endregion
    }
}
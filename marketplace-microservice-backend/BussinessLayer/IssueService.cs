using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marketplace_microservice_backend.DataAccess;
using marketplace_microservice_backend.Entity;
using RestSharp;
using System.Net.Http;
using Newtonsoft.Json;
using ProfloPortalBackend.Model;

namespace marketplace_microservice_backend.BussinessLayer
{
    public class IssueService : IIssueservice
    {
        private readonly IIssueRepository Repository;
        private readonly HttpClient httpClient;
        public IssueService(IIssueRepository issueRepository)
        {
            Repository = issueRepository;
            this.httpClient = new HttpClient();
        }

        public List<Issues> GetAllIssues()
        {
            return Repository.GetAllIssues();
        }

        public Issues GetIssuesById(string id)
        {
            return Repository.GetIssuesById(id);
        }

        public User RegisterGitHub(User user)
        {
            var result = Repository.RegisterHub(user);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new UserNotFoundException("User Not Found");
            };
        }
        public void AddIssuesToDb(Issues issue)
        {
            Repository.AddIssuesToDb(issue);
        }

        public async Task<List> CreateList(List list)
        {
            var response = await this.httpClient.PostAsJsonAsync<List>($"http://core-api.proflo.cgi-wave7.stackroute.io/api/lists", list);
            var createListString = (await response.Content.ReadAsStringAsync());
            var createList = JsonConvert.DeserializeObject<List>(createListString);
            return createList;

        }

        public async Task<Board> CreateBoard(Board board)
        {
            if(board.BoardMembers == null)
           {
                board.BoardMembers = new List<Member>();
            }
            if (board.BoardInvites == null)
            {
                board.BoardInvites = new List<Invitee>();
            }
            //if (board.BoardLists == null)
            //{
            //    board.BoardLists = new List<List>();
            //}

            var response = await this.httpClient.PostAsJsonAsync<Board>($"http://core-api.proflo.cgi-wave7.stackroute.io/api/boards", board);
            var createBoardString = (await response.Content.ReadAsStringAsync());
            var createBoard = JsonConvert.DeserializeObject<Board>(createBoardString);
            return createBoard;

        }




        public async Task<Card> CreateCard(Card card)
        {
            if (card.Assignees == null)
            {
                card.Assignees = new List<Member>();
            }
            if (card.Labels == null)
            {
                card.Labels = new List<Label>();
            }
            if (card.Attachments == null)
            {
                card.Attachments = new List<Attachment>();
            }
            if (card.Comments == null)
            {
                card.Comments = new List<Comment>();
            }
            if (card.CardInvites == null)
            {
                card.CardInvites = new List<Invitee>();
            }
            var response = await this.httpClient.PostAsJsonAsync<Card>($"http://core-api.proflo.cgi-wave7.stackroute.io/api/cards", card);
            var createCardString = (await response.Content.ReadAsStringAsync());
            var createCard = JsonConvert.DeserializeObject<Card>(createCardString);
            return createCard;
        }
    }
}

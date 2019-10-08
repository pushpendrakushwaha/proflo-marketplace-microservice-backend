using marketplace_microservice_backend.Entity;
using ProfloPortalBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace_microservice_backend.BussinessLayer
{
    public interface IIssueservice
    {
        Issues GetIssuesById(string id);
        List<Issues> GetAllIssues();
        User RegisterGitHub(User user);
        void AddIssuesToDb(Issues issue);
       // Task<Card> CreateCard(Card card);
        Task<Board> CreateBoard(Board board);
        //Task<List> CreateList(List list);

    }
}

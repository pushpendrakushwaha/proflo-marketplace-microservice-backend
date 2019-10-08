using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marketplace_microservice_backend.Entity;
using MongoDB.Driver;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace marketplace_microservice_backend.DataAccess
{
    public class IssueRepository:IIssueRepository
    {
        private readonly AllDbContext context;
        public IssueRepository(AllDbContext allDbContext)
        {
            context = allDbContext;
        }

        public List<Issues> GetAllIssues()
        {
            return context.Issues.Find(_=>true).ToList();
        }

        public Issues GetIssuesById(string id)
        {
            return context.Issues.Find(i => i.id == id).SingleOrDefault();
        }

        public User RegisterHub(User user)
        {
            context.User.InsertOne(user);
            return user;
        }
        public void AddIssuesToDb(Issues issue) 
        {
            context.Issues.InsertOne(issue);
        }
    }
}

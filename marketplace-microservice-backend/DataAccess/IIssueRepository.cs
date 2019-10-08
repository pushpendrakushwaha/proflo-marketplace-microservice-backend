using marketplace_microservice_backend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace_microservice_backend.DataAccess
{
    public interface IIssueRepository
    {
        Issues GetIssuesById(string id);
        List<Issues> GetAllIssues();
        User RegisterHub(User user);
        void AddIssuesToDb(Issues issue);
    }
}

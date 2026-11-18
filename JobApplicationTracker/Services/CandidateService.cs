using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Services
{
    public class CandidateService
    {
        private DataStore<Candidate> candidatelist;
        private HashSet<string> emails = [];
        public CandidateService(DataStore<Candidate> c) { candidatelist = c; }

        public string Add(Candidate com)
        {
            if (candidatelist.GetById(com.Id) != null)
            {
                return "Id must be uniqe";
            }
            else if (emails.Contains(com.Email))
            {
                return "Email must be uniqe";
            }
            
                candidatelist.Add(com);
                emails.Add(com.Email);
                return "Add Successfully";
            
        }

        public bool Remove(int id)

        {
            Candidate? c = candidatelist.GetById(id);
            if (c != null)
            {
                emails.Remove(c.Email);
                candidatelist.Remove(c);
                return true;
            }
            else
            {
                return false;
            }
        }
        public string Update(int id, Candidate can)
        {
            Candidate? c = candidatelist.GetById(id);
            if (c == null)
            {
                return "Invaild Id , Candidate not found !";
            }
            else if (c.Email != can.Email && emails.Contains(can.Email))
            {
                return "Email must be uniqe";
            }
            emails.Remove(c.Email);
            emails.Add(can.Email);
            candidatelist.Update(c , can);
            return "remore Successfully";

        }

        public List<Candidate> GetAll() { return candidatelist.GetAll; }

        public Candidate? GetById(int id)
        {
            return candidatelist.GetById(id);
        }

    }
}

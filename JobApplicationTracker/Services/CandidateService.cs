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
        public CandidateService(DataStore<Candidate> c) { candidatelist = c; }

        public bool Add(Candidate com)
        {
            if (candidatelist.GetById(com.Id) != null)
            {
                return false;
            }
            else
            {
                candidatelist.Add(com);
                return true;
            }
        }

        public bool Remove(int id)

        {
            Candidate? c = candidatelist.GetById(id);
            if (c != null)
            {
                candidatelist.Remove(c);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(int id, Candidate can)
        {
            Candidate? c = candidatelist.GetById(id);
            bool retrn = false;

            if (c != null && id == can.Id)
            {
                retrn = candidatelist.Update(c, can);
            }

            return retrn;
        }

        public List<Candidate> GetAll() { return candidatelist.GetAll; }

        public Candidate? GetById(int id)
        {
            return candidatelist.GetById(id);
        }

    }
}

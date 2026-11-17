using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Services
{
    public class RecruiterService
    {

        private DataStore<Recruiter> Recruiterlist;
        public RecruiterService(DataStore<Recruiter> c) { Recruiterlist = c; }

        public bool Add(Recruiter rec)
        {
            if (Recruiterlist.GetById(rec.Id) != null)
            {
                return false;
            }
            else
            {
                Recruiterlist.Add(rec);
                return true;
            }
        }

        public bool Remove(int id)

        {
            Recruiter? r = Recruiterlist.GetById(id);
            if (r != null)
            {
                Recruiterlist.Remove(r);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Recruiter> GetAll() { return Recruiterlist.GetAll; }

    }
}

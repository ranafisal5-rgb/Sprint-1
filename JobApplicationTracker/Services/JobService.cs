using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Services
{
    public class JobService
    {
        private DataStore<Job> joblist;
        public JobService(DataStore<Job> j) { joblist = j; }

        Dictionary<int,Job> jobbyId = [];

        public bool Add(Job j)
        {
            if(joblist.GetById(j.Id) != null)
            {
                return false;
            }
            else
            {
                joblist.Add(j);
                jobbyId.Add(j.Id, j);
                return true;
            }
        }

        public bool remove(int id)
        {
            Job x = joblist.GetById(id);
            if ( x != null )
            {
                joblist.Remove(x);
                jobbyId.Remove(x.Id);
                return true;
            }
            else
            {
                return false;
            }


        }

        public List<Job> GetAll() { return joblist.GetAll; }

      








    }
}

using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Services
{
    public class JobService
    {
        private DataStore<Job> joblist;
        private DataStore<Company> companiylist;
        private DataStore<Recruiter> recruiterlist;
        public JobService(DataStore<Job> j , DataStore<Company> c , DataStore<Recruiter> r) { joblist = j; companiylist = c; recruiterlist = r; }

        Dictionary<int,Job> jobbyId = [];

        public string Add(Job j)
        {
            if(joblist.GetById(j.Id) != null)
            {
                return "Id must be uniqe";
            }
            else if(companiylist.GetById(j.CompanyId) == null)
            {
                return "Company Id Not Found";
            }
            else if(recruiterlist.GetById(j.RecruiterId) == null)
            {
                return "Recruiter Id Not Found";
            }
            else if(companiylist.GetById(j.CompanyId).Status != Company_Status.Approved )
            {
                return "Pending / Rejected company cannot add jobs.";
            }
            else
            {
                joblist.Add(j);
                jobbyId.Add(j.Id, j);
                return "Add Successfully";
            }
        }


        public string Update(int id, Job jb)
        {
            Job? j = joblist.GetById(id);
            if (j == null || id != jb.Id )
            {
                return "Invaild Id , Job not found !";
            }
            Company? c = companiylist.GetById(jb.CompanyId);

            if ( c == null)
            {
                return "Company Id Not Found";
            }
             if (recruiterlist.GetById(jb.RecruiterId) == null)
            {
                return "Recruiter Id Not Found";
            }
             if (c.Status != Company_Status.Approved)
            {
                return "Pending / Rejected company cannot add jobs.";
            }

            j.Title = jb.Title;
            j.Salary = jb.Salary;
            j.Location = jb.Location;
            j.RecruiterId = jb.RecruiterId;
            j.CompanyId = jb.CompanyId;
            j.Description = jb.Description;
            return "Update Successfully";

        }


        public bool remove(int id)
        {
            Job? x = joblist.GetById(id);
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

        public Job? job_by_Id(int id)
        {
                
            jobbyId.TryGetValue(id, out Job? j);
            return j;


        }

    }
}

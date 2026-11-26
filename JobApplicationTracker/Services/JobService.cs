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

        private DataStore<Application> applicationlist;
        public JobService(DataStore<Job> j, DataStore<Company> c, DataStore<Recruiter> r , DataStore<Application> app) { joblist = j; companiylist = c; recruiterlist = r; applicationlist = app; }

        Dictionary<int, Job> jobbyId = [];

        public string Add(Job j)
        {
            if (joblist.GetById(j.Id) != null)
            {
                return "Id must be uniqe";
            }
            else if (companiylist.GetById(j.CompanyId) == null)
            {
                return "Company Id Not Found";
            }
            else if (recruiterlist.GetById(j.RecruiterId) == null)
            {
                return "Recruiter Id Not Found";
            }
            else if (companiylist.GetById(j.CompanyId).Status != Company_Status.Approved)
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
            if (j == null || id != jb.Id)
            {
                return "Invaild Id , Job not found !";
            }
            Company? c = companiylist.GetById(jb.CompanyId);

            if (c == null)
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
            if (x != null)
            {
              if(!jobfoundinapplication(id))
                { joblist.Remove(x);
                jobbyId.Remove(x.Id);
                return true; }

            }
             return false;
        }

        public bool jobfoundinapplication(int jobid)
        {
            foreach (var i in applicationlist)
            {
                if (i.JobId == jobid)
                    return true;
            }
            return false;
        }


        public List<Job> GetAll() { return joblist.GetAll; }

        public Job? job_by_Id(int id)
        {

            jobbyId.TryGetValue(id, out Job? j);
            return j;


        }

        public List<Job> SearchByTitle(string keyword)
        {
            List<Job> res = [];
            res = joblist.Find(a => a.Title.Contains(keyword));
            return res;
        }
        public List<Job> SearchByMinimumSalary(decimal minsalary)
        {
            List<Job> res = [];
            res = joblist.Find(a => a.Salary >= minsalary);
            return res;

        }

        public List<Job> SearchJobs(string keyword, decimal minsalary)
        {
            List<Job> res = [];
            res = joblist.Find(a => a.Salary >= minsalary && a.Title.Contains(keyword));
            return res;

        }

        public List<Job> SortBySalary(bool type) // asc => true - des => false
        {
            List<Job> res = [] ;
            foreach (var item in joblist)
            {
                res.Add(item);
            }
            if (type)
            res.Sort((a,b)=> a.Salary.CompareTo(b.Salary));
            else
            res.Sort((a, b) => b.Salary.CompareTo(a.Salary));

            return res;
        }

        public List<Job> SortByTitle()
        {
            List<Job> res = [];
            foreach (var item in joblist)
            {
                res.Add(item);
            }
            res.Sort((a, b) => string.Compare(a.Title, b.Title, StringComparison.OrdinalIgnoreCase));
           
            return res;
        }










    }
}

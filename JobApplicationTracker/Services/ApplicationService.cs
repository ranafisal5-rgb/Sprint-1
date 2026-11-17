using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Services
{
    public class ApplicationService
    {
        private static int index = 1;
        private DataStore<Application> Applicationlist;
        private CandidateService candidate;
        private JobService Job;
        private CompanyService company;
        private HashSet<(int jobid, int candidateid)> jobcand = [];

        public ApplicationService(DataStore<Application> app , CandidateService can , JobService J , CompanyService com) { Applicationlist = app; candidate = can; company = com; Job = J; }
        
        public string Apply_to_job(int idjob , int idcand)
        {
           Job? j = Job.job_by_Id(idjob);
           Candidate? can = candidate.GetById(idcand);

            if (j == null )
            {
                return " Job not found";
            }
            if ( can == null)
            {
                return "Candidate not found ";
            }
            if (j.IsOpen == false)
            {
                return "Job is closed";
            }

            Company? com = company.GetById(j.CompanyId);

             if ( com == null || com.Status != Company_Status.Approved )
            {
                return "Company is not approved or not found";
            }
            if (jobcand.Contains((idjob,idcand)))
            {
                return "Candidate already applied";
            }
         
                Application app = new Application() { Id = index++, CandidateId = idcand, JobId = idjob, Status = Application_Status.Submitted, AppliedDate = DateTime.Now };
                Applicationlist.Add(app);
                jobcand.Add((idjob, idcand));
                return "Application submitted successfully";
            



        }



        public bool Remove(int id)

        {
            Application? c = Applicationlist.GetById(id);
            if (c != null)
            {
                Applicationlist.Remove(c);
                jobcand.Remove((c.JobId , c.CandidateId ));
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Application> GetAll() { return Applicationlist.GetAll; }

    }

}

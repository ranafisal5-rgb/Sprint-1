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

        private DataStore<Company> companylist;
        public RecruiterService(DataStore<Recruiter> r , DataStore<Company> c ) { Recruiterlist = r; companylist = c; }

        public string Add(Recruiter rec)
        {
            if (Recruiterlist.GetById(rec.Id) != null )
            {
                return "Id must be uniqe";
            }
            else if(companylist.GetById(rec.CompanyId) == null)
            {
                return "Company Id Not Found";
            }
            else
            {
                Recruiterlist.Add(rec);
                return "Add Successfully";
            }
        }

        public string Update(int id, Recruiter rec)
        {
            Recruiter? r = Recruiterlist.GetById(id);
         
            if (r == null || id != rec.Id)
            {
                return "Invaild Id , Recruiter not found ! ";
            }
            else if(companylist.GetById(rec.CompanyId) == null)
            {
                return "Company Id Not Found";
            }
            else
            {
                Recruiterlist.Update(r , rec);
                return "Update Successfully";
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

        public void display()
        {
            foreach (var l in Recruiterlist)
            {
                l.Print();
                Console.WriteLine();
            }
        }

    }
}

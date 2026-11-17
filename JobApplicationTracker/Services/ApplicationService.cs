using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JobApplicationTracker.Services
{
    public class ApplicationService
    {
        private DataStore<Application> Applicationlist;
        public ApplicationService(DataStore<Application> c) { Applicationlist = c; }

        public bool Add(Application com)
        {
            if (Applicationlist.GetById(com.Id) != null)
            {
                return false;
            }
            else
            {
                Applicationlist.Add(com);
                return true;
            }
        }

        public bool Remove(int id)

        {
            Application c = Applicationlist.GetById(id);
            if (c != null)
            {
                Applicationlist.Remove(c);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(int id, Company comp)
        {


        }//dont know

        public List<Application> GetAll() { return Applicationlist.GetAll; }

    }
}

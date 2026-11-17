using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Services
{
    public class CompanyService 
    {

     private DataStore<Company> companylist;
     public CompanyService(DataStore<Company> c) { companylist = c; }

    public bool Add(Company com)
        {
            if(companylist.GetById(com.Id) != null)
            {
                return false; 
            }
            else
            { companylist.Add(com);
                return true; 
            }
        }

    public bool Remove(int id)

        {
            Company c = companylist.GetById(id);
            if(c != null)
            {
                companylist.Remove(c);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(int id , Company comp)
        {
            Company c = companylist.GetById(id);
             

            if (c != null)
            {
                companylist.Update(id , c);
                return true;
            }
            else
            {
                return false;
            }

        }//dont know

        public List<Company> GetAll() { return companylist.GetAll; }

        public bool Chang_Status(int id , Company_Status status)
        {

          Company c = companylist.GetById(id);
          
            if(c != null)
            {
              c.Status = status;
                return true;
            }
            else
            {
                return false;
            }       
        }

        public DataStore<Company> List_by_status(Company_Status status)
        {
            DataStore<Company> res = new DataStore<Company>();
        

            foreach(var i in companylist)
            {
                if(i.Status == status)
                {
                    res.Add(i);
                    
                }
               

            }
            return res;
            
        }










    }
}

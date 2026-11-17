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
     private Stack<(int id , Company_Status state)> undostatus = [];
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
            Company? c = companylist.GetById(id);
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
            Company? c = companylist.GetById(id);
            bool retrn = false;

            if (c != null && id == comp.Id  )
            {
                //  retrn = companylist.Update(c , comp);
                c.Name = comp.Name;
                c.City = comp.City;
                c.Industry = comp.Industry;
                 retrn = true;
            }

            return retrn;
        }

        public List<Company> GetAll() { return companylist.GetAll; }

        public Company? GetById(int id)
        {
            return companylist.GetById(id);
        }

        public bool Chang_Status(int id , Company_Status status)
        {

          Company? c = companylist.GetById(id);
          
            if(c != null)
            {
              undostatus.Push((c.Id , c.Status));
              c.Status = status;
                return true;
            }
            else
            {
                return false;
            }       
        }

        public string Undo ()
        {
            if(undostatus.Count > 0 )
            {
                (int idcompany, Company_Status stutes) = undostatus.Pop();
                Company? c = companylist.GetById(idcompany);
                if(c != null)
                {
                    c.Status = stutes;
                    return "Undo Is Done";

                }

                undostatus.Push((idcompany, stutes));
                return "Company Not Found";

            }
            else
            {
                return "No History Found !";
            }
        }

        public List<Company> List_by_status(Company_Status status)
        {
            DataStore<Company> res = new DataStore<Company>();
        

            foreach(var i in companylist)
            {
                if(i.Status == status)
                {
                    res.Add(i);
                    
                }
               

            }
            return res.ToList();
            
        }

        public void display()
        {
            foreach(var l in companylist)
            {
                l.print();
                Console.WriteLine();
            }
        }










    }
}

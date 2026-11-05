using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Models
{
    public class Job : IEntity
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public string Description { set; get; }

        private decimal salary; // above 0

        public decimal Salary { set {
                if (value >= 0)
                    salary = value;
                else throw new ArgumentOutOfRangeException(nameof(value), "Salary cannot be negative"); }
            get{ return salary; } } 

        public string Location { set; get; }

        public bool IsOpen { set; get; } // default true

        public DateTime PostedDate { set; get; }

        public int CompanyId { set; get; }

        public int RecruiterId { set; get; }

        public Job()
        {
            IsOpen = true;
        }


    }
}

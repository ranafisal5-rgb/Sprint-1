using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Models
{
    public enum Company_Status { Pending, Approved, Rejected }

    public class Company :IEntity
    {
        public int Id { set; get; } //unique

        public required string Name { set; get; } //required
        public string Industry { set; get; }

        public string City { set; get; }

        public Company_Status Status { set; get; }

        public Company()
        {
            Status = Company_Status.Pending;
        }

    }
}

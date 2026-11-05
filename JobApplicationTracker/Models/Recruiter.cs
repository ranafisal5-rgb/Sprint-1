using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace JobApplicationTracker.Models
{

    public class Recruiter : IEntity
    {
        public int Id { set; get; } //unique

        public required string Name { set; get; } //required
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (MailAddress.TryCreate(value, out _))

                { email = value; }
                else
                    throw new FormatException("Invalid email format");
            }
        }

        public int CompanyId { set; get; }

        




    }
}

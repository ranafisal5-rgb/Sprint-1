using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace JobApplicationTracker.Models
{
    public class Candidate : IEntity
    {
        public int Id { set; get; }
        public required string  FullName { set; get; }
        private string email;
        public string Email { get { return email; }
            set {
                if (MailAddress.TryCreate(value, out _))

                   { email = value; }
                else
                    throw new FormatException("Invalid email format");
            }  }

        public String Phone { set; get; }

        private int yearsOfExperience;
        public int YearsOfExperience
        {
            get { return yearsOfExperience; }
            set { if (value >= 0) yearsOfExperience = value; 
                else throw new ArgumentOutOfRangeException(nameof(value), "Years of experience cannot be negative"); }
        }



    }
}

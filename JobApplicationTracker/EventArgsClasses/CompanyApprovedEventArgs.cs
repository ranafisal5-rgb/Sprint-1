using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker
{
    public class CompanyApprovedEventArgs : EventArgs
    {
        public Company Company { get; }

        public CompanyApprovedEventArgs(Company company)
        {
            Company = company;
        }
    }
}

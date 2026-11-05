using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Models
{ 
    public interface IEntity
{
    int Id { set; get; }

}

   public enum Application_Status
    {
        Submitted, UnderReview, Interview, Accepted, Rejected
    } 



    public class Application : IEntity
    {
     public int Id { set; get; }

    public int JobId { set; get; }

     public int CandidateId { set; get; }

    public DateTime AppliedDate { set; get; }

    public Application_Status Status { set; get; }


    }
}

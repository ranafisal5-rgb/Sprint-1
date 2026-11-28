using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.EventArgsClasses
{
    public class ApplicationSubmittedEventAegs : EventArgs
    {
      public  Application application { get; }
      public  Job job { get; }
      public  Candidate candidate { get; }

        public ApplicationSubmittedEventAegs(Application app , Job j , Candidate c)
        {
            application = app;
            job = j;
            candidate = c;
        }


    }
}

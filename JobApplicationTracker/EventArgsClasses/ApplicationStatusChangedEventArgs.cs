using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.EventArgsClasses
{
    public class ApplicationStatusChangedEventArgs : EventArgs
    {
        public Application_Status oldstatus { get; }
        public Application_Status newstatus { get; }

        public ApplicationStatusChangedEventArgs(Application_Status old, Application_Status n)
        {
            oldstatus = old;
            newstatus = n;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Practice
{
    public class testargs : EventArgs
    {
        public int grade;
        public int passgrae;

        public int fullgrade;
        public testargs(int g, int p , int f)
        {
            grade = g; passgrae = p;fullgrade = f;
        }
    }
    public class stuent
    {
        public event EventHandler<testargs>? tests;
        public string name;

        public stuent(string s)
        {
            name = s;
        }

        public bool pass(int g, int p , int f)
        {
            testargs data = new testargs(g, p ,f);

            if (g >= p)
            {
                tests?.Invoke(this, data);
                return true;

            }
            return false;
        }




    }

}

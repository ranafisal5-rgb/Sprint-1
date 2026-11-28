using JobApplicationTracker.Data;
using JobApplicationTracker.EventArgsClasses;
using JobApplicationTracker.Models;
using JobApplicationTracker.Practice;
using JobApplicationTracker.Services;
using Microsoft.VisualBasic;
using System.Reflection.Metadata;

namespace JobApplicationTracker
{

    internal class Program
    {

       static void CompanyMenu(CompanyService companyService)
        {
            while(true)
            {
               
                Console.WriteLine("========== COMPANIES ==========\r\n1. Add Company\r\n2. Update Company\r\n3. Remove Company\r\n4. List All Companies\r\n5. Change Company Status\r\n6. List Companies By Status\r\n7. Undo Last Status Change\r\n8. Back");
                string ch = Console.ReadLine()??"";
                switch (ch)
                {
                    case "1":
                   {
                        Console.WriteLine("Inter Company ID");
                         int id;
                        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                        {
                          Console.WriteLine("Invalid ID. Please enter a number:");
                        }
                        Console.WriteLine("Inter Company Name");
                        string name = Console.ReadLine() ?? "";
                         while (string.IsNullOrWhiteSpace(name))
                         {
                           Console.WriteLine("Name is required. Please enter a valid name:");
                           name = Console.ReadLine() ?? "";
                          }
                         Console.WriteLine("Inter Company Ciry");
                        string city = Console.ReadLine()??"";
                        Console.WriteLine("Inter Company Indastry");
                        string indastry = Console.ReadLine()??"";
                        Company newcomp = new Company() {Id=id , Name = name , City = city , Industry = indastry };
                            if (companyService.Add(newcomp))
                            {
                                Console.WriteLine("add successfully");
                                companyService.display();

                            }
                            else
                                Console.WriteLine("id must be uniqe");
                        }
                            break;
                    case "2":
                        {
                            Console.WriteLine("Inter Company ID You Need To Update");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                            {
                                Console.WriteLine("Invalid ID. Please enter a number:");
                            }


                            Console.WriteLine("Inter New Company Name");
                            string name = Console.ReadLine() ?? "";
                            while (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Name is required. Please enter a valid name:");
                                name = Console.ReadLine() ?? "";
                            }
                            Console.WriteLine("Inter Company Ciry");
                            string city = Console.ReadLine() ?? "";
                            Console.WriteLine("Inter Company Indastry");
                            string indastry = Console.ReadLine() ?? "";
                            Company newcomp = new Company() { Id = id, Name = name, City = city, Industry = indastry };
                            if (companyService.Update(id , newcomp))
                            {
                                Console.WriteLine("Update successfully");
                                companyService.display();
                            }
                                
                            else
                                Console.WriteLine("Invalid ID , company not found !");
                            
                        }
                        break;
                    case "3":
                        {
                            Console.WriteLine("Inter Company ID You Need To delete");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                            {
                                Console.WriteLine("Invalid ID. Please enter a number:");
                            }

                            if(companyService.Remove(id))
                            {
                                Console.WriteLine("Company Removed successfully");
                                companyService.display();
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID , company not found !");
                            }
                        }
                        break;
                    case "4":
                        {
                            List < Company > all = companyService.GetAll();
                            foreach(var i in all)
                            {
                                i.print();
                                Console.WriteLine();
                            }


                        }
                        break;
                    case "5":
                        {
                            Console.WriteLine("Inter Company ID You Need To Change Status");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                            {
                                Console.WriteLine("Invalid ID. Please enter a number:");
                            }
                            Console.WriteLine("1 Aproved\n2 Regected");
                            string? state = Console.ReadLine()??"";
                            while(state != "1" && state != "2")
                            {
                                Console.WriteLine("please inter 1 or 2");
                                state = Console.ReadLine()??"";

                            }

                            if (state == "1")
                            {
                                if(companyService.Chang_Status(id , Company_Status.Approved))
                                {
                                    Console.WriteLine(" Status Changed successfully");
                                    companyService.display();

                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID , company not found !");

                                }


                            }
                            if (state == "2")
                            {
                                if (companyService.Chang_Status(id, Company_Status.Rejected))
                                {
                                    Console.WriteLine(" Status Changed successfully");
                                    companyService.display();

                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID , company not found !");

                                }

                            }

                        }
                        break;
                    case "6":
                        {
                            Console.WriteLine("1 Aproved\n2 Regected\n3 Regected");
                            string? state = Console.ReadLine() ?? "";
                            while (state != "1" && state != "2" && state != "3")
                            {
                                Console.WriteLine("please inter 1 or 2 or 3");
                                state = Console.ReadLine() ?? "";

                            }
                            List<Company> statelist = [];
                            if (state == "1")
                            {
                                statelist = companyService.List_by_status(Company_Status.Approved);
                                foreach(var i in statelist)
                                {
                                    i.print();
                                    Console.WriteLine();
                                }
                            }
                            else if (state == "2")
                            {
                                statelist = companyService.List_by_status(Company_Status.Rejected);
                                foreach (var i in statelist)
                                {
                                    i.print();
                                    Console.WriteLine();
                                }
                            }
                            if (state == "3")
                            {
                                statelist = companyService.List_by_status(Company_Status.Pending);
                                foreach (var i in statelist)
                                {
                                    i.print();
                                    Console.WriteLine();
                                }
                            }



                        }
                        break;
                    case "7":
                        {
                           Console.WriteLine( companyService.Undo() );
                            companyService.display();
                        }
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("invalud number");
                        break;
                }
                
            }

        }


        static void RecruiterMenu(RecruiterService recruiterService)
        {
            while(true)
{            
            Console.WriteLine("========== RECRUITERS ==========\r\n1. Add Recruiter\r\n2. Update Recruiter\r\n3. Remove Recruiter\r\n4. List All Recruiters\r\n5. Back");
            string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                        {

                            Console.WriteLine("Inter Recruiter ID");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                            {
                                Console.WriteLine("Invalid ID. Please enter a number:");
                            }
                            Console.WriteLine("Inter Recruiter Name");
                            string name = Console.ReadLine() ?? "";
                            while (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Name is required. Please enter a valid name:");
                                name = Console.ReadLine() ?? "";
                            }
                            Console.WriteLine("Inter Recruiter Email");
                            string email = Console.ReadLine() ?? "";
                            Console.WriteLine("Inter Recruiter CompanyId");
                            int companyid ;
                            while (!int.TryParse(Console.ReadLine(), out companyid) || companyid <= 0 )
                            {
                                Console.WriteLine("Invalid ID. Please enter a number:");
                            }

                            try{
                                Recruiter newrec = new Recruiter() { Id = id, Name = name, Email = email, CompanyId = companyid };
                                Console.WriteLine(recruiterService.Add(newrec));
                                recruiterService.display();
                            }
                            catch(FormatException ex)
                            {
                                Console.WriteLine(ex.Message);

                            }




                        }
                    break;
                case "2":
                        {

                            Console.WriteLine("Inter Recruiter ID You Need To Update");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                            {
                                Console.WriteLine("Invalid ID. Please enter a number:");
                            }


                            Console.WriteLine("Inter New Recruiter Name");
                            string name = Console.ReadLine() ?? "";
                            while (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Name is required. Please enter a valid name:");
                                name = Console.ReadLine() ?? "";
                            }
                            Console.WriteLine("Inter Recruiter New Email");
                            string email = Console.ReadLine() ?? "";
                            Console.WriteLine("Inter Recruiter New CompanyId");
                            int companyid;
                            while (!int.TryParse(Console.ReadLine(), out companyid) || companyid <= 0)
                            {
                                Console.WriteLine("Invalid ID. Please enter a number:");
                            }

                            try
                            {
                                Recruiter newrec = new Recruiter() { Id = id, Name = name, Email = email, CompanyId = companyid };
                                Console.WriteLine(recruiterService.Update( id , newrec));
                                recruiterService.display();
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);

                            }
    

                        }
                    break;
                case "3":
                        {
                            Console.WriteLine("Inter Recruiter ID You Need To Update");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                            {
                                Console.WriteLine("Invalid ID. Please enter a number:");
                            }

                            if(recruiterService.Remove(id))
                            {
                                Console.WriteLine("remove Successfully");
                                recruiterService.display();
                            }
                            else
                            {
                                Console.WriteLine("Invaild Id , Recruiter not found !");
                            }

                        }
                    break;
                case "4":
                        {
                            List<Recruiter> all = recruiterService.GetAll();
                            foreach(var i in all)
                            {
                                i.Print();
                                Console.WriteLine();


                            }
                        }
                    break;
                        {

                        }
                    case "5": return;
                    break;
                default:
                    Console.WriteLine("invalud number");
                    break;
            }
            }
        }

       static void printjob(JobService job)
        {
            foreach(var i in job.GetAll())
            {
                Console.WriteLine($"ID: {i.Id}");
                Console.WriteLine($"Title: {i.Title}");
                Console.WriteLine($"Description: {i.Description}");
                Console.WriteLine($"Salary: {i.Salary}");
                Console.WriteLine($"Location: {i.Location}");
                Console.WriteLine($"Is Open: {(i.IsOpen ? "Yes":"No" )}");
                Console.WriteLine($"Posted Date: {i.PostedDate}");
                Console.WriteLine($"Company ID: {i.CompanyId}");
                Console.WriteLine($"Recruiter ID: {i.RecruiterId}");
                Console.WriteLine("--------------------------------");
            }
        }

        static void printlist(List<Job> job)
        {
            foreach(var i in job)
            {
                Console.WriteLine($"ID: {i.Id}");
                Console.WriteLine($"Title: {i.Title}");
                Console.WriteLine($"Description: {i.Description}");
                Console.WriteLine($"Salary: {i.Salary}");
                Console.WriteLine($"Location: {i.Location}");
                Console.WriteLine($"Is Open: {(i.IsOpen ? "Yes" : "No")}");
                Console.WriteLine($"Posted Date: {i.PostedDate}");
                Console.WriteLine($"Company ID: {i.CompanyId}");
                Console.WriteLine($"Recruiter ID: {i.RecruiterId}");
                Console.WriteLine("--------------------------------");
            }
        }
        static void JobMenu(JobService jobservice)
        {
            while(true)
            {
                Console.WriteLine("========== JOBS ==========\r\n1. Add Job\r\n2. Update Job\r\n3. Remove Job\r\n4. List All Jobs\r\n5. Find Job By ID\r\n6. Search By Title\r\n7. Search By Minimum Salary\r\n8. Search By Title and Minimum Salary\r\n9. Sort By Salary Ascending\r\n10. Sort By Salary Descending\r\n11. Sort By Title\r\n12. Back"); string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                        {
                            Console.WriteLine("Enter Job ID:");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                            {
                                Console.WriteLine("Invalid ID. Please enter a valid number:");
                            }

                            Console.WriteLine("Enter Job Title:");
                            string title = Console.ReadLine() ?? "";
                            while (string.IsNullOrWhiteSpace(title))
                            {
                                Console.WriteLine("Title is required. Please enter a valid title:");
                                title = Console.ReadLine() ?? "";
                            }

                            Console.WriteLine("Enter Job Description:");
                            string description = Console.ReadLine() ?? "";

                            Console.WriteLine("Enter Salary:");
                            decimal salary;
                            while (!decimal.TryParse(Console.ReadLine(), out salary) || salary < 0)
                            {
                                Console.WriteLine("Invalid Salary. Please enter a valid salary:");
                            }

                            Console.WriteLine("Enter Job Location:");
                            string location = Console.ReadLine() ?? "";

                            Console.WriteLine("Enter Company ID:");
                            int companyId;
                            while (!int.TryParse(Console.ReadLine(), out companyId) || companyId <= 0)
                            {
                                Console.WriteLine("Invalid Company ID. Please enter a valid number:");
                            }

                            Console.WriteLine("Enter Recruiter ID:");
                            int recruiterId;
                            while (!int.TryParse(Console.ReadLine(), out recruiterId) || recruiterId <= 0)
                            {
                                Console.WriteLine("Invalid Recruiter ID. Please enter a valid number:");
                            }

                            Job newJob = new Job()
                            {
                                Id = id,
                                Title = title,
                                Description = description,
                                Salary = salary,
                                Location = location,
                                CompanyId = companyId,
                                RecruiterId = recruiterId,
                                PostedDate = DateTime.Now
                            };

                            Console.WriteLine(jobservice.Add(newJob));
                            printjob(jobservice);


                        }
                    break;
                case "2":
                        {
                            Console.WriteLine("Enter Job ID:");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                                Console.WriteLine("Invalid ID. Please enter a valid number:");

                            Console.WriteLine("Enter Job Title:");
                            string title = Console.ReadLine() ?? "";
                            while (string.IsNullOrWhiteSpace(title))
                            {
                                Console.WriteLine("Title is required. Please enter a valid title:");
                                title = Console.ReadLine() ?? "";
                            }

                            Console.WriteLine("Enter Job Description:");
                            string description = Console.ReadLine() ?? "";

                            Console.WriteLine("Enter Salary:");
                            decimal salary;
                            while (!decimal.TryParse(Console.ReadLine(), out salary) || salary < 0)
                                Console.WriteLine("Invalid Salary. Please enter a valid salary:");

                            Console.WriteLine("Enter Job Location:");
                            string location = Console.ReadLine() ?? "";

                            Console.WriteLine("Enter Company ID:");
                            int companyId;
                            while (!int.TryParse(Console.ReadLine(), out companyId) || companyId <= 0)
                                Console.WriteLine("Invalid Company ID. Please enter a valid number:");

                            Console.WriteLine("Enter Recruiter ID:");
                            int recruiterId;
                            while (!int.TryParse(Console.ReadLine(), out recruiterId) || recruiterId <= 0)
                                Console.WriteLine("Invalid Recruiter ID. Please enter a valid number:");

                            Job updatedJob = new Job()
                            {
                                Id = id,
                                Title = title,
                                Description = description,
                                Salary = salary,
                                Location = location,
                                CompanyId = companyId,
                                RecruiterId = recruiterId
                            };

                            Console.WriteLine(jobservice.Update(id, updatedJob));
                            printjob(jobservice);
                        }
                    break;
                case "3":
                        {
                            Console.WriteLine("Enter Job ID:");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                                Console.WriteLine("Invalid ID. Please enter a valid number:");
                            Console.WriteLine((jobservice.remove(id) ? "Remove Successfully " : "Invaild Id , Job not found or you try remove job in application !"));
                            printjob(jobservice);
                        }
                    break;
                case "4":
                        {
                            printjob(jobservice);
                        }
                    break;
                case "5":
                        {
                            Console.WriteLine("Enter Job ID:");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                                Console.WriteLine("Invalid ID. Please enter a valid number:");
                            Job? job = jobservice.job_by_Id(id);
                            Console.WriteLine((job != null ? "job found" : "Invaild Id , Job not found !"));
                        }
                    break;
                    case "6":
                        {Console.Write("Enter Keyword: ");
                        string keyword = Console.ReadLine() ?? "";
                            printlist(jobservice.SearchByTitle(keyword));
                        }
                        break;

                    case "7":
                        {Console.Write("Enter Minimum Salary: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal minSalary) && minSalary >= 0)
                                printlist(jobservice.SearchByMinimumSalary(minSalary));
                            else
                                Console.WriteLine("Invalid Salary");
                        }
                        break;

                    case "8":
                       { Console.Write("Enter Keyword: ");
                        string searchKeyword = Console.ReadLine() ?? "";

                        Console.Write("Enter Minimum Salary: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal salary) && salary >= 0)
                                printlist(jobservice.SearchJobs(searchKeyword, salary));
                            else
                                Console.WriteLine("Invalid Salary");
                        }
                        break;

                    case "9":
                        printlist(jobservice.SortBySalary(true));
{
                            break;
}
                    case "10":
{
                            printlist(jobservice.SortBySalary(false));
}                        break;

                    case "11":
{
                            printlist(jobservice.SortByTitle());
}                        break;

                    case "12":
                        return;
                        break;
                default:
                    Console.WriteLine("invalud number");
                    break;
            }
               
            }
        }

        static void printcandidate(CandidateService candidate)
        {
            foreach (var i in candidate.GetAll())
            {
                Console.WriteLine($"ID: {i.Id}");
                Console.WriteLine($"Full Name: {i.FullName}");
                Console.WriteLine($"Email: {i.Email}");
                Console.WriteLine($"Phone: {i.Phone}");
                Console.WriteLine($"Years Of Experience: {i.YearsOfExperience}");
                Console.WriteLine("--------------------------------");
            }
        }


        static void CandidateMenu(CandidateService candidateService)
        {
            while (true) { 

            Console.WriteLine("========== CANDIDATES ==========\r\n1. Add Candidate\r\n2. Update Candidate\r\n3. Remove Candidate\r\n4. List All Candidates\r\n5. Back");
            string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                        {
                            Console.WriteLine("Enter Candidate ID:");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                                Console.WriteLine("Invalid ID. Please enter a valid number:");

                            Console.WriteLine("Enter Full Name:");
                            string name = Console.ReadLine() ?? "";
                            while (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Name is required. Please enter a valid name:");
                                name = Console.ReadLine() ?? "";
                            }

                            Console.WriteLine("Enter Email:");
                            string email = Console.ReadLine() ?? "";

                            Console.WriteLine("Enter Phone:");
                            string phone = Console.ReadLine() ?? "";

                            Console.WriteLine("Enter Years Of Experience:");
                            int experience;
                            while (!int.TryParse(Console.ReadLine(), out experience) || experience < 0)
                                Console.WriteLine("Invalid Experience. Please enter a valid number:");

                            try
                            {
                                Candidate newCandidate = new Candidate()
                                {
                                    Id = id,
                                    FullName = name,
                                    Email = email,
                                    Phone = phone,
                                    YearsOfExperience = experience
                                };

                                Console.WriteLine(candidateService.Add(newCandidate));
                                printcandidate(candidateService);
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    break;
                case "2":
                        {
                            Console.WriteLine("Enter Candidate ID:");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                                Console.WriteLine("Invalid ID. Please enter a valid number:");

                            Console.WriteLine("Enter Full Name:");
                            string name = Console.ReadLine() ?? "";
                            while (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Name is required. Please enter a valid name:");
                                name = Console.ReadLine() ?? "";
                            }

                            Console.WriteLine("Enter Email:");
                            string email = Console.ReadLine() ?? "";

                            Console.WriteLine("Enter Phone:");
                            string phone = Console.ReadLine() ?? "";

                            Console.WriteLine("Enter Years Of Experience:");
                            int experience;
                            while (!int.TryParse(Console.ReadLine(), out experience) || experience < 0)
                                Console.WriteLine("Invalid Experience. Please enter a valid number:");

                            try
                            {
                                Candidate updatedCandidate = new Candidate()
                                {
                                    Id = id,
                                    FullName = name,
                                    Email = email,
                                    Phone = phone,
                                    YearsOfExperience = experience
                                };

                                Console.WriteLine(candidateService.Update(id, updatedCandidate));
                                printcandidate(candidateService);
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    break;
                case "3":
                        {
                            Console.WriteLine("Enter Candidate ID:");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                            Console.WriteLine("Invalid ID. Please enter a valid number:");

                            Console.WriteLine(candidateService.Remove(id) ? "Remove Successfully " : "Invaild Id , Candidate not found !");
                            printcandidate(candidateService);
                        }
                    break;
                case "4":
                        {
                            printcandidate(candidateService);
                        }
                    break;
                case "5":
                    return;
                    break;
                default:
                    Console.WriteLine("invalud number");
                    break;
            }
        }
          

        }

        static void ApplicationMenu(ApplicationService applicationService)
        {

            while (true) { 
            Console.WriteLine("========== APPLICATIONS ==========\r\n1. Apply To Job\r\n2. List All Applications\r\n3. Change Statues\r\n4. Back");
            string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                        {
                            Console.WriteLine("Enter Candidate ID:");
                            int canid;
                            while (!int.TryParse(Console.ReadLine(), out canid) || canid <= 0)
                                Console.WriteLine("Invalid ID. Please enter a valid number:");

                            Console.WriteLine("Enter Job ID:");
                            int jobid;
                            while (!int.TryParse(Console.ReadLine(), out jobid) || jobid <= 0)
                                Console.WriteLine("Invalid ID. Please enter a valid number:");

                            Console.WriteLine(applicationService.Apply_to_job(jobid , canid));

                        }
                    break;
                case "2":
                        {
                           
                            foreach (var i in applicationService.GetAll())
                            {
                                Console.WriteLine($"ID: {i.Id}");
                                Console.WriteLine($"Job ID: {i.JobId}");
                                Console.WriteLine($"Candidate ID: {i.CandidateId}");
                                Console.WriteLine($"Applied Date: {i.AppliedDate}");
                                Console.WriteLine($"Status: {i.Status}");
                                Console.WriteLine("--------------------------------");
                            }

                        }
                    break;
                case "3":
                        {
                            Console.WriteLine("Inter Application ID You Need To Change Status");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                            {
                                Console.WriteLine("Invalid ID. Please enter a number:");
                            }
                            Console.WriteLine("1- UnderReview\n2- Interview\n3- Accepted\n4- Rejected");
                            string? state = Console.ReadLine() ?? "";
                            while (state != "1" && state != "2" && state != "3" && state != "4")
                            {
                                Console.WriteLine("please inter from 1 to 4");
                                state = Console.ReadLine() ?? "";

                            }

                            if (state == "1")
                            {
                                if (applicationService.Chang_Status(id, Application_Status.UnderReview))
                                {
                                    Console.WriteLine("Status Changed successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID , company not found !");

                                }


                            }
                            if (state == "2")
                            {
                                if (applicationService.Chang_Status(id, Application_Status.Interview))
                                {
                                    Console.WriteLine("Status Changed successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID , company not found !");

                                }

                            }

                            if (state == "3")
                            {
                                if (applicationService.Chang_Status(id, Application_Status.Accepted))
                                {
                                    Console.WriteLine("Status Changed successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID , company not found !");

                                }

                            }

                            if (state == "4")
                            {
                                if (applicationService.Chang_Status(id, Application_Status.Rejected))
                                {
                                    Console.WriteLine("Status Changed successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID , company not found !");

                                }

                            }

                        }
                    break;
                    case "4": return;
                        break;
                default:
                    Console.WriteLine("invalud number");
                    break;
            }
        }

        }








        static void Main(string[] args)
        {
            Company TechNova = new Company()
            { Name = "TechNova", Id = 1 , Industry= "tech" , City="Alx" , Status=Company_Status.Approved };

            Company CloudNine = new Company()
            { Name = "CloudNine", Id = 2, Industry = "tech", City = "Cairo", Status = Company_Status.Approved };

            Company DevSphere = new Company()
            { Name = "DevSphere", Id = 3, Industry = "tech", City = "Giza" };

            DataStore<Company> companies = new DataStore<Company>();
            CompanyService companyService = new CompanyService(companies);
            companyService.CompanyApproved += infocompany ;
            companyService.Add(TechNova);
            companyService.Add(CloudNine);
            companyService.Add(DevSphere);


            /////////////////

            Recruiter rec1 = new Recruiter() { Id = 1 , Name = "Ahmed Hassan" , Email= "ahmed@technova.com" , CompanyId=1 };

            Recruiter rec3 = new Recruiter() { Id = 2, Name = "Sara Mohamed", Email = "sara@cloudnine.com", CompanyId = 2 };

            Recruiter rec2 = new Recruiter() { Id = 3, Name = "Omar Ali", Email = "omar@devsphere.com", CompanyId = 3 };

            DataStore<Recruiter> Recruiters = new DataStore<Recruiter>();
            RecruiterService recruiterService = new RecruiterService(Recruiters, companies);
            recruiterService.Add(rec1);
            recruiterService.Add(rec2);
            recruiterService.Add(rec3);
            ////////////////////////////

            Job j1 = new Job()
            {
                Id = 1,
                Title = "Backend Developer",
                Salary = 150000,
                Location = "Cairo",
                IsOpen = true,
                PostedDate = new DateTime(2026, 7, 15),
                RecruiterId = 1,
                Description = "-",
                CompanyId = 1
            };

            Job j2 = new Job()
            {
                Id = 2,
                Title = "Frontend Developer",
                Salary = 120000,
                Location = "Cairo",
                IsOpen = true,
                PostedDate = new DateTime(2026, 10, 30),
                RecruiterId = 1,
                Description = "-",
                CompanyId = 1
            };

            Job j3 = new Job()
            {
                Id = 3,
                Title = ".NET Developer",
                Salary = 160000,
                Location = "Giza",
                IsOpen = true,
                PostedDate = new DateTime(2026, 11, 1),
                RecruiterId = 2,
                Description = "-",
                CompanyId = 2
            };

            Job j4 = new Job()
            {
                Id = 4,
                Title = "UI/UX Designer",
                Salary = 100000,
                Location = "Alx",
                IsOpen = true,
                PostedDate =new DateTime(2026 , 7 , 1),
                RecruiterId = 2,
                Description = "-",
                CompanyId = 2
            };

            Job j5 = new Job()
            {
                Id = 5,
                Title = "Junior Backend Developer",
                Salary = 8000,
                Location = "Cairo",
                IsOpen = true,
                PostedDate = new DateTime(2026, 8, 10),
                RecruiterId = 2,
                Description = "-",
                CompanyId = 3
            };

            Job j6 = new Job()
            {
                Id = 6,
                Title = "Software Tester",
                Salary = 150000,
                Location = "Cairo",
                IsOpen = false,
                PostedDate = new DateTime(2026, 10, 15),
                RecruiterId = 2,
                Description = "-",
                CompanyId = 3
            };




            ////////////////////

            Candidate cand1 = new Candidate()
            { 
                Id = 1 ,
                Email = "rana@gmail.com" ,
            
                FullName = "Rana Fisal" ,
            
                Phone = "01012345678" ,
            
                YearsOfExperience = 0

            };

            Candidate cand2 = new Candidate()
            {
                Id = 2,
                Email = "mariam@gmail.com",

                FullName = "Mariam Adel",

                Phone = "01087345678",

                YearsOfExperience = 2

            };

            Candidate cand3 = new Candidate()
            {
                Id = 3,
                Email = "youssef@gmail.com",

                FullName = "Youssef Ahmed",

                Phone = "01012375306",

                YearsOfExperience = 1

            };

            Candidate cand4 = new Candidate()
            {
                Id = 4,
                Email = "nour@gmail.com",

                FullName = "Nour Khaled",

                Phone = "01063075678",

                YearsOfExperience = 3


            };

            Candidate cand5 = new Candidate()
            {
                Id = 5,
                Email = "ali@gmail.com",

                FullName = "Ali Mostafa",

                Phone = "010036689468",

                YearsOfExperience = 4

            };

            DataStore<Candidate> Candidates = new DataStore<Candidate>();
            CandidateService candidateService = new CandidateService(Candidates);
            candidateService.Add(cand1);
            candidateService.Add(cand2);
            candidateService.Add(cand3);
            candidateService.Add(cand4);
            candidateService.Add(cand5);
            //////

            DataStore<Application> applications = new DataStore<Application>();
            DataStore<Job> jobs = new DataStore<Job>();
            JobService jobService = new JobService(jobs, companies, Recruiters, applications);
            ApplicationService applicationService = new ApplicationService(applications, candidateService, jobService, companyService);
            applicationService.ApplicationSubmitted += infoapplication;
            applicationService.ApplicationStatusChanged += changestatus;
            jobService.Add(j1);
            jobService.Add(j2);
            jobService.Add(j3);
            jobService.Add(j4);
            jobService.Add(j5);
            jobService.Add(j6);

            /////////////////////////////////////
            /////////////////////////////////////
            ///

            while (true)
            {

                Console.WriteLine
                    ("================================\r\n" +
                    "      JOB APPLICATION TRACKER\r\n" +
                    "================================\r\n\r\n" +
                    "1. Manage Companies\r\n" +
                    "2. Manage Recruiters\r\n" +
                    "3. Manage Jobs\r\n" +
                    "4. Manage Candidates\r\n" +
                    "5. Manage Applications\r\n" +
                    "6. Exit\r\n\r\n" +
                    "Enter your choice:");
                //Event
                // stuent sub = new stuent("ahmed");
                // sub.tests += (object o, testargs t) =>
                // {
                //     stuent s = (stuent)o;
                //     Console.WriteLine($"congratulations {s.name} you are passed with {t.grade} from {t.fullgrade}");
                // };
                // sub.tests += namedmethod ;

                //bool x = sub.pass(70 , 50 ,100);
                // sub.tests -= namedmethod;
                // publisher The class that raises the event 
                //  subscribers the classes that  handle the event 
                //If we have multiple subscribers, the delegates are executed in the order in which they subscribed.
                 //If an exception occurs within one of them and it is not handled using a `try-catch` block:
                //The execution of that specific handler will stop.
                // and will propagate out of `Invoke()`.
                //The remaining subscribers that follow will not be executed.





    string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                       CompanyMenu(companyService);
                        break;
                    case "2":
                        RecruiterMenu(recruiterService);
                        break;
                    case "3":
                        JobMenu(jobService);
                        break;
                    case "4":
                        CandidateMenu(candidateService);
                        break;
                    case "5":
                        ApplicationMenu(applicationService);
                        break;
                    case "6":
                        return;
                        break;
                    default:
                        Console.WriteLine("invalud number");
                        break;
                }

            }















        }
        public static void namedmethod(object o, testargs t)
        {
            stuent s = (stuent)o;
            Console.WriteLine($"the passed grade was {t.passgrae}");
        }

        public static void infocompany(object o , CompanyApprovedEventArgs c)
        {
            Console.WriteLine($"{c.Company.Name} Company is approved now !");

        }

        public static EventHandler<ApplicationSubmittedEventAegs> infoapplication = (o, app) =>
             {
                 Console.WriteLine($"{app.candidate.FullName} you applayed on {app.job.Title} Job whith Salary {app.job.Salary} " +
                     $"\n your application id : {app.application.Id}");
             };
        public static EventHandler<ApplicationStatusChangedEventArgs> changestatus = (o, app) =>
        {

            Console.WriteLine($"your old status is {app.oldstatus} the new is {app.newstatus}");

        };
    }
}

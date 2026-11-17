using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using JobApplicationTracker.Services;
using Microsoft.VisualBasic;

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
                            Console.WriteLine("Inter 1 Aproved\n2 Regected");
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


        static void RecruiterMenu()
        {
            while(true)
{            
            Console.WriteLine("========== RECRUITERS ==========\r\n1. Add Recruiter\r\n2. Update Recruiter\r\n3. Remove Recruiter\r\n4. List All Recruiters\r\n5. Back");
            string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                    case "5": return;
                    break;
                default:
                    Console.WriteLine("invalud number");
                    break;
            }
            }
        }

        static void JobMenu()
        {
            while(true)
            {
            Console.WriteLine("========== JOBS ==========\r\n1. Add Job\r\n2. Update Job\r\n3. Remove Job\r\n4. List All Jobs\r\n5. Find Job By ID\r\n6. Back");
            string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6": return;
                    break;
                default:
                    Console.WriteLine("invalud number");
                    break;
            }
               
            }
        }

        static void CandidateMenu()
        {
            while (true) { 

            Console.WriteLine("========== CANDIDATES ==========\r\n1. Add Candidate\r\n2. Update Candidate\r\n3. Remove Candidate\r\n4. List All Candidates\r\n5. Back");
            string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
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

        static void ApplicationMenu()
        {

            while (true) { 
            Console.WriteLine("========== APPLICATIONS ==========\r\n1. Apply To Job\r\n2. List All Applications\r\n3. Back");
            string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3": return;
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
            { Name = "CloudNine", Id = 2, Industry = "tech", City = "Cairo", Status = Company_Status.Rejected };

            Company DevSphere = new Company()
            { Name = "DevSphere", Id = 3, Industry = "tech", City = "Giza" };

            DataStore<Company> companies = new DataStore<Company>();
            CompanyService companyService = new CompanyService(companies);
            companyService.Add(TechNova);
            companyService.Add(CloudNine);
            companyService.Add(DevSphere);


            /////////////////

            Recruiter rec1 = new Recruiter() { Id = 1 , Name = "Ahmed Hassan" , Email= "ahmed@technova.com" , CompanyId=1 };

            Recruiter rec3 = new Recruiter() { Id = 2, Name = "Sara Mohamed", Email = "sara@cloudnine.com", CompanyId = 2 };

            Recruiter rec2 = new Recruiter() { Id = 3, Name = "Omar Ali", Email = "omar@devsphere.com", CompanyId = 3 };

            DataStore<Recruiter> Recruiters = new DataStore<Recruiter>();

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
                RecruiterId = 3,
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
                RecruiterId = 3,
                Description = "-",
                CompanyId = 3
            };


            DataStore<Job> jobs = new DataStore<Job>();

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
                Id = 3,
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
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                       CompanyMenu(companyService);
                        break;
                    case 2:
                        RecruiterMenu();
                        break;
                    case 3:
                        JobMenu();
                        break;
                    case 4:
                        CandidateMenu();
                        break;
                    case 5:
                        ApplicationMenu();
                        break;
                    case 6:
                        return;
                        break;
                    default:
                        Console.WriteLine("invalud number");
                        break;
                }

            }















        }
    }
}

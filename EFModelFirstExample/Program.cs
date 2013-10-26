using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a company name.");
            string companyName = Console.ReadLine();

            Console.WriteLine("Please enter a company address");
            string companyAddress = Console.ReadLine();

            EFModelFirstExample.Company company = new Company();
            company.Name = companyName;
            company.Address = companyAddress;
            using (var db = new DBContext())
            {
                db.Companies.Add(company);
                db.SaveChanges();    
            }

            Console.WriteLine("List of companies in the DB");
            using (var db = new DBContext())
            {
                var companies = (from c in db.Companies
                                 select c.Name).ToList();
                foreach (var name in companies)
                {
                    Console.WriteLine(name);       
                }
                Console.ReadKey();
            }
        }
    }
}

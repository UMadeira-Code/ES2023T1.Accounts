using Accounts.Data;
using Accounts.Data.Xml;

using Accounts.Data.Json;
using Accounts.Data.Store;
using Microsoft.EntityFrameworkCore;

namespace Accounts.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Accounts v1.0");

            Console.WriteLine();
            Console.WriteLine("Using XML...");
            UsindJson();

            Console.WriteLine();
            Console.WriteLine("Using Json...");
            UsingXml();

            Console.WriteLine();
            Console.WriteLine("Using Entity Framework...");
            UsingEntityFramework();
        }

        static void UsingEntityFramework()
        {
            using (var context = new AccountsContext())
            {
                context.Database.EnsureCreated();

                // Custom Seeding the Database 
                if (context.Organizations.Count() == 0)
                {
                    context.Organizations.Add(CreateOrganization());
                    context.SaveChanges();
                }

                var organization = context.Organizations.Include(e => e.Users).First();
                ShowOrganization( organization );
            }
        }

        static void UsingXml()
        {
            if ( ! File.Exists("data.xml") )
            {
                Data.Xml.Serializer.Save(CreateOrganization(), "data.xml" );
            }

            var organization = Data.Json.Serializer.Load("data.json");
            ShowOrganization(organization);


            //Serializer.Save("data.xml", organization);
            //organization.Save("accounts.xml");
        }

        static void UsindJson()
        {
            if (!File.Exists("data.json"))
            {
                Data.Json.Serializer.Save(CreateOrganization(), "data.json");
            }

            var organization = Data.Json.Serializer.Load("data.json");
            ShowOrganization(organization);
        }

        static Organization CreateOrganization()
        {
            var organization = new Organization() { Name = "UMa" };

            organization.Users.Add(new() { UserName = "maria",  Password = "***" });
            organization.Users.Add(new() { UserName = "jose",   Password = "***" });
            organization.Users.Add(new() { UserName = "rosa",   Password = "***" });
            organization.Users.Add(new() { UserName = "manuel", Password = "***" });

            return organization;
        }

        static void ShowOrganization( Organization organization )
        {
            Console.WriteLine($"Organization: {organization.Name}");
            foreach ( var user in organization.Users )
            {
                Console.WriteLine($"\tUser: {user.UserName}");
            }
        }
    }
}
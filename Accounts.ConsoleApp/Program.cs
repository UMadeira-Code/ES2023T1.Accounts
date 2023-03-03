using Accounts.Data;
using Accounts.Data.Xml;

using Accounts.Data.Json;

namespace Accounts.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Accounts v1.0");
            //var organization = CreateOrganization();

            var organization = Data.Json.Serializer.Load("data.json");
            ShowOrganization( organization );
//            Data.Json.Serializer.Save(organization, "data.json");


            //Serializer.Save("data.xml", organization);
            //organization.Save("accounts.xml");
            
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
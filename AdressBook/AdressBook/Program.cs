using System;
using AddressBookSystem.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("Welcome to Address Book Program!");

            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter City:");
            string city = Console.ReadLine();

            Console.WriteLine("Enter State:");
            string state = Console.ReadLine();

            Console.WriteLine("Enter Zip:");
            string zip = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            string phone = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();

            Contact c = new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                Phone = phone,
                Email = email
            };

            addressBook.AddContact(c);

            Console.WriteLine("\nContact Added Successfully!\n");
            Console.WriteLine(c);


        }
    }
}

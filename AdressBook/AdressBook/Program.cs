using System;
using AddressBookSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class Program
    {

       static  AddressBook addressBook = new AddressBook();
        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Address Book Program!");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;

                    case "2":
                        EditContact();
                        break;

                    case "3":
                        DeleteContact();
                        break;

                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }

        public static void AddContact()
        {
            bool addMore = true;

            while (addMore)
            {

                Console.WriteLine("\nEnter First Name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("\nEnter Last Name:");
                string lastName = Console.ReadLine();

                Console.WriteLine("\nEnter Address:");
                string address = Console.ReadLine();

                Console.WriteLine("\nEnter City:");
                string city = Console.ReadLine();

                Console.WriteLine("\nEnter State:");
                string state = Console.ReadLine();

                Console.WriteLine("\nEnter Zip:");
                string zip = Console.ReadLine();

                Console.WriteLine("\nEnter Phone:");
                string phone = Console.ReadLine();

                Console.WriteLine("\nEnter Email:");
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

                Console.Write("\nDo you want to add another contact? (Yes/No): ");
                string choice = Console.ReadLine();

                addMore = choice.Equals("Yes", StringComparison.OrdinalIgnoreCase); 
            }
        }


        public static void EditContact()
        {
            var allContacts = addressBook.GetAllContacts();

            if (allContacts.Count == 0)
            {
                Console.WriteLine("No contacts available to edit.");
                return;
            }

            Console.WriteLine("Select a contact to edit:");
            for (int i = 0; i < allContacts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allContacts[i]}");
            }

            Console.Write("Enter the number of the contact: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > allContacts.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Contact contactToEdit = allContacts[index - 1];

            Console.WriteLine("Enter New First Name (current: {0}):", contactToEdit.FirstName);
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter New Last Name (current: {0}):", contactToEdit.LastName);
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter New Address (current: {0}):", contactToEdit.Address);
            string address = Console.ReadLine();

            Console.WriteLine("Enter New City (current: {0}):", contactToEdit.City);
            string city = Console.ReadLine();

            Console.WriteLine("Enter New State (current: {0}):", contactToEdit.State);
            string state = Console.ReadLine();

            Console.WriteLine("Enter New Zip (current: {0}):", contactToEdit.Zip);
            string zip = Console.ReadLine();

            Console.WriteLine("Enter New Phone (current: {0}):", contactToEdit.Phone);
            string phone = Console.ReadLine();

            Console.WriteLine("Enter New Email (current: {0}):", contactToEdit.Email);
            string email = Console.ReadLine();

            Contact updatedContact = new Contact
            {
                FirstName = string.IsNullOrEmpty(firstName) ? contactToEdit.FirstName : firstName,
                LastName = string.IsNullOrEmpty(lastName) ? contactToEdit.LastName : lastName,
                Address = string.IsNullOrEmpty(address) ? contactToEdit.Address : address,
                City = string.IsNullOrEmpty(city) ? contactToEdit.City : city,
                State = string.IsNullOrEmpty(state) ? contactToEdit.State : state,
                Zip = string.IsNullOrEmpty(zip) ? contactToEdit.Zip : zip,
                Phone = string.IsNullOrEmpty(phone) ? contactToEdit.Phone : phone,
                Email = string.IsNullOrEmpty(email) ? contactToEdit.Email : email
            };

            addressBook.EditContact(contactToEdit.FirstName, updatedContact);

            Console.WriteLine("Contact updated successfully!");
        }

        public static void DeleteContact()
        {
            var allContacts = addressBook.GetAllContacts();

            if (allContacts.Count == 0)
            {
                Console.WriteLine("No contacts available to delete.");
                return;
            }

            Console.WriteLine("Enter the First Name of the contact to delete:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the Last Name of the contact to delete:");
            string lastName = Console.ReadLine();

            bool deleted = addressBook.DeleteContactByName(firstName, lastName);

            Console.WriteLine(deleted
                ? "Contact deleted successfully."
                : "Contact not found.");
        }


    }
}


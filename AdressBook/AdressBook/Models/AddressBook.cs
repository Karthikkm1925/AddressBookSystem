using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem.Models
{
    public class AddressBook
    {
        private List<Contact> contacts = new List<Contact>();

        public bool AddContact(Contact contact)
        {
            if (contacts.Any(c => c.Equals(contact)))
                return false;

            contacts.Add(contact);
            return true;
        }



        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        public bool EditContact(string firstName, Contact updatedContact)
        {
            var existingContact = contacts
                .FirstOrDefault(c => c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));

            if (existingContact == null)
                return false;

            existingContact.LastName = updatedContact.LastName;
            existingContact.Address = updatedContact.Address;
            existingContact.City = updatedContact.City;
            existingContact.State = updatedContact.State;
            existingContact.Zip = updatedContact.Zip;
            existingContact.Phone = updatedContact.Phone;
            existingContact.Email = updatedContact.Email;

            return true;
        }

        public bool DeleteContactByName(string firstName, string lastName)
        {
             
            var contact = contacts.FirstOrDefault(c =>
                c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

            if (contact == null)
                return false;

            contacts.Remove(contact);
            return true;
        }


    }
}

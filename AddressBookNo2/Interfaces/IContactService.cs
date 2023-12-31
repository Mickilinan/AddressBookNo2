using AddressBookNo2.Models;

namespace AddressBookNo2.Interfaces;



    public interface IContactService
    {
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void RemoveContactByEmail(string email);
        List<Contact> GetAllContacts();
        Contact GetContactByEmail(string email);
    }


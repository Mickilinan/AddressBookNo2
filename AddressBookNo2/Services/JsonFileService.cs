

using AddressBookNo2.Interfaces;
using AddressBookNo2.Models;
using System.Text.Json;

namespace AddressBookNo2.Services;

public partial class JsonFileService : IContactService
{

    private readonly string _filePath;

    public JsonFileService(string filePath)
    {
        _filePath = filePath;
    }

    public void AddContact(Contact contact)
    {
        var contacts = LoadContacts();
        contacts.Add(contact);
        SaveContacts(contacts);
    }

    public void UpdateContact(Contact contact)
    {
        var contacts = LoadContacts();
        var existingContact = contacts.Find(c => c.Email == contact.Email);
        if (existingContact != null)
        {
            // Update the existing contact
            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.Phone = contact.Phone;
            existingContact.Address = contact.Address;
            SaveContacts(contacts);
        }
    }

    public void RemoveContactByEmail(string email)
    {
        var contacts = LoadContacts();
        contacts.RemoveAll(c => c.Email == email);
        SaveContacts(contacts);
    }

    public List<Contact> GetAllContacts()
    {
        return LoadContacts();
    }

    public Contact GetContactByEmail(string email)
    {
        var contacts = LoadContacts();
        return contacts.Find(c => c.Email == email);
    }

    private List<Contact> LoadContacts()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }

        return new List<Contact>();
    }

    private void SaveContacts(List<Contact> contacts)
    {
        var json = JsonSerializer.Serialize(contacts);
        File.WriteAllText(_filePath, json);
    }
}


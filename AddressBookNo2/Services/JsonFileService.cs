using AddressBookNo2.Interfaces;
using AddressBookNo2.Models;
using System.Text.Json;

namespace AddressBookNo2.Services;
/// <summary>
/// Implementation av IContactService interface som använder JSON filer för datalagring.
/// </summary>
public partial class JsonFileService : IContactService
{

    private readonly string _filePath;


    /// <summary>
    /// Initialiserar en ny instans av JsonFileService-klassen med den angivna filvägen.
    /// </summary>
    /// <param name="filePath">Sökvägen till JSON-filen som används för förvaring.</param>
    public JsonFileService(string filePath)
    {
        _filePath = filePath;
    }

    /// <summary>
    /// Lägger till en kontakt i JSON-filen.
    /// </summary>
    /// <param name="contact">Kontakten som ska läggas till.</param>
    public void AddContact(Contact contact)
    {
        var contacts = LoadContacts();
        contacts.Add(contact);
        SaveContacts(contacts);
    }

    /// <summary>
    /// Uppdaterar en befintlig kontakt i JSON-filen.
    /// </summary>
    /// <param name="contact">Uppdaterad kontaktinformation.</param>
    public void UpdateContact(Contact contact)
    {
        var contacts = LoadContacts();
        var existingContact = contacts.Find(c => c.Email == contact.Email);
        if (existingContact != null)
        {
            
            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.Phone = contact.Phone;
            existingContact.Address = contact.Address;
            SaveContacts(contacts);
        }
    }

    /// <summary>
    /// Tar bort en kontakt via e-post från JSON-filen.
    /// </summary>
    /// <param name="email">E-postadressen för kontakten som ska tas bort.</param>
    public void RemoveContactByEmail(string email)
    {
        var contacts = LoadContacts();
        contacts.RemoveAll(c => c.Email == email);
        SaveContacts(contacts);
    }

    /// <summary>
    /// Hämtar alla kontakter från JSON-filen.
    /// </summary>
    /// <returns>En lista med alla kontakter.</returns>
    public List<Contact> GetAllContacts()
    {
        return LoadContacts();
    }

    /// <summary>
    /// Hämtar en kontakt via e-post från JSON-filen.
    /// </summary>
    /// <param name="email">E-postadressen för kontakten som ska hämtas.</param>
    /// <returns>Kontakten med den angivna e-postadressen, eller null om den inte hittades.</returns>
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


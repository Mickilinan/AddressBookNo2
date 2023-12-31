
using AddressBookNo2.Models;
using AddressBookNo2.Services;


namespace ClassLibrary.Tests;

public class ContactService_Tests
{
    [Fact]
    public void Add_ShouldAddContactToList()
    {
        // Arrange
        var contactService = new ContactService();
        var contact = new Contact();

        // Act
        contactService.Add(contact);

        // Assert
        var contacts = contactService.GetAll();
        Assert.Contains(contact, contacts);
    }

    [Fact]
    public void GetAll_ShouldReturnAllContacts()
    {
        // Arrange
        var contactService = new ContactService();
        var contact1 = new Contact();
        var contact2 = new Contact();
        contactService.Add(contact1);
        contactService.Add(contact2);

        // Act
        var contacts = contactService.GetAll();

        // Assert
        Assert.Contains(contact1, contacts);
        Assert.Contains(contact2, contacts);
    }

    [Fact]
    public void UpdateContact_ShouldUpdateContact_WhenContactExists()
    {
        // Arrange
        var contactService = new ContactService();
        var originalContact = new Contact();
        var updatedContact = new Contact
        {
            Id = originalContact.Id,
            FirstName = "Updated",
            LastName = "Doe",
            Email = "updated@example.com",
            Phone = "555-555-5555",
            Address = "456 Updated St"
        };
        contactService.Add(originalContact);

        // Act
        contactService.UpdateContact(updatedContact);

        // Assert
        var contacts = contactService.GetAll();
        var updatedContactInList = contacts.FirstOrDefault(c => c.Id == updatedContact.Id);
        Assert.NotNull(updatedContactInList);
        Assert.Equal(updatedContact.FirstName, updatedContactInList.FirstName);
        Assert.Equal(updatedContact.LastName, updatedContactInList.LastName);
        Assert.Equal(updatedContact.Email, updatedContactInList.Email);
        Assert.Equal(updatedContact.Phone, updatedContactInList.Phone);
        Assert.Equal(updatedContact.Address, updatedContactInList.Address);
    }

    [Fact]
    public void RemoveContact_ShouldRemoveContact_WhenContactExists()
    {
        // Arrange
        var contactService = new ContactService();
        var contact = new Contact();
        contactService.Add(contact);

        // Act
        contactService.Remove(contact);

        // Assert
        var contacts = contactService.GetAll();
        Assert.DoesNotContain(contact, contacts);
    }
}



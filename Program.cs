using System;
using System.Collections.Generic;

class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}

class AddressBook
{
    private Dictionary<string, Contact> contacts; // store contacts
    public AddressBook()
    {
        contacts = new Dictionary<string, Contact>(); // start dictionary
    }

    public void AddContact(Contact contact)
    {
        try
        {
            if (!contacts.ContainsKey(contact.Email))
            {
                contacts.Add(contact.Email, contact); // add contact to dictionary
            }
            else
            {
                throw new ArgumentException("Contact with the same email exists in the address book.");
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message); //print error message if contact already exists
        }
    }

    public Contact GetByEmail(string email)
    {
        try
        {
            if (contacts.TryGetValue(email, out Contact contact))
            {
                return contact; // return contaft if found
            }
            else
            {
                throw new ArgumentException("Contact not found in the address book");
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message); // print error if contact not found
            return null;
        }
    }
}



class Program
{
    /*
        1. Add the required classes to make the following code compile.
        

        2. Run the program and observe the exception.

        3. Add try/catch blocks in the appropriate locations to prevent the program from crashing
            Print meaningful error messages in the catch blocks.
    */
    

    static void Main(string[] args)
    {

        try
        {

        // Create a few contacts
        Contact bob = new Contact() {
            FirstName = "Bob", LastName = "Smith",
            Email = "bob.smith@email.com",
            Address = "100 Some Ln, Testville, TN 11111"
        };
        Contact sue = new Contact() {
            FirstName = "Sue", LastName = "Jones",
            Email = "sue.jones@email.com",
            Address = "322 Hard Way, Testville, TN 11111"
        };
        Contact juan = new Contact() {
            FirstName = "Juan", LastName = "Lopez",
            Email = "juan.lopez@email.com",
            Address = "888 Easy St, Testville, TN 11111"
        };


        // Create an AddressBook and add some contacts to it
        AddressBook addressBook = new AddressBook();
        addressBook.AddContact(bob);
        addressBook.AddContact(sue);
        addressBook.AddContact(juan);

        // Try to addd a contact a second time
        try
        {
             addressBook.AddContact(sue);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        // Create a list of emails that match our Contacts
        List<string> emails = new List<string>() {
            "sue.jones@email.com",
            "juan.lopez@email.com",
            "bob.smith@email.com",
        };

        // Insert an email that does NOT match a Contact
        emails.Insert(1, "not.in.addressbook@email.com");


        //  Search the AddressBook by email and print the information about each Contact
        foreach (string email in emails)
        {
            try
            {
            Contact contact = addressBook.GetByEmail(email);
            if (contact != null)
            {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Name: {contact.FullName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Address: {contact.Address}");
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
    
    catch (Exception e)
    {
        Console.WriteLine("An error occured: " + e.Message);
    }
}
}
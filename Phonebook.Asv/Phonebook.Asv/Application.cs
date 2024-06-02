﻿using Phonebook.Data;
using Phonebook.Models;
using Phonebook.Helper;
using Phonebook.Queries;

namespace Phonebook;

internal class Application
{
    internal void MainMenu()
    {
        bool runApp = true;
        while (runApp)
        {
            Console.Clear();
            string option = Display.GetSelection("Hi! What do you wish to do?", new List<string> { "Create Contact", "Edit Contact", "Delete Contact", "View Contacts", "Send Message/Email", "Quit" });
            switch (option)
            {
                case "Create Contact":
                    CreateContact();
                    break;
                case "Edit Contact":
                    EditContacts();
                    break;
                case "Delete Contact":
                    DeleteContact();
                    break;
                case "View Contacts":
                    ViewContacts();
                    break;
                case "Send Message/Email Contact":
                    ContactContacts();
                    break;
                case "Quit":
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }

    private void ContactContacts()
    {
        throw new NotImplementedException();
    }

    private void ViewContacts()
    {
        string option = Display.GetSelection("Hi! Do you wish to see all contacts or view a specific category ?", new List<string> { "All Contacts", "View Specific Category" , "Go to Main Menu" });
        if(option == "View Specific Category")
        {
            List<string> categories = DbQueries.GetAllCategories();
            string selectedCategory = Display.GetSelection("Please select from the list of categories", categories);
            List<Contact> contacts = DbQueries.GetContactsSpecificCategory(selectedCategory);
            Console.WriteLine("Following are the contacts in the {0} category", selectedCategory);
            Display.ShowContacts(["Id","Name", "Phone-no", "Emailid"], contacts);
            Console.ReadLine();
        }
        else if(option == "All Contacts")
        {
            List<Contact> contacts = DbQueries.GetAllContacts();
            Display.ShowContacts(["Id", "Name", "Phone-no", "Emailid"], contacts);
            Console.ReadLine();
        }
       
    }

    private void DeleteContact()
    {
        throw new NotImplementedException();
    }

    private void EditContacts()
    {
        throw new NotImplementedException();
    }

    private void CreateContact()
    {
        DbQueries.CreateDefaultCategory();
        using ContactContext context = new ContactContext();
        Contact contact = new Contact();
        Console.Write("Enter Name: ");
        contact.ContactName = Console.ReadLine();
        do
        {
            Console.Write("Enter Email: ");
            contact.ContactEmailid = Console.ReadLine();
        } while (!InputValidator.IsValidEmail(contact.ContactEmailid));
        do
        {
            Console.Write("Enter Phone Number with country code: ");
            contact.ContactPhoneno = Console.ReadLine();
        } while (!InputValidator.IsValidPhoneNumber(contact.ContactPhoneno));
        string option = Display.GetSelection("Do you wish to register this contact under a specific category?", new List<string> {"Yes", "No"});
        if (option == "Yes")
        {
            List<string> categories = DbQueries.GetAllCategories();
            categories.Add("Create a new category");
            string selectedCategory = Display.GetSelection("Please select from the list of categories", categories);
            if(selectedCategory == "Create a new category")
            {
                string category;
                do
                {
                    Console.Write("Enter a new category name: ");
                    category = Console.ReadLine();
                } while (DbQueries.IsCategoryAlreadyPresent(category));
                DbQueries.CreateCategory(category);
                contact.CategoryId = DbQueries.GetCategoryId(category);
            }
            else
                contact.CategoryId = DbQueries.GetCategoryId(selectedCategory);
        }
        else
            contact.CategoryId = DbQueries.GetCategoryId("Default");
        context.Add(contact);
        context.SaveChanges();
        Console.WriteLine("Contact added successfully! Press any key to continue....");
        Console.ReadLine();
    }
}

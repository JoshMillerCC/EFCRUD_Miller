using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationalLayer
{
    class Menu
    {
        public static void menu(int switchChange)
        {
            switch (switchChange)
            {
                case 1:
                    //add new customer
                    Console.WriteLine("What is the customers first name?");
                    string firstName = Console.ReadLine();
                    while(string.IsNullOrWhiteSpace(firstName))
                    { 
                        Console.WriteLine("First name cannot be empty.");
                        firstName = Console.ReadLine();
                    }
                    Console.WriteLine("What is the customers last name?");
                    string lastName = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(lastName))
                    {
                        Console.WriteLine("Last name cannot be empty.");
                        lastName = Console.ReadLine();
                    }
                    Console.WriteLine("What city is the customer from?");
                    string city = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(city))
                    { city = null; }
                    Console.WriteLine("What country is the customer from?");
                    string country = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(country))
                    { country = null; }
                    Console.WriteLine("What is the customers phone number?");
                    string phone = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(phone))
                    { phone = null; }

                    CRUDOperations.addCustomer(firstName, lastName, city, country, phone);
                    Console.WriteLine(CRUDOperations.showAllCustomers());
                    break;
                case 2:
                    //delete customer
                    Console.WriteLine("Which customer would you like to delete? (Last name)");
                    string deleteCust = Console.ReadLine();

                    CRUDOperations.deleteCustomer(deleteCust);
                    Console.WriteLine(CRUDOperations.showAllCustomers());
                    break;
                case 3:
                    //update customer
                    Console.WriteLine("Which customer would you like to update? (Last name)");
                    string updateCust = Console.ReadLine();

                    CRUDOperations.updateCustomer(updateCust);
                    Console.WriteLine(CRUDOperations.showAllCustomers());
                    break;
                case 4:
                    //find customer
                    Console.WriteLine("Which customer(s) would you like to find? (Last name)");
                    string findCust = Console.ReadLine();
                    Console.WriteLine(CRUDOperations.findCustomer(findCust));
                    break;
                case 5:
                    //show customers by filter
                    string findcust = "";
                    string filterYN = "";
                    string startingChar = "";

                    Console.WriteLine("Do you want to filter your search? Y/N");
                    filterYN = Console.ReadLine().ToUpper();
                    while(filterYN != "Y" && filterYN != "N")
                    {
                        Console.WriteLine("Pick 'Y' or 'N'");
                        filterYN = Console.ReadLine();
                    }

                    if (filterYN == "N")
                    {
                        //find customer
                        Console.WriteLine("Which customer(s) would you like to find? (Last name)");
                        findCust = Console.ReadLine();
                        Console.WriteLine(CRUDOperations.findCustomer(findCust));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Do you want to filter by (1)Last name, (2)City? or (3)starting character of last name");
                        string lastNameCityFilter = Console.ReadLine();
                        if(lastNameCityFilter == "1")
                        {
                            Console.WriteLine("What is the last name?");
                            startingChar = Console.ReadLine();
                        }
                        else if(lastNameCityFilter == "2")
                        {
                            Console.WriteLine("What is the city?");
                            startingChar = Console.ReadLine();
                        }
                        else if(lastNameCityFilter == "3")
                        {
                            Console.WriteLine("What is the first character of the last name?");
                            startingChar = Console.ReadLine();
                        }
                        Console.WriteLine(CRUDOperations.filter(lastNameCityFilter, startingChar));
                    }
                    break;
                case 6:
                    //quit
                    Environment.Exit(0);
                    break;
                default:
                    //1-6 not chosen
                    Console.WriteLine("Incorrect choice, please try again.");
                    break;
            }
        }
    }
}

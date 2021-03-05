using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace PresentationalLayer
{
    class CRUDOperations
    {
        static SalesContext sc = new SalesContext();
        public static string showAllCustomers()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Customer c in sc.Customers)
            {
                sb.Append("Name: " + c.FirstName + " " + c.LastName + " || " + "City: " + c.City + " || " + "Country: " + c.Country + " || " + "Phone Number: " + c.Phone + "\n");
            }
            return sb.ToString();
        }
        public static void addCustomer(string firstName, string lastName, string city, string country, string phone)
        {
            Customer newCust = new Customer();
            newCust.FirstName = firstName;
            newCust.LastName = lastName;
            newCust.City = city;
            newCust.Country = country;
            newCust.Phone = phone;
            sc.Add(newCust);
            sc.SaveChanges();
            Console.WriteLine("Customer added.");
        }
        public static void deleteCustomer(string deleteCust)
        {
            int lastNameMatchNum = 0;
            foreach (Customer c in sc.Customers.Where(c => c.LastName.ToLower() == deleteCust.ToLower()))
            {
                lastNameMatchNum++;
            }
            if (lastNameMatchNum == 1)
            {
                Customer removeCust = sc.Customers.Single(c => c.LastName.ToLower() == deleteCust);
                Console.WriteLine("Removing: " + removeCust.LastName + ", " + removeCust.FirstName);
                sc.Customers.Remove(removeCust);
                Console.WriteLine("Customer deleted.");
            }
            else if (lastNameMatchNum > 1)
            {
                Customer removeMultCust;
                Console.WriteLine("Multiple Matches Found");
                foreach (Customer c in sc.Customers.Where(c => c.LastName.ToLower() == deleteCust.ToLower()))
                {
                    Console.WriteLine("Delete: " + c.LastName + ", " + c.FirstName + "? Y/N");
                    string yN = Console.ReadLine().ToLower();
                    if (yN == "y")
                    {
                        removeMultCust = c;
                        sc.Customers.Remove(removeMultCust);
                        Console.WriteLine("Customer deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Customer skipped.");
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("No Matches Found");
                return;
            }
            sc.SaveChanges();
        }
        public static string findCustomer(string findCust)
        {
            StringBuilder sb = new StringBuilder();
            int increment = 0;
            foreach(Customer c in sc.Customers.Where(c=>c.LastName == findCust))
            {
                sb.Append("Name: " + c.FirstName + " " + c.LastName + " || " + "City: " + c.City + " || " + "Country: " + c.Country + " || " + "Phone Number: " + c.Phone + "\n");
                increment++;
            }
            if (increment == 0)
            { sb.Append("No matches found."); }

            return sb.ToString();
        }
        public static string filter(string lastNameCityFilter, string startingChar)
        {
            StringBuilder sb = new StringBuilder();

            if(lastNameCityFilter == "1")
            {
                foreach(Customer c in sc.Customers.Where(c=>c.LastName.Equals(startingChar)))
                {
                    sb.Append("Name: " + c.FirstName + " " + c.LastName + " || " + "City: " + c.City + " || " + "Country: " + c.Country + " || " + "Phone Number: " + c.Phone + "\n");
                }
            }
            else if(lastNameCityFilter == "2")
            {
                foreach (Customer c in sc.Customers.Where(c => c.City.Equals(startingChar)))
                {
                    sb.Append("Name: " + c.FirstName + " " + c.LastName + " || " + "City: " + c.City + " || " + "Country: " + c.Country + " || " + "Phone Number: " + c.Phone + "\n");
                }
            }
            else if (lastNameCityFilter == "3")
            {
                foreach (Customer c in sc.Customers.Where(c => c.LastName.StartsWith(startingChar)))
                {
                    sb.Append("Name: " + c.FirstName + " " + c.LastName + " || " + "City: " + c.City + " || " + "Country: " + c.Country + " || " + "Phone Number: " + c.Phone + "\n");
                }
            }
            else
            {
                sb.Append("No filter applied");
            }
            return sb.ToString();
        }
        public static void updateCustomer(string updateCust)
        {
            int increment = 0;
            foreach(Customer c in sc.Customers.Where(c=>c.LastName == updateCust))
            {
                increment++;
            }
            if(increment == 1)
            {
                Customer updater = sc.Customers.Single(c => c.LastName.ToLower() == updateCust);

                Console.WriteLine("Update first name? Y/N");
                string fnyn = Console.ReadLine().ToUpper();
                while(fnyn != "Y" && fnyn != "N")
                {
                    Console.WriteLine("Pick 'Y' or 'N'");
                    fnyn = Console.ReadLine().ToUpper();
                }
                if(fnyn == "Y")
                {
                    Console.WriteLine("What is the new first name?");
                    string newFirstName = Console.ReadLine();
                    while (newFirstName == "")
                    {
                        Console.WriteLine("Enter a name please.");
                        newFirstName = Console.ReadLine();
                    }
                    updater.FirstName = newFirstName;
                }

                Console.WriteLine("Update last name? Y/N");
                string lnyn = Console.ReadLine().ToUpper();
                while (lnyn != "Y" && lnyn != "N")
                {
                    Console.WriteLine("Pick 'Y' or 'N'");
                    lnyn = Console.ReadLine().ToUpper();
                }
                if (lnyn == "Y")
                {
                    Console.WriteLine("What is the new last name?");
                    string newLastName = Console.ReadLine();
                    while (newLastName == "")
                    {
                        Console.WriteLine("Enter a name please.");
                        newLastName = Console.ReadLine();
                    }
                    updater.LastName = newLastName;
                }

                Console.WriteLine("Update city? Y/N");
                string ciyn = Console.ReadLine().ToUpper();
                while (ciyn != "Y" && ciyn != "N")
                {
                    Console.WriteLine("Pick 'Y' or 'N'");
                    ciyn = Console.ReadLine().ToUpper();
                }
                if (ciyn == "Y")
                {
                    Console.WriteLine("What is the new city?");
                    string newCity = Console.ReadLine();
                    if (newCity.Equals(""))
                        newCity = null;
                    updater.City = newCity;
                }

                Console.WriteLine("Update country? Y/N");
                string coyn = Console.ReadLine().ToUpper();
                while (coyn != "Y" && coyn != "N")
                {
                    Console.WriteLine("Pick 'Y' or 'N'");
                    coyn = Console.ReadLine().ToUpper();
                }
                if (coyn == "Y")
                {
                    Console.WriteLine("What is the new city?");
                    string newCountry = Console.ReadLine();
                    if (newCountry.Equals(""))
                        newCountry = null;
                    updater.Country = newCountry;
                }

                Console.WriteLine("Update phone number? Y/N");
                string pnyn = Console.ReadLine().ToUpper();
                while (pnyn != "Y" && pnyn != "N")
                {
                    Console.WriteLine("Pick 'Y' or 'N'");
                    pnyn = Console.ReadLine().ToUpper();
                }
                if (pnyn == "Y")
                {
                    Console.WriteLine("What is the new phone number?");
                    string newPhone = Console.ReadLine();
                    if (newPhone.Equals(""))
                        newPhone = null;
                    updater.Phone = newPhone;
                }

                Console.WriteLine("Customer updated.");
            }
            else if(increment > 1)
            {
                Console.WriteLine("Multiple matches found.");
                foreach (Customer c in sc.Customers.Where(c => c.LastName.ToLower() == updateCust.ToLower()))
                {
                    Customer updater = c;
                    Console.WriteLine("Update: " + c.LastName + ", " + c.FirstName + "? Y/N");
                    string yN = Console.ReadLine().ToUpper();
                    while (yN != "Y" && yN != "N")
                    {
                        Console.WriteLine("Pick 'Y' or 'N'");
                        yN = Console.ReadLine().ToUpper();
                    }
                    if (yN == "Y")
                    {
                        Console.WriteLine("Update first name? Y/N");
                        string fnyn = Console.ReadLine().ToUpper();
                        while (fnyn != "Y" && fnyn != "N")
                        {
                            Console.WriteLine("Pick 'Y' or 'N'");
                            fnyn = Console.ReadLine().ToUpper();
                        }
                        if (fnyn == "Y")
                        {
                            Console.WriteLine("What is the new first name?");
                            string newFirstName = Console.ReadLine();
                            while (newFirstName == "")
                            {
                                Console.WriteLine("Enter a name please.");
                                newFirstName = Console.ReadLine();
                            }
                            updater.FirstName = newFirstName;
                        }

                        Console.WriteLine("Update last name? Y/N");
                        string lnyn = Console.ReadLine().ToUpper();
                        while (lnyn != "Y" && lnyn != "N")
                        {
                            Console.WriteLine("Pick 'Y' or 'N'");
                            lnyn = Console.ReadLine().ToUpper();
                        }
                        if (lnyn == "Y")
                        {
                            Console.WriteLine("What is the new last name?");
                            string newLastName = Console.ReadLine();
                            while (newLastName == "")
                            {
                                Console.WriteLine("Enter a name please.");
                                newLastName = Console.ReadLine();
                            }
                            updater.LastName = newLastName;
                        }

                        Console.WriteLine("Update city? Y/N");
                        string ciyn = Console.ReadLine().ToUpper();
                        while (ciyn != "Y" && ciyn != "N")
                        {
                            Console.WriteLine("Pick 'Y' or 'N'");
                            ciyn = Console.ReadLine().ToUpper();
                        }
                        if (ciyn == "Y")
                        {
                            Console.WriteLine("What is the new city?");
                            string newCity = Console.ReadLine();
                            if (newCity.Equals(""))
                                newCity = null;
                            updater.City = newCity;
                        }

                        Console.WriteLine("Update country? Y/N");
                        string coyn = Console.ReadLine().ToUpper();
                        while (coyn != "Y" && coyn != "N")
                        {
                            Console.WriteLine("Pick 'Y' or 'N'");
                            coyn = Console.ReadLine().ToUpper();
                        }
                        if (coyn == "Y")
                        {
                            Console.WriteLine("What is the new country?");
                            string newCountry = Console.ReadLine();
                            if (newCountry.Equals(""))
                                newCountry = null;
                            updater.Country = newCountry;
                        }

                        Console.WriteLine("Update phone number? Y/N");
                        string pnyn = Console.ReadLine().ToUpper();
                        while (pnyn != "Y" && pnyn != "N")
                        {
                            Console.WriteLine("Pick 'Y' or 'N'");
                            pnyn = Console.ReadLine().ToUpper();
                        }
                        if (pnyn == "Y")
                        {
                            Console.WriteLine("What is the new phone number?");
                            string newPhone = Console.ReadLine();
                            if (newPhone.Equals(""))
                                newPhone = null;
                            updater.Phone = newPhone;
                        }

                        Console.WriteLine("Customer updated.");
                    }
                    else
                    {
                        Console.WriteLine("Customer skipped.");
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("No matches found.");
                return;
            }
            sc.SaveChanges();
        }
    }
}


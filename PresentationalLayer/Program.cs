using System;
using DataLayer;
using System.Text;

namespace PresentationalLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int switchChange = 0;
            while(true)
            {
                Console.WriteLine("Pick an option");
                Console.WriteLine("1. Add a customer");
                Console.WriteLine("2. Delete a customer");
                Console.WriteLine("3. Update a customer");
                Console.WriteLine("4. Find a customer by last name");
                Console.WriteLine("5. Filter customers by last name or city");
                Console.Write("6. Quit\n");
                switchChange = Convert.ToInt32(Console.ReadLine());
                Menu.menu(switchChange);
            }
        }
    }
}

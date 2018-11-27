using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp2
{
    class Program
    {
        
        static void Main(string[] args)
        { 
        
            string Filename = @"C:\test\mydoc.txt";
  
            if (!Directory.Exists(@"C:\test\"))
            {
                    Directory.CreateDirectory(@"c:\test\");
            }
            // WriteFile(Filename);
            Console.WriteLine(File.ReadAllText(Filename));
            Console.ReadKey();

            List<Customer> list = new List<Customer>();
            int choise = 0;
            int i = 0;

            string filetext = File.ReadAllText(Filename);
            string[] name = filetext.Split(',');
            List<string> list2 = new List<string>(name);
            list2.RemoveAt(0);

            foreach (string word in list2)
            {
                string Name = list2[i];
                AddCustomer(Name, list);
                i++;
            }

            
            Console.WriteLine("Välkommen till banken\n");
            while(choise != 7)
            {
                Console.WriteLine("Ange vilket av följande alternativ önskar du göra.\n");

                Console.WriteLine("  1 : Lägga till en användare");
                Console.WriteLine("  2 : Ta bort en användare");
                Console.WriteLine("  3 : Visa alla befintliga användare");
                Console.WriteLine("  4 : Visa saldo för en användare");
                Console.WriteLine("  5 : Gör en insättning för en användare");
                Console.WriteLine("  6 : Gör ett uttag för en användare");
                Console.WriteLine("  7 : Avsluta programmet\n");

                Console.Write("Skriv in ditt tal: ");

                
                try
                {
                    choise = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exection: " + e.Message);
                    Console.ReadKey();
                }
                //test
                switch (choise)
                {
                    case 1:
                        //lägg till användare
                        Console.Clear();
                        Console.WriteLine("du valde val 1");

                        Console.Write("Ange ditt användarens namn: ");
                        string Name = Console.ReadLine();
                        AddCustomer(Name, list);

                        //Sara kladdar:
                        /*
                        Console.Write("Ange ditt användarens namn: ");
                        string customerName = Console.ReadLine();
                        AddCustomer(customerName);
                        */
                        break;
                    case 2:
                        i = 0;
                        Console.WriteLine("du valde val 2");
                        foreach (Customer customer in list)
                        {
                            Console.WriteLine(i + " :" + customer.ShowCustomerName());
                            i++;
                        }
                        Console.WriteLine("Ange nummret för den ancändare du önskar ta bort : ");
                        string deleteindexString = Console.ReadLine();
                        int deleteindex = int.Parse(deleteindexString);
                        list.RemoveAt(deleteindex);
                        break;
                    //ta bort användare
                    case 3:
                        i = 0;
                        Console.WriteLine("du valde val 3");
                        foreach(Customer info in list)
                        {
                            i++;
                            Console.WriteLine(i + " :" + info.ShowCustomerName());
                        }
                        break;
                    //visa alla befintliga användare
                    case 7:
                        string mydoc = "";
                        foreach( Customer info in list)
                        {
                            mydoc = info.ShowCustomerName() + "," + mydoc;
                        }
                        File.WriteAllText(Filename, mydoc);
                        break;
                        //avsluta programmet                   
                }
            }

        }
        

        static void AddCustomer(string Name, List<Customer> list)
        {
            Customer Customer1 = new Customer();
            Customer1.Name = Name;
            list.Add(Customer1);
        }
        static void ReadFile(string Filename)
        {

            Console.WriteLine(File.ReadAllText(Filename));
            Console.WriteLine("again....");
            string[] lines = File.ReadAllLines(Filename);
            foreach (string i in lines)
            {
                Console.WriteLine(i);
            }
        }
    }
}

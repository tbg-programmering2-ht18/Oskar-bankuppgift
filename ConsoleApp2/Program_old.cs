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
            //ReadFile(Filename);
            Console.ReadKey();
            
            File.ReadAllText(Filename,mydoc)

            int choise = 0;

            List<Customer> list = new List<Customer>();
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

                string Val = Console.ReadLine();
                Console.Clear();
                try
                {
                    choise = int.Parse(Val);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exection: " + e.Message);
                    Console.ReadKey();
                }
                int i = 0;
                //test
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("du valde val 1");
                        
                        Customer Customer1 = new Customer();
                        list.Add(Customer1);
                        Console.Write("Ange ditt användarens namn: ");
                        Customer1.Name = Console.ReadLine();

                        //Sara kladdar:
                        /*
                        Console.Write("Ange ditt användarens namn: ");
                        string customerName = Console.ReadLine();
                        AddCustomer(customerName);
                        */
                        break;
                    //lägg till användare
                    case 2:
                        Console.WriteLine("du valde val 2");
                        foreach (Customer customer in list)
                        {
                            Console.WriteLine(i + " :" + customer.ShowInkomstInfo());
                            i++;
                        }
                        Console.WriteLine("Ange nummret för den ancändare du önskar ta bort : ");
                        string deleteindexString = Console.ReadLine();
                        int deleteindex = int.Parse(deleteindexString);
                        list.RemoveAt(deleteindex);
                        break;
                    //ta bort användare
                    case 3:
                        Console.WriteLine("du valde val 3");
                        foreach(Customer info in list)
                        {
                            i++;
                            Console.WriteLine(i + " :" + info.ShowInkomstInfo());
                        }
                        break;
                    //visa alla befintliga användare
                    case 7:
                        string mydoc = "";
                        foreach( Customer info in list)
                        {
                            mydoc = mydoc +","+ info.ShowInkomstInfo();
                        }
                        File.WriteAllText(Filename, mydoc);
                        break;
                        //avsluta programmet                   
                }
            }

        }

        static void testcode()
        {
            string s = " there is a cat";
            // Split string on spaces.
            // ... This will separate all the words.
            string[] words = s.Split(' ');
            foreach (string word in words)
            {
                if (word != "")
                {
                    Console.WriteLine(word);
                }
            }
        }

        static void WriteFile(string Filename, string mydoc)
        {
            
        }
        static void ReadFile(string Filename)
        {
            string text = File.ReadAllText(Filename);

            Console.WriteLine(text);
            Console.WriteLine("again....");
            string[] lines = File.ReadAllLines(Filename);
            foreach (string i in lines)
            {
                Console.WriteLine(i);
            }
        }
    }
}

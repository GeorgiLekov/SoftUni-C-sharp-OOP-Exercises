using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Split by = to get the customer names and money separated and also by ; to separate the different customers
                string[] input = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                Dictionary<string, Person> customers = new Dictionary<string, Person>();
                // Add to dictionary all customers and their money
                for (int i = 0; i < input.Length; i += 2)
                {
                    customers.Add(input[i], new Person(input[i], decimal.Parse(input[i+1])));
                }

                string[] inputProducts = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                Dictionary<string, Product> products = new Dictionary<string, Product>();
                for (int i = 0; i < inputProducts.Length; i += 2)
                {
                    products.Add(inputProducts[i], new Product(inputProducts[i], decimal.Parse(inputProducts[i+1])));
                }

                string command = Console.ReadLine();

                while(command != "END")
                {
                    string[] instruction = command.Split().ToArray();
                    string customerName = instruction[0];
                    string productName = instruction[1];
                    
                    if (customers.ContainsKey(customerName))
                    {
                        if (products.ContainsKey(productName))
                        {
                            Person currentCustomer = customers[customerName];
                            Product currentProduct = products[productName];

                            if (currentCustomer.Money-currentProduct.Cost>=0)
                            {
                                customers[customerName].AddBag(products[productName]);
                                customers[customerName].Money -= currentProduct.Cost;
                                Console.WriteLine($"{customerName} bought {productName}");
                            }
                          
                            else
                            {
                                Console.WriteLine($"{customerName} can't afford {productName}");
                            }
                        }
                    }
                    command = Console.ReadLine();
                }

                foreach(var customer in customers)
                {
                    if (customer.Value.Count <= 0)
                    {
                        Console.WriteLine($"{customer.Key} - Nothing bought ");
                    }
                    else
                    {
                        List<string> namesOfProducts = new List<string>();
                        foreach(var item in customer.Value.Bag)
                        {
                            namesOfProducts.Add(item.Name);
                        }
                        Console.WriteLine($"{customer.Key} - {string.Join(", ", namesOfProducts)}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

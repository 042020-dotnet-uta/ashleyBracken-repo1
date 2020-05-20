using GettingStartedClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorClient client = new CalculatorClient();
            List<Fruit> fruits = new List<Fruit>();
            Fruit Apple = new Fruit();
            Fruit Pear = new Fruit();
            Fruit Orange = new Fruit();
            Pear.Name = "Pear";
            Orange.Name = "Orange";
            Apple.Name = "Apple";

             client.AddAFruit(fruits, Orange);
           // fruits = client.AddAFruit(fruits, Pear);
            //fruits = client.AddAFruit(fruits, Apple);

            Console.WriteLine("Adding {Apple},{Pear},{Orange} to Fridge");
            //int index = 2;

            //client.RemoveAFruit(fruits, index);

            //client.Total(fruits);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;

namespace GettingStartedLib
{
    public class CalculatorService : ICalculator
    {
        public List<Fruit> AddAFruit(List<Fruit> fruitList,Fruit fruit)
        {
            fruitList.Add(fruit);
            return fruitList;
        }
        public List<Fruit> RemoveAFruit(List<Fruit> fruitList, int index)
        {
            for (var i = 0; i < fruitList.Count; i++)
            {
                if (i==index)
                {
                    fruitList.RemoveAt(index);
                }
            }
            return fruitList;
        }
        public int Total(List<Fruit> fruits)
        {
         var total =  fruits.Count;
            return total;
        } 
    }
}
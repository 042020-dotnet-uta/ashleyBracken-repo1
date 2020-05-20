using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace GettingStartedLib
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        int Total(List<Fruit> fruits);
        [OperationContract]
        List <Fruit> AddAFruit(List<Fruit> fruitList,Fruit fruit);
        [OperationContract]
        List<Fruit> RemoveAFruit(List<Fruit> fruitList,int index);
    }
}
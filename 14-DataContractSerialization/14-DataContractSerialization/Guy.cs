using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MyNamespace
{
  [DataContract] //over the class name
  //[DataContract(Namespace="")]// <- to hide the namespace
  class Guy
  {
    [DataMember] //on every property
    public string name = "";

    [DataMember(Name="PocketMoney")] //on every property
    public int cash = 0;

    //[DataMember] <- not on methods
    public Guy(string name, int cash)
    {
      this.name = name;
      this.cash = cash;
    }
  }
}

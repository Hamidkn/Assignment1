using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConsoleAssignment.Model
{
  [DataContract]
  public class Output
  {
    public Output(int id)
    {
      ID = id;
    }

    [DataMember]
    public int ID { get; private set; }

    [DataMember]
    public List<Different> ListDifferents { get; set; }

    public override string ToString()
    {
      return $"id= {ID} , list of differents= {ListDifferents}";
    }
  }
}

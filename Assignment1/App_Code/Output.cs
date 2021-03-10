using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for Output
/// </summary>
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
    return "Id = " + ID + " , list of differents = " + ListDifferents;
  }
}
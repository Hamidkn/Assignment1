using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for Model
/// </summary>
[DataContract]
public class Model
{
  public Model(int id, string value)
  {
    Id = id;
    Value = value;
  }

  [DataMember]
  public int Id { get; set; }

  [DataMember]
  public string Value { get; set; }

  public override string ToString()
  {
    return "Id = " + Id + " , Value = " + Value;
  }
}
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConsoleAssignment.Model
{
  [DataContract]
  public class Different
  {
    public Different(int index, int length)
    {
      Index = index;
      Length = length;
    }

    /// <summary>
    /// Difference starts from the index
    /// </summary>
    [DataMember]
    public int Index { get; private set; }

    /// <summary>
    /// Length of difference
    /// </summary>
    [DataMember]
    public int Length { get; private set; }

    public override string ToString()
    {
      return $"Index= {Index} ,Length = {Length}";
    }
  }
}

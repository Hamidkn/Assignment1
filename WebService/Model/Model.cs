using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace ConsoleAssignment.Model
{
    [DataContract]
    public class Model
    {
        public Model(int id, string value)
        {
            Id = id;
            Value = value;
        }

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Value { get; private set; }

        public override string ToString()
        {
            return $"id= {Id} value= {Value}";
        }
    }
}
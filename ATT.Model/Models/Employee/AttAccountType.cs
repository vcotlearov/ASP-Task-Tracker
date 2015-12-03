using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Infrastructure.Models.Employee
{
    public class AttAccountType
    {
        public int Id { get; }
        public string Type { get; }

        public AttAccountType() : this(1, "Basic")
        {
            
        }

        public AttAccountType(int id)
        {
            Id = id;
        }

        public AttAccountType(int id, string type) : this(id)
        {
            Type = type;
        }
    }
}

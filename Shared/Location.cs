using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Shared
{
    public class Location
    {
        public int Id { get; set; }
        public string OccupantName { get; set; }
        public Address Address { get; set; }
    }
}

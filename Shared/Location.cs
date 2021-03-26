using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Shared
{
    public class Location
    {
        public int Id { get; set; }
        public string OccupantName { get; set; }
        public MelissaAddress Address { get; set; }
        public string OwnerId { get; set; }
    }
}

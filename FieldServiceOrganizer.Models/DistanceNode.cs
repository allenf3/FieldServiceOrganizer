using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Models
{
    public class DistanceNode
    {
        public Location From { get; set; }
        public Location To { get; set; }
        public int TimeInSeconds { get; set; }
        public int DistanceInFeet { get; set; }
    }
}

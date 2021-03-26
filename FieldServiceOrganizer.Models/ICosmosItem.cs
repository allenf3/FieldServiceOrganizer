using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Models
{
    public interface ICosmosItem
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; }
    }
}

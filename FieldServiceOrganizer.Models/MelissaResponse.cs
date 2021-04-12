using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Models
{
    public class MelissaResponse
    {
        public string Version { get; set; }
        public string TransmissionReference { get; set; }
        public string TransmissionResults { get; set; }
        public string TotalRecords { get; set; }
        public MelissaNormalizedLocation[] Records { get; set; }
    }
}

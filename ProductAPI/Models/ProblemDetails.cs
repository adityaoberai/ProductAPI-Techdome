using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class ProblemDetails
    {
        public string type { get; set; }
        public string title { get; set; }
        public Int32 status { get; set; }
        public string detail { get; set; }
        public string instance { get; set; }
    }
}

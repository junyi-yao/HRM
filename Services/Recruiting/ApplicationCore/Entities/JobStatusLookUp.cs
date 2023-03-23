using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class JobStatusLookUp
    {
        //open, pending, closed, postponed
        public int Id { get; set; }
        public string JobStatusCode { get; set; }
        public string JobStatusDescription { get; set; }
    }
}

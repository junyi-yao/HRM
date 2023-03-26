using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class JobRequestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public DateTime StartDate { get; set; }
        public int NumberOfPositions { get; set; }
    }
}

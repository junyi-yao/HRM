using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class JobRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Title of the Job")]
        [StringLength(256)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter Job Description")]
        [StringLength(5000)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter Job Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please enter number")]
        public int NumberOfPositions { get; set; }
    }
}

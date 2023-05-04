using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public partial class Students
    {
       

        public int Id { get; set; }

      [Required(ErrorMessage ="PLEASE FILL OUT THIS FEILD")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "PLEASE FILL OUT THIS FEILD")]
        public string ContactNumber { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_and_ADO.NET.Models
{
    public class Employer
    {
        [Display(Name ="ID")]
        public int EmployerID { get; set; }

        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="City is required")]
        public string City { get; set; }

        [Required(ErrorMessage ="Address is required")]
        public string Address { get; set; }
    }
}
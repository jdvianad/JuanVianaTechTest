﻿using System.ComponentModel.DataAnnotations;

namespace ReviewApplication.Domain
{
    public class Customer
    {

        [Required]
        public  int Id { get; set; }
        public string Name { get;set;}
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }



    }
}

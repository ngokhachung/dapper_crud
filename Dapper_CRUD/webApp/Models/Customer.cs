﻿namespace webApp.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime DOB { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int CityId { get; set; }
       
        [Required]
        public int StateId { get; set; }
      
        [Required]
        public string  Gender { get; set; }

        public string State { get; set; }
        public string City { get; set; }
    }
}

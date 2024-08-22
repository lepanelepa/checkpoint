using System.ComponentModel.DataAnnotations;

namespace CheckPoint.Models
{
    public class Car
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Number { get; set; }
 
    }
}

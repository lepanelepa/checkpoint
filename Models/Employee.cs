using System.ComponentModel.DataAnnotations;

namespace CheckPoint.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FistName { get; set; }

        [Required]
        public string LastName { get; set; }    


        public List<Car> Cars { get; set; }

    }
}

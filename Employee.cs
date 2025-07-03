using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeDemo.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender{ get; set; }
        public int Age{ get; set; }
        public long Phone { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}

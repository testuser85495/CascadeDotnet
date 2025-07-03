using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeDemo.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        // Navigation property
        public State State { get; set; }
    }
}

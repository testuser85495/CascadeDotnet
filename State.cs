using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeDemo.Models
{
    public class State
    {
        
        public int StateId { get; set; }
        public string StateName { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<City> City { get; set; }
    }
}

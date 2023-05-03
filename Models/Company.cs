using System.ComponentModel.DataAnnotations;

namespace ABCDapperWEBAPI.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}

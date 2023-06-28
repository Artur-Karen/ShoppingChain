using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShoppingChain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Date of employment")]
        public DateTime DateOfEmployment { get; set; }
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public int? ShopId { get; set; }
        public Shop? Shop { get; set; }
        public int? BakeryId { get; set; }
        public Bakery? Bakery { get; set; }
        public int? StorageId { get; set; }
        public Storage? Storage { get; set; }
    }
}

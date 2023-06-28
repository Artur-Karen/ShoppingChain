using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShoppingChain.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [ValidateNever]
        public ICollection<Employee> Employees { get; set; }
        [ValidateNever]
        public Bakery Bakery { get; set; }
        [ValidateNever]
        public Storage Storage { get; set; }
    }
}

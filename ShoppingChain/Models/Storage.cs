using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ShoppingChain.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name ="Phone number")]
        public string PhoneNumber { get; set; }
        [ValidateNever]
        public ICollection<Employee> Employees { get; set; }
        public int ShopId { get; set; }
        [ValidateNever]
        public Shop Shop { get; set; }
    }
}

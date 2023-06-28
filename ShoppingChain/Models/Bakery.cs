using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ShoppingChain.Models
{
    public class Bakery
    {
        public int Id { get; set; }
        [Display(Name ="Bakery for")]
        public string BakeryFor { get; set; }
        [Display(Name ="Phone number")]
        public string PhoneNumber { get; set;}
        [ValidateNever]
        public int ShopId { get; set; }
        [ValidateNever]
        public Shop Shop { get; set;}
        [ValidateNever]
        public ICollection<Employee> Employees { get; set; }

    }
}

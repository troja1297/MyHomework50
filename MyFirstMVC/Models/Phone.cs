using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVC.Models
{
    public class Phone
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Компания-производитель")]
        public string Company { get; set; }
        [Display(Name = "Цена")]
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<PhoneOnStock> PhoneOnStocks { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFirstMVC.Models
{
    public class Currencies
    {
        public int Id { get; set; }

        public string CurrencyCode { get; set; }

        public string CurrencyName { get; set; }

        public double CurrencyRate { get; set; }
    }
}
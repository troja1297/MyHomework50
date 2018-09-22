using System.Collections.Generic;

namespace MyFirstMVC.Models
{
    public class MainModelForPhone
    {
        public IEnumerable<Phone> Phone { get; set; }
        public IEnumerable<Currencies> Currencies { get; set; }
    }
}
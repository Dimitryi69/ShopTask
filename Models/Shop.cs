using System.Collections.Generic;

namespace TestTask.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string WorkHours { get; set; }

        virtual public ICollection<Product> Products { get; set; }
    }
}

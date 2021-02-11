using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMobile.Models
{
    public partial class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Phone> Phone{ get; set; }
    }
}
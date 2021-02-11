using System.ComponentModel.DataAnnotations;

namespace AMobile.Models
{
    public partial class Phone
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Capacity { get; set; }
        public string Colour { get; set; }
        public string Specs { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }



        //will make after category,maybe categoryid,and maybe image mapping
    }
}
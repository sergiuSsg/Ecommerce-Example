using System.ComponentModel.DataAnnotations;

namespace AMobile.Models
{
    [MetadataType(typeof(PhoneMetaData))]
    public partial class Phone
    {
    }
                            
    public class PhoneMetaData
    {
        [Display(Name = "Phone Name")]
        public string Name;
    }
}
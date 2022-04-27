using System.ComponentModel.DataAnnotations;

namespace Inlämning_API.Models
{
    public class Ads
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }


}

using System.ComponentModel.DataAnnotations;

namespace bulkyweb_razor_pages.Models
{
    public class Category
    {


        [Key] 
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Number Must be between range 1-100 ok.. ")]
        public int DisplayOrder { get; set; }
    }
}

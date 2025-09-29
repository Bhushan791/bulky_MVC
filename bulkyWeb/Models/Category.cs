using System.ComponentModel.DataAnnotations;

namespace bulkyWeb.Models
{
    public class Category
    {
        [Key] //if we do Id , modelnameId then automatically accepts as PK else do [Key] 
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
         public string Name { get; set;  }
        [Range(1,100, ErrorMessage ="Number Must be between range 1-100 ")]
         public int DisplayOrder { get; set; }

    }
}

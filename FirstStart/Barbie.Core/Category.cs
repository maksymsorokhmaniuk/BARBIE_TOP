using Barbie.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barbie.Core
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        public string CategoryName { set; get; }
        [Required]
        public string Username { set; get; }
        public List<Barbiee>? Barbies { get; set; }
    }

}

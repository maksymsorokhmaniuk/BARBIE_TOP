using Barbie.Core;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barbie.Core
{
    public class Barbiee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Description { set; get; }
        public string? Img { set; get; }
        [NotMapped]
        public IFormFile? ImgFile { set; get; }
        [Required]
        public int CategoryID { set; get; }
        public virtual Category? Category { set; get; }
        [Required]
        public string Username { get; set; }
    }
}
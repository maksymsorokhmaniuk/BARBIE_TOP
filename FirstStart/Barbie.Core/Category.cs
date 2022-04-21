using Barbie.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barbie.Core
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set;get; }
        public string CategoryName { set; get; }
        public string Desc { set; get; }
        public List<Barbiee> Barbies { get; set; }
    }

}

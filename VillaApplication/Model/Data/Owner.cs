using System.ComponentModel.DataAnnotations;
using VillaApplication.Model.Base;

namespace VillaApplication.Model.Data
{
    public class Owner : Entity
    {
        [Required]
        public string FristName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<Villa> villas { get; set; }
    }
}

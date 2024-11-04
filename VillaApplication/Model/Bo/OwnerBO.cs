using System.ComponentModel.DataAnnotations;
using VillaApplication.Model.Base;

namespace VillaApplication.Model.Bo
{
    public class OwnerBO : EntityBO
    {
        [Required]
        public string FristName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}

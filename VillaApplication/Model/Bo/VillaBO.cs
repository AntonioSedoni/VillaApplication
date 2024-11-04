using System.ComponentModel.DataAnnotations;
using VillaApplication.Model.Base;

namespace VillaApplication.Model.Bo
{
    public class VillaBO : EntityBO
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}

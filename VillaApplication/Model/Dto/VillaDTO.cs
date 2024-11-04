using System.ComponentModel.DataAnnotations;
using VillaApplication.Model.Base;

namespace VillaApplication.Model.Dto
{
    public class VillaDTO : EntityDTO
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}

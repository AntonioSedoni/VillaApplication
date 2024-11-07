using VillaApplication.Model.Base;

namespace VillaApplication.Model.Dto
{
    public class VillaDTO : EntityDTO
    {
        public required string Name { get; set; }
        public int OwnerId { get; set; }
    }
}

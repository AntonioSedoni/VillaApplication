using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VillaApplication.Model.Base;

namespace VillaApplication.Model.Data
{
    public class Villa : Entity
    {
        public string Name { get; set; }
        public int OwnerId { get; set; }

        public virtual Owner Owner { get; set; }
    }
}

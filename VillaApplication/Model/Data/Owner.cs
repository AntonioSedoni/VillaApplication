using System.ComponentModel.DataAnnotations;
using VillaApplication.Model.Base;

namespace VillaApplication.Model.Data
{
    public class Owner : Entity
    {
        public string FristName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Villa> villas { get; set; }
    }
}

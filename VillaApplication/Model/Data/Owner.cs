using VillaApplication.Model.Base;

namespace VillaApplication.Model.Data
{
    public class Owner : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Villa> villas { get; set; }
    }
}

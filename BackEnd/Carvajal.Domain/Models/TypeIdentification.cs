using System.Collections.Generic;

namespace Carvajal.Domain.Models
{
    public class TypeIdentification
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }
}

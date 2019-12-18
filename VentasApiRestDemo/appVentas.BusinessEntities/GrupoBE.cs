using System;
using System.Collections.Generic;
using System.Text;

namespace appVentas.BusinessEntities
{
   public class GrupoBE
    {
        public GrupoBE()
        {
            ProductoBE = new HashSet<ProductoBE>();
        }

        public string CodGrup { get; set; }
        public string NomGrup { get; set; }

        public virtual ICollection<ProductoBE> ProductoBE { get; set; }
    }
}

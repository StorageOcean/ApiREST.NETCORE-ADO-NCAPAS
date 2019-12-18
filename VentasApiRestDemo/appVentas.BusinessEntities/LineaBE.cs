using System;
using System.Collections.Generic;
using System.Text;

namespace appVentas.BusinessEntities
{
    public class LineaBE
    {
        public LineaBE()
        {
            ProductoBE = new HashSet<ProductoBE>();
        }

        public string CodLin { get; set; }
        public string NomLin { get; set; }

        public virtual ICollection<ProductoBE> ProductoBE { get; set; }
    }
}

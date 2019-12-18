namespace appVentas.BusinessEntities
{
    public class ProductoBE
    {
        public string CodProd { get; set; }
        public string NomProd { get; set; }
        public string CodGrup { get; set; }
        public string CodLin { get; set; }
        public string Marca { get; set; }
        public decimal CosPromC { get; set; }
        public decimal? PrecioVta { get; set; }

        public virtual GrupoBE CodGrupNavigation { get; set; }
        public virtual LineaBE CodLinNavigation { get; set; }
    }
}

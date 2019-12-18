using appVentas.BusinessLogic.Interface;
using appVentas.BusinessEntities;
using appVentas.DataAccess.Interface;
using appVentas.DataAccess.Repositorio;
using System;
using System.Collections.Generic;

namespace appVentas.BusinessLogic.Repositorio
{
    public class RepositoryProductoBL : IRepositoryProductoBL<ProductoBE>
    {
        public IRepositoryProductoDA<ProductoBE> productoDA;

        public RepositoryProductoBL(IRepositoryProductoDA<ProductoBE> productoDA)
        {
            this.productoDA = productoDA;
        }

        public List<ProductoBE> GetAllProductos()
        {
            return productoDA.GetAllProductos();
        }

        public ProductoBE GetByIdProducto(ProductoBE producto)
        {
            return productoDA.GetByIdProducto(producto);
        }

        public bool InsertProducto(ProductoBE producto)
        {
            return productoDA.InsertProducto(producto);
        }

        public bool UpdateProducto(ProductoBE producto)
        {
            return productoDA.UpdateProducto(producto);
        }

        public bool DeleteProducto(ProductoBE producto)
        {
            return productoDA.DeleteProducto(producto);
        }
    }
}

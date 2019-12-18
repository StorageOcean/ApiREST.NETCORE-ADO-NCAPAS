using System;
using System.Collections.Generic;
using System.Text;

namespace appVentas.DataAccess.Interface
{
    public interface IRepositoryProductoDA<T>
    {

        List<T> GetAllProductos();
        T GetByIdProducto(T t);
        bool InsertProducto(T t);
        bool UpdateProducto(T t);
        bool DeleteProducto(T t);
    }
}

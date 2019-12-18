using System;
using System.Collections.Generic;
using System.Text;

namespace appVentas.BusinessLogic.Interface
{
    public interface IRepositoryProductoBL<T>
    {
        List<T> GetAllProductos();
        T GetByIdProducto(T t);
        bool InsertProducto(T t);
        bool UpdateProducto(T t);
        bool DeleteProducto(T t);
    }
}

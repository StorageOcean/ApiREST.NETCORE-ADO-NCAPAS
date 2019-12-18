using appVentas.BusinessLogic.Interface;
using appVentas.BusinessEntities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace VentasApiRestDemo.Controllers
{
    [Route("api/Producto")]
    [Produces("application/json")]
    [ApiController]
    public class ProductoController : Controller
    {
        IRepositoryProductoBL<ProductoBE> repository;

        public ProductoController(IRepositoryProductoBL<ProductoBE> repository)
        {
            this.repository = repository;
        }

        //GET api/values
        [HttpGet()]
        public JsonResult GetProductos()
        {
            IEnumerable<ProductoBE> productos = repository.GetAllProductos();
            return Json(productos);
        }

        [HttpGet("{id}")]
        public JsonResult GetProducto(string id)
        {
            ProductoBE producto = new ProductoBE
            {
                CodProd = id
            };
            ProductoBE listado = repository.GetByIdProducto(producto);
            return Json(listado);
        }

        [HttpPost()]
        public IActionResult PostProducto([FromBody]ProductoBE ProductoBE)
        {
            string resultado = repository.InsertProducto(ProductoBE) ? "Registrado" : " No Registrado";
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public IActionResult PutProducto(string id, [FromBody]ProductoBE ProductoBE)
        {
            ProductoBE productoBE = new ProductoBE
            {
                CodProd = id,
                NomProd = ProductoBE.NomProd,
                CodGrup = ProductoBE.CodGrup,
                CodLin = ProductoBE.CodLin,
                Marca = ProductoBE.Marca,
                CosPromC = ProductoBE.CosPromC,
                PrecioVta = ProductoBE.PrecioVta,
            };
            string resultado = repository.UpdateProducto(ProductoBE) ? "Actualizado" : " No Actualizado";
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(string id)
        {
            ProductoBE producto = new ProductoBE
            {
                CodProd = id
            };
            string resultado = repository.DeleteProducto(producto) ? "Eliminado" : " No Eliminado";
            return Json(resultado);
        }
    }
}

using appVentas.BusinessEntities;
using appVentas.DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace appVentas.DataAccess.Repositorio
{
    public class RepositoryProductoDA : IRepositoryProductoDA<ProductoBE>
    {
        private readonly string _connectionString;
        private IConfiguration Configuration { get; }

        public RepositoryProductoDA(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public List<ProductoBE> GetAllProductos()
        {
            List<ProductoBE> lstProducto = new List<ProductoBE>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspGetAllProductos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                 
                    ProductoBE productoBE = new ProductoBE();
                    productoBE.CodProd = reader["COD_PROD"].ToString();
                    productoBE.NomProd = reader["NOM_PROD"].ToString();
                    productoBE.CodGrup = reader["COD_GRUP"].ToString();
                    productoBE.CodLin = reader["COD_LIN"].ToString();
                    productoBE.Marca = reader["MARCA"].ToString();
                    productoBE.CosPromC = Convert.ToDecimal(reader["COS_PROM_C"]);
                    productoBE.PrecioVta = Convert.ToDecimal(reader["PRECIO_VTA"]);
                    lstProducto.Add(productoBE);
                }
                connection.Close();
                return lstProducto;
            }
        }

        public ProductoBE GetByIdProducto(ProductoBE producto)
        {
            ProductoBE productoBE = new ProductoBE();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspGetByIdProducto", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@COD_PROD", SqlDbType.VarChar, 25, "COD_PROD").Value = producto.CodProd;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                   
                    productoBE.CodProd = reader["COD_PROD"].ToString();
                    productoBE.NomProd = reader["NOM_PROD"].ToString();
                    productoBE.CodGrup = reader["COD_GRUP"].ToString();
                    productoBE.CodLin = reader["COD_LIN"].ToString();
                    productoBE.Marca = reader["MARCA"].ToString();
                    productoBE.CosPromC = Convert.ToDecimal(reader["COS_PROM_C"]);
                    productoBE.PrecioVta = Convert.ToDecimal(reader["PRECIO_VTA"]);                   
                }
                connection.Close();
                return productoBE;
            }
        }

        public bool InsertProducto(ProductoBE producto)
        {
            bool boolRegistrado;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspInsertProducto", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@COD_PROD", SqlDbType.VarChar).Value = producto.CodProd;
                cmd.Parameters.Add("@NOM_PROD", SqlDbType.VarChar).Value = producto.NomProd;
                cmd.Parameters.Add("@COD_GRUP", SqlDbType.Char).Value = producto.CodGrup;
                cmd.Parameters.Add("@COD_LIN", SqlDbType.Char).Value = producto.CodLin;
                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = producto.Marca;
                cmd.Parameters.Add("@COS_PROM_C", SqlDbType.Money).Value = producto.CosPromC;
                cmd.Parameters.Add("@PRECIO_VTA", SqlDbType.Money).Value = producto.PrecioVta;
                connection.Open();
                boolRegistrado = cmd.ExecuteNonQuery() != 0;
                connection.Close();
                return boolRegistrado;
            }
        }

        public bool UpdateProducto(ProductoBE producto)
        {
            bool boolActualizado;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspUpdateProducto", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@COD_PROD", SqlDbType.VarChar).Value = producto.CodProd;
                cmd.Parameters.Add("@NOM_PROD", SqlDbType.VarChar).Value = producto.NomProd;
                cmd.Parameters.Add("@COD_GRUP", SqlDbType.Char).Value = producto.CodGrup;
                cmd.Parameters.Add("@COD_LIN", SqlDbType.Char).Value = producto.CodLin;
                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = producto.Marca;
                cmd.Parameters.Add("@COS_PROM_C", SqlDbType.Money).Value = producto.CosPromC;
                cmd.Parameters.Add("@PRECIO_VTA", SqlDbType.Money).Value = producto.PrecioVta;
                connection.Open();
                boolActualizado = cmd.ExecuteNonQuery() != 0;
                connection.Close();
                return boolActualizado;
            }
        }

        public bool DeleteProducto(ProductoBE producto)
        {
            bool boolEliminado;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspDeleteProducto", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@COD_PROD", SqlDbType.VarChar).Value = producto.CodProd;            
                connection.Open();
                boolEliminado = cmd.ExecuteNonQuery() != 0;
                connection.Close();
                return boolEliminado;
            }
        }
    }
}

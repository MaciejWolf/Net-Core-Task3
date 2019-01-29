using System;
using System.Linq.Expressions;
using AutoMapper;
using Northwind.Application.Interfaces.Mapping;
using Northwind.Domain.Entities;

namespace Northwind.Application.Products.Queries.GetAllProducts
{
    public class ProductDto : IHaveCustomMapping
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? SupplierId { get; set; }

        public string SupplierCompanyName { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool Discontinued { get; set; }

        public void CreateMappings(Profile configuration)
        {
            
        }
    }
}
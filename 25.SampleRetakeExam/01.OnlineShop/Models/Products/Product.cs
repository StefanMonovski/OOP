using OnlineShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            if (id <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductId);
            }
            Id = id;
            if (string.IsNullOrWhiteSpace(manufacturer))
            {
                throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
            }
            Manufacturer = manufacturer;
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException(ExceptionMessages.InvalidModel);
            }
            Model = model;
            if (price <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPrice);
            }
            Price = price;
            if (overallPerformance <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
            }
            OverallPerformance = overallPerformance;
        }
        
        public int Id { get; }
        public string Manufacturer { get; }
        public string Model { get; }
        public virtual decimal Price { get; }
        public virtual double OverallPerformance { get; }

        public override string ToString()
        {
            return string.Format(SuccessMessages.ProductToString, $"{OverallPerformance:f2}", $"{Price:f2}", GetType().Name, Manufacturer, Model, Id);
        }
    }
}

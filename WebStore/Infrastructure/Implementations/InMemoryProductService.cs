using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.Filters;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class InMemoryProductService : IProductService
    {
        private readonly List<Category> _categories;
        private readonly List<Brand> _brands;
        private readonly List<Product> _products;
        public InMemoryProductService()
        {
            _categories = new List<Category>()
            {
                new Category()
                {
                    ID = 1,
                    Name = "Sportswear",
                    Order = 0,
                    ParentID = null
                },
                new Category()
                {
                    ID = 2,
                    Name = "Nike",
                    Order = 0,
                    ParentID = 1
                },
                new Category()
                {
                    ID = 3,
                    Name = "Under Armour",
                    Order = 1,
                    ParentID = 1
                },
                new Category()
                {
                    ID = 4,
                    Name = "Adidas",
                    Order = 2,
                    ParentID = 1
                },
                new Category()
                {
                    ID = 5,
                    Name = "Puma",
                    Order = 3,
                    ParentID = 1
                },
                new Category()
                {
                    ID = 6,
                    Name = "ASICS",
                    Order = 4,
                    ParentID = 1
                },
                new Category()
                {
                    ID = 7,
                    Name = "Mens",
                    Order = 1,
                    ParentID = null
                },
                new Category()
                {
                    ID = 8,
                    Name = "Fendi",
                    Order = 0,
                    ParentID = 7
                },
                new Category()
                {
                    ID = 9,
                    Name = "Guess",
                    Order = 1,
                    ParentID = 7
                },
                new Category()
                {
                    ID = 10,
                    Name = "Valentino",
                    Order = 2,
                    ParentID = 7
                },
                new Category()
                {
                    ID = 11,
                    Name = "Dior",
                    Order = 3,
                    ParentID = 7
                },
                new Category()
                {
                    ID = 12,
                    Name = "Versace",
                    Order = 4,
                    ParentID = 7
                },
                new Category()
                {
                    ID = 13,
                    Name = "Armani",
                    Order = 5,
                    ParentID = 7
                },
                new Category()
                {
                    ID = 14,
                    Name = "Prada",
                    Order = 6,
                    ParentID = 7
                },
                new Category()
                {
                    ID = 15,
                    Name = "Dolce and Gabbana",
                    Order = 7,
                    ParentID = 7
                },
                new Category()
                {
                    ID = 16,
                    Name = "Chanel",
                    Order = 8,
                    ParentID = 7
                },
                new Category()
                {
                    ID = 17,
                    Name = "Gucci",
                    Order = 1,
                    ParentID = 7
                },
                new Category()
                {
                    ID = 18,
                    Name = "Womens",
                    Order = 2,
                    ParentID = null
                },
                new Category()
                {
                    ID = 19,
                    Name = "Fendi",
                    Order = 0,
                    ParentID = 18
                },
                new Category()
                {
                    ID = 20,
                    Name = "Guess",
                    Order = 1,
                    ParentID = 18
                },
                new Category()
                {
                    ID = 21,
                    Name = "Valentino",
                    Order = 2,
                    ParentID = 18
                },
                new Category()
                {
                    ID = 22,
                    Name = "Dior",
                    Order = 3,
                    ParentID = 18
                },
                new Category()
                {
                    ID = 23,
                    Name = "Versace",
                    Order = 4,
                    ParentID = 18
                },
                new Category()
                {
                    ID = 24,
                    Name = "Kids",
                    Order = 3,
                    ParentID = null
                },
                new Category()
                {
                    ID = 25,
                    Name = "Fashion",
                    Order = 4,
                    ParentID = null
                },
                new Category()
                {
                    ID = 26,
                    Name = "Households",
                    Order = 5,
                    ParentID = null
                },
                new Category()
                {
                    ID = 27,
                    Name = "Interiors",
                    Order = 6,
                    ParentID = null
                },
                new Category()
                {
                    ID = 28,
                    Name = "Clothing",
                    Order = 7,
                    ParentID = null
                },
                new Category()
                {
                    ID = 29,
                    Name = "Bags",
                    Order = 8,
                    ParentID = null
                },
                new Category()
                {
                    ID = 30,
                    Name = "Shoes",
                    Order = 9,
                    ParentID = null
                }
            };
            _brands = new List<Brand>()
            {
                new Brand()
                {
                    ID = 1,
                    Name = "Acne",
                    Order = 0
                },
                new Brand()
                {
                    ID = 2,
                    Name = "Grüne Erde",
                    Order = 1
                },
                new Brand()
                {
                    ID = 3,
                    Name = "Albiro",
                    Order = 2
                },
                new Brand()
                {
                    ID = 4,
                    Name = "Ronhill",
                    Order = 3
                },
                new Brand()
                {
                    ID = 5,
                    Name = "Oddmolly",
                    Order = 4
                },
                new Brand()
                {
                    ID = 6,
                    Name = "Boudestijn",
                    Order = 5
                },
                new Brand()
                {
                    ID = 7,
                    Name = "Rösch creative culture",
                    Order = 6
                },
            };
            _products = new List<Product>()
            {
                new Product()
                {
                    ID = 1,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product1.jpg",
                    Order = 0,
                    CategoryId = 2,
                    BrandId = 1
                },
                new Product()
                {
                    ID = 2,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product2.jpg",
                    Order = 1,
                    CategoryId = 2,
                    BrandId = 1
                },
                new Product()
                {
                    ID = 3,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product3.jpg",
                    Order = 2,
                    CategoryId = 2,
                    BrandId = 1
                },
                new Product()
                {
                    ID = 4,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product4.jpg",
                    Order = 3,
                    CategoryId = 2,
                    BrandId = 1
                },
                new Product()
                {
                    ID = 5,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product5.jpg",
                    Order = 4,
                    CategoryId = 2,
                    BrandId = 2
                },
                new Product()
                {
                    ID = 6,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product6.jpg",
                    Order = 5,
                    CategoryId = 2,
                    BrandId = 2
                },
                new Product()
                {
                    ID = 7,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product7.jpg",
                    Order = 6,
                    CategoryId = 2,
                    BrandId = 2
                },
                new Product()
                {
                    ID = 8,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product8.jpg",
                    Order = 7,
                    CategoryId = 25,
                    BrandId = 2
                },
                new Product()
                {
                    ID = 9,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product9.jpg",
                    Order = 8,
                    CategoryId = 25,
                    BrandId = 2
                },
                new Product()
                {
                    ID = 10,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product10.jpg",
                    Order = 9,
                    CategoryId = 25,
                    BrandId = 3
                },
                new Product()
                {
                    ID = 11,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product11.jpg",
                    Order = 10,
                    CategoryId = 25,
                    BrandId = 3
                },
                new Product()
                {
                    ID = 12,
                    Name = "Easy Polo Black Edition",
                    Price = 1025,
                    ImageUrl = "product12.jpg",
                    Order = 11,
                    CategoryId = 25,
                    BrandId = 3
                },
            };
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _brands;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var products = _products;

            if (filter.CategoryId.HasValue)
                products = products
                    .Where(p => p.CategoryId.Equals(filter.CategoryId))
                    .ToList();
            if (filter.BrandId.HasValue)
                products = products
                    .Where(p => p.BrandId.HasValue && p.BrandId.Value.Equals(filter.BrandId.Value))
                    .ToList();
            
            return products;

        }
    }
}

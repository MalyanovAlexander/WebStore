using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class InMemoryProductService : IProductService
    {
        private readonly List<Category> _categories;
        private readonly List<Brand> _brands;
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
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _brands;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }
    }
}
